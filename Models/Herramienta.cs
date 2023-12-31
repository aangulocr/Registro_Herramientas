﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Registro_Herramientas.Models
{
    public class Herramienta
    {
        [Required(ErrorMessage = "ID Herramienta es obligatorio")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "ID debe tener entre 3 y 6 caracteres")]
        [Key]
        public string Id_herramienta { get; set; }

        [Required(ErrorMessage = "Nombre Herramienta es obligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nombre debe tener entre 3 y 20 caracteres")]
        public string Nombre_herramienta { get; set; }

        [Required(ErrorMessage = "La Descripción es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre debe tener entre 3 y 50 caracteres")]
        public string Descripcion { get; set; }


        public bool Prestada { get; set; }
    }
}