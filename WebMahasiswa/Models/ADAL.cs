using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebMahasiswa.Models
{
    public class ADAL : DbContext
    {
        public ADAL() : base("ADAL")
        {
        }

        public DbSet<MahasiswaVM> MahasiswaVMs { get; set; }
        public DbSet<NilaiVM> NilaiVMs { get; set; }
        public DbSet<MataKuliahVM> MataKuliahVMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}