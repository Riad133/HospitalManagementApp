using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalMangementApp.Models;

namespace HospitalMangementApp.Controllers
{
    public class DoctorDepartmentController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        // GET: DoctorDepartment
        public ActionResult Index()
        {
            return View(db.DoctorDepartment.ToList());
        }

        // GET: DoctorDepartment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDepartment doctorDepartment = db.DoctorDepartment.Find(id);
            if (doctorDepartment == null)
            {
                return HttpNotFound();
            }
            return View(doctorDepartment);
        }

        // GET: DoctorDepartment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorDepartment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorDepartmentId,DoctorDepartmentName")] DoctorDepartment doctorDepartment)
        {
            if (ModelState.IsValid)
            {
                db.DoctorDepartment.Add(doctorDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorDepartment);
        }

        // GET: DoctorDepartment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDepartment doctorDepartment = db.DoctorDepartment.Find(id);
            if (doctorDepartment == null)
            {
                return HttpNotFound();
            }
            return View(doctorDepartment);
        }

        // POST: DoctorDepartment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorDepartmentId,DoctorDepartmentName")] DoctorDepartment doctorDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorDepartment);
        }

        // GET: DoctorDepartment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDepartment doctorDepartment = db.DoctorDepartment.Find(id);
            if (doctorDepartment == null)
            {
                return HttpNotFound();
            }
            return View(doctorDepartment);
        }

        // POST: DoctorDepartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorDepartment doctorDepartment = db.DoctorDepartment.Find(id);
            db.DoctorDepartment.Remove(doctorDepartment);
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
