using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class DoctorsContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Analysis> Analyses { get; set; }
        public DbSet<AvaliableVisitTime> AvaliableVisitTimes { get; set; }

        public DoctorsContext(DbContextOptions<DoctorsContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-6GV0RFG;Database=doctorsdb;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Patient>().ToTable("Patients");

            modelBuilder.Entity<AvaliableVisitTime>()
            .HasOne(d => d.Doctor)
            .WithMany(i => i.AvaliableVisitTimes);

            modelBuilder.Entity<Visit>()
            .HasOne(d => d.Doctor)
            .WithMany(i => i.Visits);
        }
    }
}
