using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.DataModels
{
    public class Destination
    {
        public int Id { get; set; }
        public virtual City City { get; set; }
        
        //TODO Evaluar si a la fecha desde y hasta la hacemos una clase nueva con algunos metodos
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual Trip Trip { get; set; }
            
    }
}
