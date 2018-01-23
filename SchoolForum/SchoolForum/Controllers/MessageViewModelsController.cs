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
            return View(db.MessagesViewModels.ToList());
        }
        // GET: MessageViewModels/Create
        public ActionResult Create()
        {
            ApplicationDbContext schoolForum = new ApplicationDbContext();
            ViewBag.Category = new SelectList(schoolForum.Categories, "Id", "Name");
            return View();
        }

        // POST: MessageViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,NumberOfMessages,User,PostingDate,CategoryName")] MessagesViewModel messagesViewModel)
        {
            if (ModelState.IsValid)
            {
                db.MessagesViewModels.Add(messagesViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messagesViewModel);
        }

        // GET: MessageViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessagesViewModel messagesViewModel = db.MessagesViewModels.Find(id);
            if (messagesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(messagesViewModel);
        }

        // POST: MessageViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "User,CategoryName")] MessagesViewModel messagesViewModel)
        {
            MessagesViewModel SchoolForumDB = db.MessagesViewModels.Single(x => x.Id == messagesViewModel.Id);
            SchoolForumDB.Title = messagesViewModel.Title;
            SchoolForumDB.Text = messagesViewModel.Text;
            SchoolForumDB.PostingDate = DateTime.Now;
            messagesViewModel.User = SchoolForumDB.User;
            messagesViewModel.CategoryName = SchoolForumDB.CategoryName;
            if (ModelState.IsValid)
            {
                ////db.Entry(messagesViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messagesViewModel);
        }

        // GET: MessageViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessagesViewModel messagesViewModel = db.MessagesViewModels.Find(id);
            if (messagesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(messagesViewModel);
        }

        // POST: MessageViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessagesViewModel messagesViewModel = db.MessagesViewModels.Find(id);
            db.MessagesViewModels.Remove(messagesViewModel);
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
