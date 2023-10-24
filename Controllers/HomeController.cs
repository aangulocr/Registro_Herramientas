using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registro_Herramientas.Models;

namespace BodegaHerramientas.Controllers
{
    public class HomeController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Empleado> objEmpleado = new List<Empleado>();
        private static List<Herramienta> objHerramienta = new List<Herramienta>();
        private static List<Registro> objRegistro = new List<Registro>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Empleados()
        {
            objEmpleado = new List<Empleado>();

            using (SqlConnection objCon = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Empleados", objCon);
                cmd.CommandType = CommandType.Text;
                objCon.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Empleado nuevoEmpleado = new Empleado();

                        nuevoEmpleado.Cedula = Convert.ToInt32(reader["Cedula"]);
                        nuevoEmpleado.Nombre = reader["Nombre"].ToString();
                        nuevoEmpleado.Apellido = reader["Apellido"].ToString();
                        //nuevoEmpleado.fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]);
                        nuevoEmpleado.Fecha_ingreso = reader["Fecha_ingreso"].ToString();
                        nuevoEmpleado.Activo = Convert.ToBoolean(reader["Activo"]);

                        objEmpleado.Add(nuevoEmpleado);
                    }
                }
            }
            return View(objEmpleado);
        }

        [HttpGet]
        public ActionResult AgregarHerramienta()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult AgregarHerramienta(Herramienta objHerramienta)
        {
            using (SqlConnection objCon = new SqlConnection(conexion))
            {
                //****** Procedimiento Almacenado de BdInventario ******
                SqlCommand cmd = new SqlCommand("sp_InsertarHerramienta", objCon);
                cmd.Parameters.AddWithValue("Id_herramienta", objHerramienta.Id_herramienta);
                cmd.Parameters.AddWithValue("Nombre_herramienta", objHerramienta.Nombre_herramienta);
                cmd.Parameters.AddWithValue("Descripcion", objHerramienta.Descripcion);
                             
                cmd.CommandType = CommandType.StoredProcedure;
                objCon.Open();

                cmd.ExecuteNonQuery();
            }
            
            return RedirectToAction("AgregarHerramienta", "Home");
        }


        [HttpGet]
        public ActionResult AgregarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarEmpleado(Empleado objEmpleado)
        {
            using (SqlConnection objCon = new SqlConnection(conexion))
            {
                //****** Procedimiento Almacenado de BdInventario ******
                SqlCommand cmd = new SqlCommand("sp_InsertarEmpleado", objCon);
                cmd.Parameters.AddWithValue("cedula", objEmpleado.Cedula);
                cmd.Parameters.AddWithValue("nombre", objEmpleado.Nombre);
                cmd.Parameters.AddWithValue("apellido", objEmpleado.Apellido);
                cmd.Parameters.AddWithValue("fecha_ingreso", objEmpleado.Fecha_ingreso);

                var bActivo = objEmpleado.Activo.ToString();
                cmd.Parameters.AddWithValue("activo", objEmpleado.Activo);
                cmd.CommandType = CommandType.StoredProcedure;
                objCon.Open();

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("AgregarEmpleado", "Home");
        }
    }
}