using StudentManagementSystem.Filters;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    //[Authorize]
    [CustomAuthorization]
    public class UserController : Controller
    {
        SMSDbContext _db=new SMSDbContext();
        // GET:all User
        public ActionResult Index()
        {
            var list=_db.Users.ToList();
            return View(list);
        }
        //Get:Create
        public ActionResult Create()
        {
            return View();
        }
        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        //Get:Edit
        public ActionResult Edit(int?Id)
        {
            if(Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _db.Users.Find(Id);
            if(user==null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
              return View(user);
        }
        public ActionResult Details(int? Id)
        {
            if(Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _db.Users.Find(Id);
            if(user==null) 
            {
                return HttpNotFound();
            }
            return View(user);
        }
        //Get: Delete
        public ActionResult Delete(int? Id)
        {
            if(Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _db.Users.Find(Id);
            if(user==null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? Id)
        {
            var user= _db.Users.Find(Id);
            _db.Users.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}