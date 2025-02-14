using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static API.Models.GlobalModel;

namespace API.Controllers
{
    public class PostController : ApiController
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        public static readonly HttpClient _httpClient = new HttpClient();

        // GET api/values
        public GlobalMessage Get(int page, int size)
        {
            GlobalMessage Model = new GlobalMessage();
            Model.listMessage = new List<Message>();
            try
            {
                var strData = _httpClient.GetStringAsync(url).Result;
                Model.listMessage = JsonConvert.DeserializeObject<List<Message>>(strData);
                Model.listMessage = Model.listMessage.Skip((page - 1) * size).Take(size).ToList();
                Model.status = "Success";
            }
            catch (Exception e)
            {
                Model.status = "failed";
                Model.errorMssage = "Service Sedang tidak gangguan harp coba beberapa saat lagi";
            }

            return (Model);
        }

    }
}
