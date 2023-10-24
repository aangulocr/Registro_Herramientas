using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registro_Herramientas.Models
{
    public class Registro
    {
        public int Id_registro { get; set; }
        public int Cedula { get; set; }
        public bool Devuelta { get; set; }
        public string Fecha_prestamo { get; set; }
        public string Fecha_devuelve { get; set; }
        public string Fecha_devolucion { get; set; }
    }
}