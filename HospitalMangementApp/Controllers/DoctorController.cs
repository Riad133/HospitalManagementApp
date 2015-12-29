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
    public class DoctorController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        // GET: Doctor
        public ActionResult Index()
        {
            var doctor = db.Doctor.Include(d => d.DoctorDepartment).Include(d => d.DoctorSpecialization);
            return View(doctor.ToList());
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            ViewBag.DoctorDepartmentId = new SelectList(db.DoctorDepartment, "DoctorDepartmentId", "DoctorDepartmentName");
            ViewBag.DoctorSpecializationId = new SelectList(db.DoctorSpecialization, "DoctorSpecializationId", "Specialization");
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,Name,Email,DoctorDepartmentId,Degree,DoctorSpecializationId,Phone")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctor.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorDepartmentId = new SelectList(db.DoctorDepartment, "DoctorDepartmentId", "DoctorDepartmentName", doctor.DoctorDepartmentId);
            ViewBag.DoctorSpecializationId = new SelectList(db.DoctorSpecialization, "DoctorSpecializationId", "Specialization", doctor.DoctorSpecializationId);
            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorDepartmentId = new SelectList(db.DoctorDepartment, "DoctorDepartmentId", "DoctorDepartmentName", doctor.DoctorDepartmentId);
            ViewBag.DoctorSpecializationId = new SelectList(db.DoctorSpecialization, "DoctorSpecializationId", "Specialization", doctor.DoctorSpecializationId);
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,Name,Email,DoctorDepartmentId,Degree,DoctorSpecializationId,Phone")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorDepartmentId = new SelectList(db.DoctorDepartment, "DoctorDepartmentId", "DoctorDepartmentName", doctor.DoctorDepartmentId);
            ViewBag.DoctorSpecializationId = new SelectList(db.DoctorSpecialization, "DoctorSpecializationId", "Specialization", doctor.DoctorSpecializationId);
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctor.Find(id);
            db.Doctor.Remove(doctor);
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
