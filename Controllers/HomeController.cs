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

        private static List<Empleado> _objEmpleado = new List<Empleado>();
        private static List<Herramienta> _objHerramienta = new List<Herramienta>();
        private static List<Registro> _objRegistro = new List<Registro>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Empleados()
        {
            _objEmpleado = new List<Empleado>();

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
                        nuevoEmpleado.Nombre = reader["Nombre"].ToString().ToUpper();
                        nuevoEmpleado.Apellido = reader["Apellido"].ToString().ToUpper();
                        //nuevoEmpleado.fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]);
                        nuevoEmpleado.Fecha_ingreso = reader["Fecha_ingreso"].ToString();
                        nuevoEmpleado.Activo = Convert.ToBoolean(reader["Activo"]);

                        _objEmpleado.Add(nuevoEmpleado);
                    }
                }
            }
            return View(_objEmpleado);
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
                cmd.Parameters.AddWithValue("Id_herramienta", objHerramienta.Id_herramienta.ToUpper());
                cmd.Parameters.AddWithValue("Nombre_herramienta", objHerramienta.Nombre_herramienta.ToUpper());
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
                cmd.Parameters.AddWithValue("nombre", objEmpleado.Nombre.ToUpper());
                cmd.Parameters.AddWithValue("apellido", objEmpleado.Apellido.ToUpper());
                cmd.Parameters.AddWithValue("fecha_ingreso", objEmpleado.Fecha_ingreso);

                var bActivo = objEmpleado.Activo.ToString();
                cmd.Parameters.AddWithValue("activo", objEmpleado.Activo);
                cmd.CommandType = CommandType.StoredProcedure;
                objCon.Open();

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("AgregarEmpleado", "Home");
        }

        [HttpGet]
        public ActionResult BuscarRegistroCedula() { return View(); }

        [HttpPost]
        public ActionResult BuscarRegistroCedula(string Cedula) 
        {
            using (SqlConnection objCon = new SqlConnection(conexion))
            {
                //****** Procedimiento Almacenado de BdInventario ******

                //****** Validar que la Cedula Exista dentro de los Empleados ******
                SqlCommand cmd = new SqlCommand("sp_CuentaEmpleadoByCedula", objCon);
                cmd.Parameters.AddWithValue("Cedula", Cedula);
                cmd.CommandType = CommandType.StoredProcedure;
                objCon.Open();

                var cuentaCedula = cmd.ExecuteScalar();
                if (cuentaCedula.Equals(1))
                {//Agregando funcion de store procedure
                    _objRegistro = new List<Registro>();

                    SqlCommand cmd2 = new SqlCommand("sp_SelectRegistroByCedula", objCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("cedula", Cedula);
                    //cmd2.Parameters.Add(new SqlParameter("@Cedula", objRegistro.Cedula));                   

                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Registro nuevoRegistro = new Registro();

                            nuevoRegistro.Id_registro = Convert.ToInt32(reader["Id_movimiento"]);                                                        
                            nuevoRegistro.Id_herramienta = reader["Id_herramienta"].ToString().ToUpper();
                            nuevoRegistro.Nombre_herramienta = reader["Nombre_herramienta"].ToString().ToUpper();
                            nuevoRegistro.Devuelta = Convert.ToBoolean(reader["Devuelta"]);
                            nuevoRegistro.Fecha_prestamo = reader["Fecha_prestamo"].ToString();
                            nuevoRegistro.Fecha_devuelve = reader["Fecha_devuelve"].ToString();
                            nuevoRegistro.Fecha_devolucion = reader["Fecha_devolucion"].ToString();

                            _objRegistro.Add(nuevoRegistro);
                        }
                    }
                    ViewBag.Registro = _objRegistro.ToList();

                    return View();
                }//Agregado de storeprocedure
                else { ViewBag.Mensaje = "CÉDULA NO EXISTE, COLABORADOR NO EXISTE O ERROR DE NÚMERO DE CÉDULA"; }
            }
            AgregarRegistro(_objRegistro);
            return View(); 
        }

        [HttpGet]
        public ActionResult AgregarRegistro() {            
            
            
            return View();
        }
        

        //********** OJO CORREGIR DE AQUÍ - CREAR OTRO PAGINA DONDE SE RECORRA LA LISTA DE PRESTAMOS*******
        [HttpPost]  
        public ActionResult AgregarRegistro(List<Registro> _objRegistro)
        {
            //Aqui es donde se tiene que conectar a la base de datos                       

            

            //using (SqlConnection objCon = new SqlConnection(conexion))
            //{
            //    //****** Procedimiento Almacenado de BdInventario ******

            //    //****** Validar que la Cedula Exista dentro de los Empleados ******
            //    SqlCommand cmd = new SqlCommand("sp_CuentaEmpleadoByCedula", objCon);
            //    cmd.Parameters.AddWithValue("Cedula", Cedula);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    objCon.Open();

            //    var cuentaCedula = cmd.ExecuteScalar();
            //    if (cuentaCedula.Equals(1))
            //    {//Agregando funcion de store procedure
            //        _objRegistro = new List<Registro>();

            //        SqlCommand cmd2 = new SqlCommand("sp_SelectRegistroByCedula", objCon);
            //        cmd2.CommandType = CommandType.StoredProcedure;
            //        cmd2.Parameters.AddWithValue("cedula", cedula);
            //        //cmd2.Parameters.Add(new SqlParameter("@Cedula", objRegistro.Cedula));

                    
            //        //objCon.Open();
                   

            //        using (SqlDataReader reader = cmd2.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                Registro nuevoRegistro = new Registro();

            //                nuevoRegistro.Cedula = Convert.ToInt32(reader["Cedula"]);
            //                nuevoRegistro.Id_herramienta = reader["Id_herramienta"].ToString().ToUpper();
            //                nuevoRegistro.Devuelta = Convert.ToBoolean(reader["Devuelta"]);
            //                nuevoRegistro.Fecha_prestamo = reader["Fecha_prestamo"].ToString();
            //                nuevoRegistro.Fecha_devuelve = reader["Fecha_devuelve"].ToString();
            //                nuevoRegistro.Fecha_devolucion = reader["Fecha_devolucion"].ToString();


            //                _objRegistro.Add(nuevoRegistro);
            //            }
            //        }
            //        ViewBag.Registro = _objRegistro;

            //        return View();
            //    }//Agregado de storeprocedure
            //    else { ViewBag.Mensaje = "CÉDULA NO EXISTE, COLABORADOR NO EXISTE O ERROR DE NÚMERO DE CÉDULA"; }                               
            //}

            //return RedirectToAction("AgregarRegistro", "Home");
            return View();
        }
       
    }
}