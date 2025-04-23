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
    public class BatchController : Controller
    {
        SMSDbContext _db=new SMSDbContext();
        // GET: Batch
        public ActionResult Index()
        {
            var list=_db.Batchs.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Batch batch)
        {
            if (ModelState.IsValid)
            {
                _db.Batchs.Add(batch);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(batch);
        }
        public ActionResult Edit(int? Id)
        {
            if(Id== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var batch = _db.Batchs.Find(Id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Batch batch)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(batch).State=EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(batch);
        }
        public ActionResult Details(int?Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var batch = _db.Batchs.Find(Id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var batch= _db.Batchs.Find(Id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
                 var batch=_db.Batchs.Find(Id);
                _db.Batchs.Remove(batch);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }
    }
}