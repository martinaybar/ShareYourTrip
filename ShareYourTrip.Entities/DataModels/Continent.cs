using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.DataModels
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum ContinentEnum
    {
        America = 1,
        Europa,
        Asia,
        Africa,
        Oceania,
        Antartida
    }
}
