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
    public class IndoorPatientController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        // GET: IndoorPatient
        public ActionResult Index()
        {
            var indoorPatient = db.IndoorPatient.Include(i => i.Bed).Include(i => i.Doctor);
            return View(indoorPatient.ToList());
        }

        // GET: IndoorPatient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndoorPatient indoorPatient = db.IndoorPatient.Find(id);
            if (indoorPatient == null)
            {
                return HttpNotFound();
            }
            return View(indoorPatient);
        }

        // GET: IndoorPatient/Create
        public ActionResult Create()
        {
            ViewBag.BedId = new SelectList(db.Bed, "BedId", "BedNo");
            ViewBag.DoctorId = new SelectList(db.Doctor, "DoctorId", "Name");
            return View();
        }

        // POST: IndoorPatient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IndoorPatientId,Name,Age,Gender,BedId,Admissiondate,Releasedate,DoctorId")] IndoorPatient indoorPatient)
        {
            if (ModelState.IsValid)
            {
                db.IndoorPatient.Add(indoorPatient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BedId = new SelectList(db.Bed, "BedId", "BedNo",+ indoorPatient.BedId);



            


            ViewBag.DoctorId = new SelectList(db.Doctor, "DoctorId", "Name", indoorPatient.DoctorId);
            return View(indoorPatient);
        }

        // GET: IndoorPatient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndoorPatient indoorPatient = db.IndoorPatient.Find(id);
            if (indoorPatient == null)
            {
                return HttpNotFound();
            }
            ViewBag.BedId = new SelectList(db.Bed, "BedId", "BedNo", indoorPatient.BedId);
            ViewBag.DoctorId = new SelectList(db.Doctor, "DoctorId", "Name", indoorPatient.DoctorId);
            return View(indoorPatient);
        }

        // POST: IndoorPatient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IndoorPatientId,Name,Age,Gender,BedId,Admissiondate,Releasedate,DoctorId")] IndoorPatient indoorPatient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indoorPatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BedId = new SelectList(db.Bed, "BedId", "BedNo", indoorPatient.BedId);
            ViewBag.DoctorId = new SelectList(db.Doctor, "DoctorId", "Name", indoorPatient.DoctorId);
            return View(indoorPatient);
        }

        // GET: IndoorPatient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndoorPatient indoorPatient = db.IndoorPatient.Find(id);
            if (indoorPatient == null)
            {
                return HttpNotFound();
            }
            return View(indoorPatient);
        }

        // POST: IndoorPatient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndoorPatient indoorPatient = db.IndoorPatient.Find(id);
            db.IndoorPatient.Remove(indoorPatient);
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
