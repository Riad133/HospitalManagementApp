using HospitalMangementApp.Models;

namespace HospitalMangementApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HospitalMangementApp.Models.ProjectDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HospitalMangementApp.Models.ProjectDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            
            context.DoctorDepartment.AddOrUpdate(
                p=>p.DoctorDepartmentName,
                new DoctorDepartment { DoctorDepartmentName = "Cardiology"},
                new DoctorDepartment { DoctorDepartmentName = "Medicine" }
                );
            context.DoctorSpecialization.AddOrUpdate(
                p=>p.Specialization,
                new DoctorSpecialization { Specialization = "Professor" },

                new DoctorSpecialization { Specialization = "Ass. Professor" },
                new DoctorSpecialization { Specialization = "Register" }



                );
            context.Medicine.AddOrUpdate(
                p=>p.MedicineName,
                new Medicine { MedicineName = "Napa (500mg)"},
                new Medicine { MedicineName = "Ace (500mg)"},
                new Medicine { MedicineName = "Napadol(500mg)"}
                
                );

            context.Bed.AddOrUpdate(
                p=>p.BedNo,

                new Bed { BedNo = "205",BedType = "AC",Price = 3500},
                new Bed { BedNo = "206", BedType = "Non-AC", Price = 1500 },
                new Bed { BedNo = "306", BedType = "AC", Price = 3500 },
                new Bed { BedNo = "405", BedType = "Non-AC", Price = 1500 }





                );
        }
    }
}
