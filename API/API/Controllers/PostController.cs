using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static API.Models.Message;

namespace API.Controllers
{
    public class PostController : ApiController
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        public static readonly HttpClient _httpClient = new HttpClient();

        // GET api/values
        public List<MessageResponse> Get(int page, int size)
        {
            List<MessageResponse> Response = new List<MessageResponse>();
            Response = JsonConvert.DeserializeObject<List<MessageResponse>>(_httpClient.GetStringAsync(url).Result);
            Response = Response.Skip((page-1)*size).Take(size).ToList();
            return (Response);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
