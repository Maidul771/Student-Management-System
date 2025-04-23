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
    public class CourseController : Controller
    {
        SMSDbContext _db = new SMSDbContext();
        // GET: Course
        public ActionResult Index()
        {
            var list = _db.Courses.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        //POST: Get
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }
        //GET:EDIT
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = _db.Courses.Find(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        //POST:Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(course).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            var course = _db.Courses.Find(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        //GET: DELETE
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            var course = _db.Courses.Find(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            var course = _db.Courses.Find(Id);
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
           
        
    }
}