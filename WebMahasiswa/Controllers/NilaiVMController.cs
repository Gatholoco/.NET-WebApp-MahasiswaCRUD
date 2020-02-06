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
    public class NilaiVMController : Controller
    {
        private ADAL db = new ADAL();

        // GET: NilaiVM
        public ActionResult Index(string F_NamaMahasiswa = "", string F_MataKuliah = "")
        {
            var dataMataKuliah = db.MataKuliahVMs.ToList();
            var listMataKuliah = new List<SelectListItem>();
            foreach (var i in dataMataKuliah)
            {
                listMataKuliah.Add(new SelectListItem() { Text = i.MataKuliah, Value = i.IdMataKuliah.ToString() });
            }


            var _temp = (from n in db.NilaiVMs
                         join m in db.MahasiswaVMs on n.IdMahasiswa equals m.IdMahasiswa
                         join mk in db.MataKuliahVMs on n.IdMataKuliah equals mk.IdMataKuliah
                         select new tempNIlaiVM()
                         {
                             IdMahasiswa = m.IdMahasiswa,
                             NamaMahasiswa = m.NamaMahasiswa,
                             IdMataKuliah = mk.IdMataKuliah,
                             MataKuliah = mk.MataKuliah,
                             IdNilai = n.IdNilai,
                             Nilai = n.Nilai
                         }
                         ).OrderBy(y => y.IdMataKuliah).OrderBy(x => x.IdMahasiswa).ToList();
            
            if (!string.IsNullOrWhiteSpace(F_NamaMahasiswa))
            {
                _temp = _temp.Where(x => x.NamaMahasiswa.Contains(F_NamaMahasiswa)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(F_MataKuliah))
            {
                _temp = _temp.Where(x => x.IdMataKuliah == Convert.ToInt32(F_MataKuliah)).ToList();
            }

            NilaiModels model = new NilaiModels
            {
                MataKuliahList = listMataKuliah,
                tempNIlaiVMs = _temp
            };
            return View(model);
        }

        // GET: NilaiVM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NilaiVM nilaiVM = db.NilaiVMs.Find(id);
            if (nilaiVM == null)
            {
                return HttpNotFound();
            }

            var _temp = (from n in db.NilaiVMs
                         join m in db.MahasiswaVMs on n.IdMahasiswa equals m.IdMahasiswa
                         join mk in db.MataKuliahVMs on n.IdMataKuliah equals mk.IdMataKuliah
                         select new tempNIlaiVM()
                         {
                             IdMahasiswa = m.IdMahasiswa,
                             NamaMahasiswa = m.NamaMahasiswa,
                             IdMataKuliah = mk.IdMataKuliah,
                             MataKuliah = mk.MataKuliah,
                             IdNilai = n.IdNilai,
                             Nilai = n.Nilai
                         }
                         ).Where(x => x.IdNilai == id).SingleOrDefault();
            NilaiModels model = new NilaiModels
            {
                NamaMataKuliah = _temp.MataKuliah,
                F_NamaMahasiswa = _temp.NamaMahasiswa,
                i_Nilai = _temp.Nilai
            };
            return View(model);
        }

        // GET: NilaiVM/Create
        public ActionResult Create()
        {
            var dataMataKuliah = db.MataKuliahVMs.ToList();
            var listMataKuliah = new List<SelectListItem>();
            foreach (var i in dataMataKuliah)
            {
                listMataKuliah.Add(new SelectListItem() { Text = i.MataKuliah, Value = i.IdMataKuliah.ToString() });
            }

            var dataNamaMahasiswa = db.MahasiswaVMs.ToList();
            var listNamaMahasiswa = new List<SelectListItem>();
            foreach (var i in dataNamaMahasiswa)
            {
                listNamaMahasiswa.Add(new SelectListItem() { Text = i.NamaMahasiswa, Value = i.IdMahasiswa.ToString() });
            }

            NilaiModels model = new NilaiModels
            {
                MataKuliahList = listMataKuliah,
                NamaMahasiswaList = listNamaMahasiswa
            };
            return View(model);
        }

        // POST: NilaiVM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(NilaiModels models)
        {
            if (ModelState.IsValid)
            {
                var modelsSave = new NilaiVM
                {
                    IdMahasiswa = Convert.ToInt32(models.F_NamaMahasiswa),
                    IdMataKuliah = (int)models.F_MataKuliah,
                    Nilai = (int)models.i_Nilai
                };
                db.NilaiVMs.Add(modelsSave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(models);
        }

        // GET: NilaiVM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NilaiVM nilaiVM = db.NilaiVMs.Find(id);
            if (nilaiVM == null)
            {
                return HttpNotFound();
            }

            var dataMataKuliah = db.MataKuliahVMs.ToList();
            var listMataKuliah = new List<SelectListItem>();
            foreach (var i in dataMataKuliah)
            {
                listMataKuliah.Add(new SelectListItem() { Text = i.MataKuliah, Value = i.IdMataKuliah.ToString() });
            }

            var dataNamaMahasiswa = db.MahasiswaVMs.ToList();
            var listNamaMahasiswa = new List<SelectListItem>();
            foreach (var i in dataNamaMahasiswa)
            {
                listNamaMahasiswa.Add(new SelectListItem() { Text = i.NamaMahasiswa, Value = i.IdMahasiswa.ToString() });
            }

            var _temp = (from n in db.NilaiVMs
                         join m in db.MahasiswaVMs on n.IdMahasiswa equals m.IdMahasiswa
                         join mk in db.MataKuliahVMs on n.IdMataKuliah equals mk.IdMataKuliah
                         select new tempNIlaiVM()
                         {
                             IdMahasiswa = m.IdMahasiswa,
                             NamaMahasiswa = m.NamaMahasiswa,
                             IdMataKuliah = mk.IdMataKuliah,
                             MataKuliah = mk.MataKuliah,
                             IdNilai = n.IdNilai,
                             Nilai = n.Nilai
                         }
                         ).Where(x => x.IdNilai == id).SingleOrDefault();
            NilaiModels model = new NilaiModels
            {
                MataKuliahList = listMataKuliah,
                NamaMahasiswaList = listNamaMahasiswa,
                NamaMataKuliah = _temp.MataKuliah,
                F_MataKuliah = _temp.IdMataKuliah,
                F_NamaMahasiswa = _temp.IdMahasiswa.ToString(),
                i_Nilai = _temp.Nilai,
                id_Nilai = _temp.IdNilai
            };
            return View(model);
        }

        // POST: NilaiVM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NilaiModels models)
        {
            if (ModelState.IsValid)
            {
                NilaiVM nilaiVM = db.NilaiVMs.Find(models.id_Nilai);
                nilaiVM.IdMahasiswa = Convert.ToInt32(models.F_NamaMahasiswa);
                nilaiVM.IdMataKuliah = (int)models.F_MataKuliah;
                nilaiVM.Nilai = (int)models.i_Nilai;
                db.Entry(nilaiVM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(models);
        }

        // GET: NilaiVM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NilaiVM nilaiVM = db.NilaiVMs.Find(id);
            if (nilaiVM == null)
            {
                return HttpNotFound();
            }

            var _temp = (from n in db.NilaiVMs
                         join m in db.MahasiswaVMs on n.IdMahasiswa equals m.IdMahasiswa
                         join mk in db.MataKuliahVMs on n.IdMataKuliah equals mk.IdMataKuliah
                         select new tempNIlaiVM()
                         {
                             IdMahasiswa = m.IdMahasiswa,
                             NamaMahasiswa = m.NamaMahasiswa,
                             IdMataKuliah = mk.IdMataKuliah,
                             MataKuliah = mk.MataKuliah,
                             IdNilai = n.IdNilai,
                             Nilai = n.Nilai
                         }
                        ).Where(x => x.IdNilai == id).SingleOrDefault();
            NilaiModels model = new NilaiModels
            {
                NamaMataKuliah = _temp.MataKuliah,
                F_NamaMahasiswa = _temp.NamaMahasiswa,
                i_Nilai = _temp.Nilai,
                id_Nilai = _temp.IdNilai
                
            };
            return View(model);
        }

        // POST: NilaiVM/Delete/5
        public ActionResult DeleteConfirmed(NilaiModels models)
        {
            NilaiVM nilaiVM = db.NilaiVMs.Find(models.id_Nilai);
            db.NilaiVMs.Remove(nilaiVM);
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
