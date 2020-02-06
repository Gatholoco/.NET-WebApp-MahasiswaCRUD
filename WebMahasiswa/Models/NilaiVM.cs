using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMahasiswa.Models
{
    public class NilaiVM
    {
        [Key]
        public int IdNilai { get; set; }
        public int IdMahasiswa { get; set; }
        public int IdMataKuliah { get; set; }
        public int Nilai { get; set; }
    }
}