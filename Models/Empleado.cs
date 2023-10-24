using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registro_Herramientas.Models
{
    public class Empleado
    {
        public int Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        //public DateTime fecha_ingreso { get; set; }
        public string Fecha_ingreso { get; set; }

        public bool Activo { get; set; }
    }
}