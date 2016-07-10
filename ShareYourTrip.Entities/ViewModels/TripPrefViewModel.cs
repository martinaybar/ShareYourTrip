using ShareYourTrip.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.ViewModels
{
    public class TripPrefViewModel
    {
        [Display(Name = "Nombre del viaje")]
        [Required]
        public string TripName { get; set; }
        public List<TripService> Services { get; set; }
        public List<TripType> TripTypes { get; set; }

        [Required]
        public List<CustomCheckBox> Serv { get; set; }

        public List<CustomCheckBox> Types { get; set; }

    }
    
    public class CustomCheckBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
