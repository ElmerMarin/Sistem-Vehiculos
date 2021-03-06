using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Vehiculos_API.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Marca")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
