using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.ViewModels
{
    public class DestinationViewModel
    {
        [Display(Name = "Fecha desde")]
        public DateTime FromDate { get; set; }
        [Display(Name = "Fecha hasta")]
        public DateTime ToDate { get; set; }
        [Display(Name = "Ciudad")]
        public int CityId { get; set; }

    }
}
