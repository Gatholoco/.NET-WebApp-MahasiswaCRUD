using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMahasiswa.Models
{
    public class MahasiswaVM
    {
        [Key]
        public int IdMahasiswa { get; set; }
        public string NamaMahasiswa { get; set; }
    }
}