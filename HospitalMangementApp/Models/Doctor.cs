using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalMangementApp.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Doctor's Name")]

        public string Name { get; set; }
        [Required(ErrorMessage = "You Must Fill Email Field")]
        [Index(IsUnique = true)]
        [MaxLength(32)]
        //     [Remote("DoesEmailExist", "Doctor", HttpMethod = "POST", ErrorMessage = "Email address exist")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public string Email { get; set; }


        [ForeignKey("DoctorDepartment")]

        [Display(Name = "Doctor's Department")]
        public int DoctorDepartmentId { get; set; }

        [Required]
        public string Degree { get; set; }

        [ForeignKey("DoctorSpecialization")]
        [Display(Name = "Doctor's Specialization")]

        public int DoctorSpecializationId { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$", ErrorMessage = "Entered phone format is not valid.")]
        public string  Phone { get; set; }

        public virtual DoctorDepartment DoctorDepartment { set; get; }

        public virtual DoctorSpecialization DoctorSpecialization { get; set; }
        
    }
}