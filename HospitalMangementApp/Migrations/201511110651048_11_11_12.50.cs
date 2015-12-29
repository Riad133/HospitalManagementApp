namespace HospitalMangementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11_11_1250 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beds",
                c => new
                    {
                        BedId = c.Int(nullable: false, identity: true),
                        BedNo = c.String(nullable: false),
                        BedType = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BedId);
            
            CreateTable(
                "dbo.IndoorPatients",
                c => new
                    {
                        IndoorPatientId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        BedId = c.Int(nullable: false),
                        Admissiondate = c.DateTime(),
                        Releasedate = c.DateTime(),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IndoorPatientId)
                .ForeignKey("dbo.Beds", t => t.BedId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.BedId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 32),
                        DoctorDepartmentId = c.Int(nullable: false),
                        Degree = c.String(nullable: false),
                        DoctorSpecializationId = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.DoctorDepartments", t => t.DoctorDepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.DoctorSpecializations", t => t.DoctorSpecializationId, cascadeDelete: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.DoctorDepartmentId)
                .Index(t => t.DoctorSpecializationId);
            
            CreateTable(
                "dbo.DoctorDepartments",
                c => new
                    {
                        DoctorDepartmentId = c.Int(nullable: false, identity: true),
                        DoctorDepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorDepartmentId);
            
            CreateTable(
                "dbo.DoctorSpecializations",
                c => new
                    {
                        DoctorSpecializationId = c.Int(nullable: false, identity: true),
                        Specialization = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorSpecializationId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        MedicineName = c.String(),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.Nurses",
                c => new
                    {
                        NurseId = c.Int(nullable: false, identity: true),
                        NationalID = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NurseId);
            
            CreateTable(
                "dbo.OutdoorPatients",
                c => new
                    {
                        OutdoorPatientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        DoctorId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OutdoorPatientId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OutdoorPatients", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.IndoorPatients", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "DoctorSpecializationId", "dbo.DoctorSpecializations");
            DropForeignKey("dbo.Doctors", "DoctorDepartmentId", "dbo.DoctorDepartments");
            DropForeignKey("dbo.IndoorPatients", "BedId", "dbo.Beds");
            DropIndex("dbo.OutdoorPatients", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "DoctorSpecializationId" });
            DropIndex("dbo.Doctors", new[] { "DoctorDepartmentId" });
            DropIndex("dbo.Doctors", new[] { "Email" });
            DropIndex("dbo.IndoorPatients", new[] { "DoctorId" });
            DropIndex("dbo.IndoorPatients", new[] { "BedId" });
            DropTable("dbo.OutdoorPatients");
            DropTable("dbo.Nurses");
            DropTable("dbo.Medicines");
            DropTable("dbo.DoctorSpecializations");
            DropTable("dbo.DoctorDepartments");
            DropTable("dbo.Doctors");
            DropTable("dbo.IndoorPatients");
            DropTable("dbo.Beds");
        }
    }
}
