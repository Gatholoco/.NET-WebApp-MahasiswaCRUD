using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMahasiswa.Models
{
    public class NilaiModels
    {
        public string F_NamaMahasiswa { get; set; }
        public int? F_MataKuliah { get; set; }
        public string NamaMataKuliah { get; set; }
        public int? i_Nilai { get; set; }
        public int id_Nilai { get; set; }
        public IEnumerable<SelectListItem> MataKuliahList { get; set; }
        public IEnumerable<SelectListItem> NamaMahasiswaList { get; set; }
        public IEnumerable<tempNIlaiVM> tempNIlaiVMs { get; set; }
    }

    public class tempNIlaiVM
    {
        public int IdNilai { get; set; }
        public int IdMahasiswa { get; set; }
        public string NamaMahasiswa { get; set; }
        public int IdMataKuliah { get; set; }
        public string MataKuliah { get; set; }
        public int Nilai { get; set; }
    }
}