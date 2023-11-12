using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Registro_Herramientas.Models
{
    public class Registro
    {
        
        public int Id_registro { get; set; }

        [Required(ErrorMessage = "Cédula es obligatorio")]
        [Range(100000000, 999999999, ErrorMessage = "Digitar Cédula Válida")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "ID Herramienta es obligatorio")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "ID debe tener entre 3 y 6 caracteres")]
        public string Id_herramienta { get; set; }

        [Required(ErrorMessage = "Nombre Herramienta es obligatorio")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Nombre debe tener entre 3 y 6 caracteres")]
        public string Nombre_herramienta { get; set; }


        public bool Devuelta { get; set; }

        [Required(ErrorMessage = "Fecha Requerida")]
        public string Fecha_prestamo { get; set; }

        [Required(ErrorMessage = "Fecha Requerida")]
        public string Fecha_devuelve { get; set; }

        
        public string Fecha_devolucion { get; set; }               

    }
}