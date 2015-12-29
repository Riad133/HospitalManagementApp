using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class ProjectDBContext: DbContext
    {
        public ProjectDBContext():base("HospitalManagementDBstring")
        {
            
        }
        public DbSet<Doctor> Doctor { set; get; }
        public DbSet<Bed> Bed { set; get; }
        public DbSet<DoctorDepartment> DoctorDepartment { set; get; }
        public DbSet<DoctorSpecialization> DoctorSpecialization { set; get; }
        public DbSet<Nurse> Nurse { set; get; }
        public DbSet<IndoorPatient> IndoorPatient { set; get; }
        public DbSet<OutdoorPatient> OutdoorPatient { get; set; }
        public DbSet<Medicine> Medicine { get; set; }

    }
}