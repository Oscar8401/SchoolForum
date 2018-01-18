using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolForum.Models;
using SchoolForum.Models.ViewModel;

namespace SchoolForum.Controllers
{
    public class MessageViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MessageViewModels
        public ActionResult Index()
        {
            return View(db.MessageViewModels.ToList());
        }

        // GET: MessageViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageViewModel messageViewModel = db.MessageViewModels.Find(id);
            if (messageViewModel == null)
            {
                return HttpNotFound();
            }
            return View(messageViewModel);
        }

        // GET: MessageViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Textreply,PostingDate")] MessageViewModel messageViewModel)
        {
            if (ModelState.IsValid)
            {
                db.MessageViewModels.Add(messageViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageViewModel);
        }

        // GET: MessageViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageViewModel messageViewModel = db.MessageViewModels.Find(id);
            if (messageViewModel == null)
            {
                return HttpNotFound();
            }
            return View(messageViewModel);
        }

        // POST: MessageViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Textreply,PostingDate")] MessageViewModel messageViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageViewModel);
        }

        // GET: MessageViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageViewModel messageViewModel = db.MessageViewModels.Find(id);
            if (messageViewModel == null)
            {
                return HttpNotFound();
            }
            return View(messageViewModel);
        }

        // POST: MessageViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageViewModel messageViewModel = db.MessageViewModels.Find(id);
            db.MessageViewModels.Remove(messageViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: MessageViewModels/Reply
        public ActionResult Rely()
        {
            return View();
        }

        // POST: MessageViewModels/Reply
        [HttpPost]
        public ActionResult Reply( MessageViewModel messageViewModel)
        {
            int Id = messageViewModel.Id;
            string Textreply = messageViewModel.Textreply;
            //if (ModelState.IsValid)
            //{
            //    db.MessageViewModels.Add(messageViewModel);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(messageViewModel);
            return View(messageViewModel);
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
