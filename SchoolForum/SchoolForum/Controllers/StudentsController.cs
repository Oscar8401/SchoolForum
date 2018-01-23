using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolForum.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SchoolForum.Models.ViewModel;

namespace SchoolForum.Controllers
{
    //[Authorize(Roles = "teacher")]
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
           
            List<Students> Studentlist = new List<Students>();
            foreach (var x in db.Users.ToList())
            {
                Students Student = new Students(x);
                Studentlist.Add(Student);
            }
            return View(Studentlist);
        }

        // GET: Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationuser = db.Users.Find(id);
            if (applicationuser == null)
            {
                return HttpNotFound();
            }
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ICollection<string> rolename = userManager.GetRoles(applicationuser.Id);
            Students member = new Students(applicationuser);
            member.StudentRole = rolename;
            return View(member);
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





























//[Authorize(Roles ="teacher")]
//public class StudentsController : Controller
//{
//    private ApplicationDbContext db = new ApplicationDbContext();

// GET: Students
//        public ActionResult Index()
//        {
//            List<Students> Studentlist = new List<Students>();
//            foreach (var item in db.Users.ToList()) { }
//            {
//                Students Student = new Students(x);
//                Studentlist.Add(Student);
//            }
//            return View(Studentlist);
//        }

//        // GET: Students/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Categories categories = db.Categories.Find(id);
//            if (categories == null)
//            {
//                return HttpNotFound();
//            }
//            return View(categories);
//        }

//        // GET: Students/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Students/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Name,Description,Members")] Categories categories)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Categories.Add(categories);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(categories);
//        }

//        // GET: Students/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Categories categories = db.Categories.Find(id);
//            if (categories == null)
//            {
//                return HttpNotFound();
//            }
//            return View(categories);
//        }

//        // POST: Students/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Name,Description,Members")] Categories categories)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(categories).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(categories);
//        }

//        // GET: Students/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Categories categories = db.Categories.Find(id);
//            if (categories == null)
//            {
//                return HttpNotFound();
//            }
//            return View(categories);
//        }

//        // POST: Students/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Categories categories = db.Categories.Find(id);
//            db.Categories.Remove(categories);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
