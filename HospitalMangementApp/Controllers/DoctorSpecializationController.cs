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
    public class DoctorSpecializationController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        // GET: DoctorSpecialization
        public ActionResult Index()
        {
            return View(db.DoctorSpecialization.ToList());
        }

        // GET: DoctorSpecialization/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorSpecialization doctorSpecialization = db.DoctorSpecialization.Find(id);
            if (doctorSpecialization == null)
            {
                return HttpNotFound();
            }
            return View(doctorSpecialization);
        }

        // GET: DoctorSpecialization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorSpecialization/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorSpecializationId,Specialization")] DoctorSpecialization doctorSpecialization)
        {
            if (ModelState.IsValid)
            {
                db.DoctorSpecialization.Add(doctorSpecialization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorSpecialization);
        }

        // GET: DoctorSpecialization/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorSpecialization doctorSpecialization = db.DoctorSpecialization.Find(id);
            if (doctorSpecialization == null)
            {
                return HttpNotFound();
            }
            return View(doctorSpecialization);
        }

        // POST: DoctorSpecialization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorSpecializationId,Specialization")] DoctorSpecialization doctorSpecialization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorSpecialization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorSpecialization);
        }

        // GET: DoctorSpecialization/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorSpecialization doctorSpecialization = db.DoctorSpecialization.Find(id);
            if (doctorSpecialization == null)
            {
                return HttpNotFound();
            }
            return View(doctorSpecialization);
        }

        // POST: DoctorSpecialization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorSpecialization doctorSpecialization = db.DoctorSpecialization.Find(id);
            db.DoctorSpecialization.Remove(doctorSpecialization);
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
