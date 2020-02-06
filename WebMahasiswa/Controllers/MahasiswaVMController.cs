using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMahasiswa.Models;

namespace WebMahasiswa.Controllers
{
    public class MahasiswaVMController : Controller
    {
        private ADAL db = new ADAL();

        // GET: MahasiswaVM
        public ActionResult Index()
        {
            return View(db.MahasiswaVMs.ToList());
        }

        // GET: MahasiswaVM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MahasiswaVM mahasiswaVM = db.MahasiswaVMs.Find(id);
            if (mahasiswaVM == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswaVM);
        }

        // GET: MahasiswaVM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MahasiswaVM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMahasiswa,NamaMahasiswa")] MahasiswaVM mahasiswaVM)
        {
            if (ModelState.IsValid)
            {
                db.MahasiswaVMs.Add(mahasiswaVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mahasiswaVM);
        }

        // GET: MahasiswaVM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MahasiswaVM mahasiswaVM = db.MahasiswaVMs.Find(id);
            if (mahasiswaVM == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswaVM);
        }

        // POST: MahasiswaVM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMahasiswa,NamaMahasiswa")] MahasiswaVM mahasiswaVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahasiswaVM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mahasiswaVM);
        }

        // GET: MahasiswaVM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MahasiswaVM mahasiswaVM = db.MahasiswaVMs.Find(id);
            if (mahasiswaVM == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswaVM);
        }

        // POST: MahasiswaVM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MahasiswaVM mahasiswaVM = db.MahasiswaVMs.Find(id);
            db.MahasiswaVMs.Remove(mahasiswaVM);
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
