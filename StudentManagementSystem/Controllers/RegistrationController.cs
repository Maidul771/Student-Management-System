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
    public class RegistrationController : Controller
    {
        SMSDbContext _db=new SMSDbContext();
        // GET: Registration
        public ActionResult Index()
        {
            var registrations = _db.Registrations.Include("Course").Include("Batch").ToList();
            return View(registrations);

        }
        // GET: Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_db.Courses, "Id", "CourseName");
            ViewBag.BatchID = new SelectList(_db.Batchs, "Id", "BatchName");
            return View();
        }
        // POST:Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                _db.Registrations.Add(registration);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(_db.Courses, "Id", "CourseName", registration.CourseId);
            ViewBag.BatchID = new SelectList(_db.Batchs, "Id", "BatchName", registration.BatchId);
            return View(registration);
        }
        // GET: Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var registration = _db.Registrations.Find(id);
            if (registration == null)
                return HttpNotFound();

            ViewBag.CourseId = new SelectList(_db.Courses, "Id", "CourseName", registration.CourseId);
            ViewBag.BatchID = new SelectList(_db.Batchs, "Id", "BatchName", registration.BatchId);
            return View(registration);
        }

        // POST:Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registration registration)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(registration).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(_db.Courses, "Id", "CourseName", registration.CourseId);
            ViewBag.BatchID = new SelectList(_db.Batchs, "Id", "BatchName", registration.BatchId);
            return View(registration);
        }
        // GET:Delete
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var registration = _db.Registrations.Include(r => r.Course).Include(r => r.Batch).FirstOrDefault(r => r.Id == Id);
            if (registration == null)
                return HttpNotFound();

            return View(registration);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            Registration registration = _db.Registrations.Find(Id);
            _db.Registrations.Remove(registration);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Registration/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var registration = _db.Registrations.Include(r => r.Course).Include(r => r.Batch).FirstOrDefault(r => r.Id == Id);

            if (registration == null)
                return HttpNotFound();

            return View(registration);
        }
    }
}