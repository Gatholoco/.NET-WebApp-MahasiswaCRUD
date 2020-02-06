using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMahasiswa.Models
{
    public class MataKuliahVM
    {
        [Key]
        public int IdMataKuliah { get; set; }
        public string MataKuliah { get; set; }
    }
}