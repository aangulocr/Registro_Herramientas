using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Registro_Herramientas.Models
{
    public class Empleado
    {
        [Required(ErrorMessage ="Cédula es obligatorio")]
        [Range(100000000, 999999999,ErrorMessage ="Digitar Cédula Válida")]
        public int Cedula { get; set; }
        
        [Required(ErrorMessage ="El Nombre es Requerido")]
        [StringLength(15,MinimumLength = 3, ErrorMessage ="Nombre debe ser entre 3 a 15 Caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es Requerido")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Apellido debe ser entre 3 a 30 Caracteres")]
        public string Apellido { get; set; }

        //public DateTime fecha_ingreso { get; set; }
        [Required(ErrorMessage ="Fecha Requerida")]
        public string Fecha_ingreso { get; set; }

        public bool Activo { get; set; }
    }
}