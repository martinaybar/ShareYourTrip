using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.DataModels
{
    public class Destination
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        public virtual City City { get; set; }
        [Display(Name = "Fecha desde")]
        public DateTime FromDate { get; set; }
        [Display(Name = "Fecha hasta")]
        public DateTime ToDate { get; set; }
        [Display(Name = "Posponer o adelantar")]
        public int DeltaDays { get; set; }

        public virtual Trip Trip { get; set; }
            
    }
}
