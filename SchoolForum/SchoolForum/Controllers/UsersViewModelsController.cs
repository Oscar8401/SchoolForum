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
    public class UsersViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UsersViewModels
        public ActionResult Index()
        {
            List<UsersViewModels> UsersList = new List<UsersViewModels>();
            foreach (var q in db.Users.ToList())
            {
                UsersViewModels users = new UsersViewModels();
                UsersList.Add(users);
            }
            
            //return View(db.UsersViewModels.ToList());
            return View(UsersList);
        }
        

   

        // GET: UsersViewModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersViewModels usersViewModels = db.UsersViewModels.Find(id);
            if (usersViewModels == null)
            {
                return HttpNotFound();
            }
            return View(usersViewModels);
        }

        // POST: UsersViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UsersViewModels usersViewModels = db.UsersViewModels.Find(id);
            db.UsersViewModels.Remove(usersViewModels);
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
