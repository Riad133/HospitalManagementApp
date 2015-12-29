using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class Bed
    {
        [Key]
        public int BedId { get; set; }
        [Required]
        [Display(Name = "Bed No")]
        public string BedNo { get; set; }

        [Display (Name = "Bed Type")]

        public string BedType { get; set; }

        [Required]
      
        [Range(0,10000,ErrorMessage = "Limit must be 0-10000")]
        [Display(Name = "Price per bed")]
        public decimal Price { get; set; }

        public virtual ICollection<IndoorPatient> IndoorPatient { get; set; }

    }
}