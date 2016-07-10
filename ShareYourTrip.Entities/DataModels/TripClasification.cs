using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.DataModels
{
    public class TripClasification
    {
        [Key]
        public int Id { get; set; }

        //User Info
        public virtual ApplicationUser User { get; set; }
        public virtual City CityFrom { get; set; }
        public string  UserPreferences { get; set; }
        public int Genre { get; set; }
        public int UserAgeRange { get; set; }
        

        //Trip Info
        public virtual Trip Trip { get; set; }
        public virtual Continent ContinentTo { get; set; }
        public int TripYearQuarter { get; set; }
        public string Destinations { get; set; }
        public string TripServicesToShare { get; set; }
        public string TripTypes { get; set; }
    }


    /// <summary>
    /// Enum con la agrupacion de edades de los usuarios
    /// </summary>
    public enum UserAgeRangeEnum
    {
        Age15To21 = 1,
        Age22To35,
        Age36To55,
        Age56To
    }

    /// <summary>
    /// Enum con los trimestres del anio
    /// </summary>
    public enum TripYearQuarterEnum
    {
        Q1 = 1,
        Q2,
        Q3,
        Q4
    }
}
