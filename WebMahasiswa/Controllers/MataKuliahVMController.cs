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
    public class MataKuliahVMController : Controller
    {
        private ADAL db = new ADAL();

        // GET: MataKuliahVM
        public ActionResult Index()
        {
            return View(db.MataKuliahVMs.ToList());
        }

        // GET: MataKuliahVM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MataKuliahVM mataKuliahVM = db.MataKuliahVMs.Find(id);
            if (mataKuliahVM == null)
            {
                return HttpNotFound();
            }
            return View(mataKuliahVM);
        }

        // GET: MataKuliahVM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MataKuliahVM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMataKuliah,MataKuliah")] MataKuliahVM mataKuliahVM)
        {
            if (ModelState.IsValid)
            {
                db.MataKuliahVMs.Add(mataKuliahVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mataKuliahVM);
        }

        // GET: MataKuliahVM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MataKuliahVM mataKuliahVM = db.MataKuliahVMs.Find(id);
            if (mataKuliahVM == null)
            {
                return HttpNotFound();
            }
            return View(mataKuliahVM);
        }

        // POST: MataKuliahVM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMataKuliah,MataKuliah")] MataKuliahVM mataKuliahVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mataKuliahVM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mataKuliahVM);
        }

        // GET: MataKuliahVM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MataKuliahVM mataKuliahVM = db.MataKuliahVMs.Find(id);
            if (mataKuliahVM == null)
            {
                return HttpNotFound();
            }
            return View(mataKuliahVM);
        }

        // POST: MataKuliahVM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MataKuliahVM mataKuliahVM = db.MataKuliahVMs.Find(id);
            db.MataKuliahVMs.Remove(mataKuliahVM);
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
