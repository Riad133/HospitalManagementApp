using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class IndoorPatient
    {
        [Key]
        public int IndoorPatientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }

        [Required]
        public string Gender { get; set; }
        [Display(Name = "Bed No")]
        [ForeignKey("Bed")]
        public int BedId { get; set; }

        [Display(Name = "Admission Date ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Admissiondate { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Releasedate { get; set; } 

        [Display(Name = "Doctor's Name")]

        public int  DoctorId { get; set; }


        public virtual Doctor Doctor { get; set; }
        public virtual Bed Bed { get; set; }






    }
}