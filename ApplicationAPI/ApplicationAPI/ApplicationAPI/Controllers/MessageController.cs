using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ApplicationAPI.Models;
using Newtonsoft.Json;
using static ApplicationAPI.Models.GlobalModel;
using PagedList;

namespace ApplicationAPI.Controllers
{
    public class MessageController : Controller
    {
        private INDOPAYROLL_SITEntities db = new INDOPAYROLL_SITEntities();

        string urlAPI = "https://localhost:44358/api/Post";
        public static readonly HttpClient _httpClient = new HttpClient();

        // GET: Message
        public ActionResult Index(int page = 1, int size = 10)
        {

            List<MessageResponse> Response = new List<MessageResponse>();
            string url = $"{urlAPI}?page={page}&size={size}";
            var data = _httpClient.GetStringAsync(urlAPI).Result;
            Response = JsonConvert.DeserializeObject<List<MessageResponse>>(data);

            return View(Response);
        }

        // GET: Message/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Error_Log tbl_Error_Log = db.tbl_Error_Log.Find(id);
            if (tbl_Error_Log == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Error_Log);
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Log_Date,Error_Source,Error_Description,Created_By")] tbl_Error_Log tbl_Error_Log)
        {
            if (ModelState.IsValid)
            {
                tbl_Error_Log.id = Guid.NewGuid();
                db.tbl_Error_Log.Add(tbl_Error_Log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Error_Log);
        }

        // GET: Message/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Error_Log tbl_Error_Log = db.tbl_Error_Log.Find(id);
            if (tbl_Error_Log == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Error_Log);
        }

        // POST: Message/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Log_Date,Error_Source,Error_Description,Created_By")] tbl_Error_Log tbl_Error_Log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Error_Log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Error_Log);
        }

        // GET: Message/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Error_Log tbl_Error_Log = db.tbl_Error_Log.Find(id);
            if (tbl_Error_Log == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Error_Log);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_Error_Log tbl_Error_Log = db.tbl_Error_Log.Find(id);
            db.tbl_Error_Log.Remove(tbl_Error_Log);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
