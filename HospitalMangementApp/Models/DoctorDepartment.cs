using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class DoctorDepartment
    {
        [Key]
        [Display (Name = "Doctor's Department")]
        public int DoctorDepartmentId { get; set; }
        [Required]
        [Display (Name = "Department Name")]
        public string DoctorDepartmentName { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }


    }
}