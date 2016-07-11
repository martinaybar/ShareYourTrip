using System;
using System.ComponentModel.DataAnnotations;

namespace ShareYourTrip.Entities.DataModels
{
    public class Destination
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        public virtual City City { get; set; }

        [Display(Name = "Fecha desde")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FromDate { get; set; }

        [Display(Name = "Fecha hasta")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ToDate { get; set; }

        [Display(Name = "Posponer o adelantar")]
        public int DeltaDays { get; set; }

        public virtual Trip Trip { get; set; }


            
    }
}
