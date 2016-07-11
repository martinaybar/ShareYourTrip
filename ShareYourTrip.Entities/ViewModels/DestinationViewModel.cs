using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.ViewModels
{
    public class DestinationViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Requerido")]
        [Display(Name = "Fecha desde")]
        [DataType(DataType.DateTime, ErrorMessage = "Ingrese una fecha valida")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [Display(Name = "Fecha hasta")]
        [DataType(DataType.DateTime,ErrorMessage = "Ingrese una fecha valida")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [Display(Name = "Ciudad")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} debe ser un numero")]
        [Display(Name = "Posponer o adelantar (dias)")]
        public int DeltaDays { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FromDate > ToDate)
            {
                yield return new ValidationResult("Fecha desde debe ser menor a la fecha hasta");
            }
        }
    }
}
