using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        [Display(Name = "Medicine Name")]
        public string MedicineName { get; set; }


    }
}