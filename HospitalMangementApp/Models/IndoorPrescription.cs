using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class IndoorPrescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        public IndoorPatient NAME { get; set; }
    }
}