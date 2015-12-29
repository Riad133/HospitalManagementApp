using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMangementApp.Models
{
    public class IndoorTreatment
    {
        public int IndoorTreatmentId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("IndoorPatient")]
        public int IndoorPatientId { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        [Display(Name = "Disease Description")]
        public string DiseaseDescription { get; set; }
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public string Dose { get; set; }
        public string MealTime { get; set; }   
        public string Note { get; set; }
        
         public  virtual Medicine Medicine { get; set; }

    }
}