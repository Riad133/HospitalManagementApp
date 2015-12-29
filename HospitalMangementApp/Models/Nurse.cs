using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class Nurse
    {
        [Key]
        public int NurseId { get; set; }
        [Required]
        //validation req
        [Display(Name = "National ID Number ")]
        public string NationalID { get; set; }
        [Required]
        [Display (Name = "Nurse Name")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Contact { get; set; }

    }
}