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
    public class CategoriesViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoriesViewModels
        public ActionResult Index( string SearchTerm)
        {
            return View(db.CategoriesViewModels.Where(x => x.Name.Contains(SearchTerm) || SearchTerm == null).ToList());
        }
        // GET: CategoriesViewModels/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {
            ViewBag.Members = new SelectList(db.Users, "Id", "FirstName", "LastName");
            return View();
        }

        // POST: CategoriesViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Members,MemebersCount,NumberOfMessages,CreatingTime,User")] CategoriesViewModel categoriesViewModel)
        {
            //CategoriesViewModel SchoolForumDB = db.CategoriesViewModels.Single(x => x.Id == categoriesViewModel.Id);
            //SchoolForumDB.Id = categoriesViewModel.Id;
            //SchoolForumDB.Name = categoriesViewModel.Name;
            //SchoolForumDB.Description = categoriesViewModel.Description;
            //SchoolForumDB.Members = categoriesViewModel.Members;
            //SchoolForumDB.MemebersCount = categoriesViewModel.MemebersCount;
            //SchoolForumDB.NumberOfMessages = categoriesViewModel.NumberOfMessages;
            //SchoolForumDB.CreatingTime = DateTime.Now;
            //SchoolForumDB.User = categoriesViewModel.User;
            if (ModelState.IsValid)
            {
                db.CategoriesViewModels.Add(categoriesViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriesViewModel);
        }

        // GET: CategoriesViewModels/Edit/5
        [Authorize(Roles ="Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriesViewModel categoriesViewModel = db.CategoriesViewModels.Find(id);
            if (categoriesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriesViewModel);
        }

        // POST: CategoriesViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Teacher")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Members,MemebersCount,NumberOfMessages,CreatingTime,User")] CategoriesViewModel categoriesViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriesViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriesViewModel);
        }

        // GET: CategoriesViewModels/Delete/5
        [Authorize(Roles ="Teacher")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriesViewModel categoriesViewModel = db.CategoriesViewModels.Find(id);
            if (categoriesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriesViewModel);
        }

        // POST: CategoriesViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Teacher")]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriesViewModel categoriesViewModel = db.CategoriesViewModels.Find(id);
            db.CategoriesViewModels.Remove(categoriesViewModel);
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
