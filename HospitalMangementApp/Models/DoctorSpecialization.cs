using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class DoctorSpecialization
    {
        [Key]
        public int DoctorSpecializationId { get; set; }
        [Required]
        public string Specialization { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }


        // public virtual Doctor Doctor { get; set; }
    }
}