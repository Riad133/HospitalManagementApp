using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class OutdoorPatient
    {
        [Key]
        public int OutdoorPatientId { get; set; }
        [Display(Name = "Patient Name")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Doctor's Name")]
        [ForeignKey("Doctor")]

        public int DoctorId { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime DateTime { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}