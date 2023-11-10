using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registro_Herramientas.Models;
using Microsoft.Ajax.Utilities;
using System.Web.UI;

namespace BodegaHerramientas.Controllers
{
    public class HomeController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Empleado> _objEmpleado = new List<Empleado>();
        private static List<Herramienta> _objHerramienta = new List<Herramienta>();
        private static List<Registro> _objRegistro = new List<Registro>();
        private static int iCedula;        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Empleados()
        {
            _objEmpleado = new List<Empleado>();

            try
            {            
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
                            DateTime mDate = new DateTime();

                            nuevoEmpleado.Cedula = Convert.ToInt32(reader["Cedula"]);
                            nuevoEmpleado.Nombre = reader["Nombre"].ToString().ToUpper();
                            nuevoEmpleado.Apellido = reader["Apellido"].ToString().ToUpper();
                            //nuevoEmpleado.fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]);
                            mDate = (DateTime)reader["Fecha_ingreso"];
                            nuevoEmpleado.Fecha_ingreso = mDate.ToString("dd/MM/yyyy");
                            nuevoEmpleado.Activo = Convert.ToBoolean(reader["Activo"]);

                            _objEmpleado.Add(nuevoEmpleado);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
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
            if(objHerramienta.Id_herramienta == null || objHerramienta.Nombre_herramienta == null)
                return RedirectToAction("AgregarHerramienta", "Home");
            try { 
                using (SqlConnection objCon = new SqlConnection(conexion))
                {
                    //****** Procedimiento Almacenado de BdInventario ******
                    SqlCommand cmd = new SqlCommand("sp_InsertarHerramienta", objCon);
                    cmd.Parameters.AddWithValue("Id_herramienta", objHerramienta.Id_herramienta.ToUpper());
                    cmd.Parameters.AddWithValue("Nombre_herramienta", objHerramienta.Nombre_herramienta.ToUpper());
                    cmd.Parameters.AddWithValue("Descripcion", objHerramienta.Descripcion);
                    cmd.Parameters.AddWithValue("Prestada", false);

                    cmd.CommandType = CommandType.StoredProcedure;
                    objCon.Open();

                    cmd.ExecuteNonQuery();
                    alert("Herramienta Agregada Correctamente");
                    //return RedirectToAction("AgregarHerramienta", "Home");
                    ViewBag.Msg = "Herramienta Agregada Correctamente";
                    return View();
                }                            
            }
            catch (SqlException ex) {
                ViewBag.Error = ex.Message;
            }
            //return RedirectToAction("AgregarHerramienta", "Home");
            return View();
        }


        [HttpGet]
        public ActionResult AgregarEmpleado()
        {
            ViewBag.AlertError = "false";
            return View();
        }

        [HttpPost]
        public ActionResult AgregarEmpleado(Empleado objEmpleado)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AlertError = "true";
                ViewBag.Msg = "Datos Incompletos";
                return View();
            }
            if (objEmpleado.Cedula == 0 || objEmpleado.Nombre == "")
                return View();
            try { 
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
                    ViewBag.Msg = "Empleado Guardado Correctamente";
                    //ViewData["Msg"] = "Empleado Guardado Correctamente ViewData";
                    alert("Empleado Guardado Correctamente");
                    //return RedirectToAction("AgregarEmpleado", "Home");
                }
            }
            catch (SqlException ex)
            {
                ViewBag.AlertError = "true";
                ViewBag.Msg = ex.Message;
                alert(ex.Message);
            }

            //return RedirectToAction("AgregarEmpleado", "Home");
            return View();
        }

        [HttpGet]
        public ActionResult BuscarRegistroCedula() 
        {

            return View(); 
        }

        [HttpPost]
        public ActionResult BuscarRegistroCedula(string Cedula, bool? Devolucion = false) 
        {
            if(Cedula == null || Cedula.Length < 9)
                return View();
            
            ViewBag.Devolucion = Devolucion;


            iCedula = Convert.ToInt32(Cedula);
            try { 
                using (SqlConnection objCon = new SqlConnection(conexion))
                {                                        
                    SqlCommand cmd = new SqlCommand("sp_CuentaEmpleadoByCedula", objCon);
                    cmd.Parameters.AddWithValue("Cedula", Cedula);
                    cmd.CommandType = CommandType.StoredProcedure;
                    objCon.Open();

                    var cuentaCedula = cmd.ExecuteScalar();
                    if (cuentaCedula.Equals(1))
                    {
                        _objRegistro = new List<Registro>();

                        SqlCommand cmd2 = new SqlCommand("sp_SelectRegistroByCedula", objCon);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("cedula", Cedula);                                           

                        using (SqlDataReader reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Registro nuevoRegistro = new Registro();
                                DateTime tmpDate = new DateTime();

                                nuevoRegistro.Id_registro = Convert.ToInt32(reader["Id_movimiento"]);
                                nuevoRegistro.Cedula = Convert.ToInt32( reader["Cedula"].ToString());
                                nuevoRegistro.Id_herramienta = reader["Id_herramienta"].ToString().ToUpper();
                                nuevoRegistro.Nombre_herramienta = reader["Nombre_herramienta"].ToString().ToUpper();
                                nuevoRegistro.Devuelta = Convert.ToBoolean(reader["Devuelta"]);
                                tmpDate = (DateTime)reader["Fecha_prestamo"];
                                nuevoRegistro.Fecha_prestamo = tmpDate.ToString("dd/MM/yyyy");
                                tmpDate = (DateTime)reader["Fecha_devuelve"];
                                nuevoRegistro.Fecha_devuelve = tmpDate.ToString("dd/MM/yyyy");

                                //nuevoRegistro.Fecha_devolucion = tmpDate.ToString("dd/MM/yyyy");
                                nuevoRegistro.Fecha_devolucion = "";                                                                

                                _objRegistro.Add(nuevoRegistro);

                            }
                        }
                        ViewBag.Registro = _objRegistro.ToList();

                        return View();
                    }
                    else { ViewBag.Mensaje = "CÉDULA NO EXISTE, COLABORADOR NO EXISTE O ERROR DE NÚMERO DE CÉDULA"; }
                }
                //AgregarRegistro(_objRegistro);
            }
            catch (SqlException ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(); 
        }

        [HttpGet]
        public ActionResult PrestarHerramienta() 
        {
            
            foreach (var item in _objRegistro) 
            {
                iCedula = item.Cedula;
                if (iCedula != null)
                {
                    break;
                }                
            }

            ViewBag.Cedula = iCedula;
            return View(); 
        }

        [HttpPost]
        public ActionResult PrestarHerramienta(string herramienta) 
        {
            //string sHerramienta = herramienta.Trim();
            try { 
                using (SqlConnection objCon = new SqlConnection(conexion))
                {
                    //****** Procedimiento Almacenado de BdInventario ******

                    //****** Validar que la herramienta Exista dentro de los Empleados ******
                    SqlCommand cmd = new SqlCommand("sp_SelectHerramientaByName", objCon);
                    cmd.Parameters.AddWithValue("Nombre_herramienta", herramienta);
                    cmd.CommandType = CommandType.StoredProcedure;
                    objCon.Open();

                    //var cuentaCedula = cmd.ExecuteScalar();

                    //_objHerramienta
                    _objHerramienta = new List<Herramienta>();                                 

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Herramienta nuevaHerramienta = new Herramienta
                                {
                                    Id_herramienta = reader["Id_herramienta"].ToString().ToUpper(),
                                    Nombre_herramienta = reader["Nombre_herramienta"].ToString().ToUpper(),
                                    Descripcion = reader["Descripcion"].ToString().ToUpper(),
                                    Prestada = Convert.ToBoolean(reader["Prestada"])
                                };

                                _objHerramienta.Add(nuevaHerramienta);
                            }
                        }
                        //ViewBag.Herramientas = _objHerramienta.ToList();

                        //return View();
                
                        //ViewBag.Mensaje = "CÉDULA NO EXISTE, COLABORADOR NO EXISTE O ERROR DE NÚMERO DE CÉDULA"; 
                }
            }
            catch (SqlException ex)
            {
                ViewBag.Error = ex.Message;
            }
            ViewBag.Cedula = iCedula;
            return View(_objHerramienta); 

        }

        [HttpGet]
        public ActionResult AgregarRegistro(string idherramienta) {
            if (idherramienta == "")
            {
                return RedirectToAction("PrestarHerramienta", "Home");
            }
            
            Herramienta oHerramienta = _objHerramienta.Where(c => c.Id_herramienta == idherramienta && c.Prestada == false).FirstOrDefault();
            ViewBag.Cedula = iCedula;
            Registro myRegistro = new Registro();
            myRegistro.Cedula = iCedula;
            myRegistro.Id_herramienta = oHerramienta.Id_herramienta;
            myRegistro.Nombre_herramienta = oHerramienta.Nombre_herramienta;
            myRegistro.Devuelta = false;
            myRegistro.Fecha_prestamo = DateTime.Today.ToString("d");
            myRegistro.Fecha_devuelve = DateTime.Today.AddDays(5).ToString("d");
            myRegistro.Fecha_devolucion = null;
            //DateTime.Now.AddDays(10);

            return View(myRegistro);
        }
                
        [HttpPost]  
        public ActionResult AgregarRegistro(Registro miReg)
        {
            //Aqui es donde se tiene que conectar a la base de datos                       
            
            if (miReg.Cedula != iCedula) 
                return RedirectToAction("PrestarHerramienta", "Home");
            try { 
                using (SqlConnection objCon = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarRegistro", objCon);
                    cmd.Parameters.AddWithValue("Cedula", miReg.Cedula);
                    cmd.Parameters.AddWithValue("Id_herramienta", miReg.Id_herramienta.ToString());
                    cmd.Parameters.AddWithValue("Devuelta", miReg.Devuelta);
                    cmd.Parameters.AddWithValue("Fecha_prestamo", miReg.Fecha_prestamo.ToString());
                    cmd.Parameters.AddWithValue("Fecha_devuelve", miReg.Fecha_devuelve.ToString());
                    cmd.Parameters.AddWithValue("Fecha_devolucion", miReg.Fecha_devolucion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    objCon.Open();

                    cmd.ExecuteNonQuery();
                }

                { ViewBag.Mensaje = "CÉDULA NO EXISTE, COLABORADOR NO EXISTE O ERROR DE NÚMERO DE CÉDULA"; }

            }
            catch (SqlException ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction("BuscarRegistroCedula", "Home");
            //return View();
        }


        // ****** Nuevo Datos de metodo prestarHerramienta
        [HttpGet]
        public ActionResult DevolucionHerramienta(string idherramienta)
        {
            if (idherramienta == "")
            {
                return RedirectToAction("BuscarRegistroCedula", "Home");
            }
            
            Registro oRegistro = (Registro)_objRegistro.Where(c => c.Id_herramienta == idherramienta && c.Devuelta == false).FirstOrDefault();
           
            ViewBag.Cedula = iCedula;
            
            Registro myRegistro = new Registro();
            myRegistro.Cedula = iCedula;
            myRegistro.Id_registro = oRegistro.Id_registro;
            myRegistro.Id_herramienta = oRegistro.Id_herramienta;
            myRegistro.Nombre_herramienta = oRegistro.Nombre_herramienta;
            myRegistro.Devuelta = oRegistro.Devuelta;
            myRegistro.Fecha_prestamo = oRegistro.Fecha_prestamo.ToString();
            myRegistro.Fecha_devuelve = oRegistro.Fecha_devuelve.ToString();
            myRegistro.Fecha_devolucion = DateTime.Today.ToString("d");  
            //DateTime.Now.AddDays(10);

            return View(myRegistro);
            
        }

        [HttpPost]
        public ActionResult DevolucionHerramienta(Registro miReg)
        {
            if (miReg.Fecha_devolucion == null) 
            {
                alert("Debe Ingresar Fecha de Devolución Correcta...");
                return View(miReg);
            }


            //******* Revisar Mensajes al usuario 7/11/23 ********

            if (miReg.Id_registro == 0 || miReg.Id_herramienta == null)
            {
                //ViewBag.Mensaje = "Debe tener Id Registro y Fecha de Devolución";
                //return RedirectToAction("PrestarHerramienta", "Home");               
                //return View();
                //Response.Write("<script>alert('login successful');</script>");
                alert("Debe Ingresar los Datos Correctamente - Dar Clic en Regresar al Menú");
                //return View(miReg);
                return View();
                //return RedirectToAction("BuscarRegistroCedula","Home");
            }
            else { 
                //verificar tiempo de retraso y mostrar advertencia
                DateTime FechaHoy = DateTime.Today;
                DateTime FechaDevolucion = DateTime.Parse(miReg.Fecha_devolucion);
                DateTime FechaDevuelve = DateTime.Parse(miReg.Fecha_devuelve);
                DateTime FechaPrestamo = DateTime.Parse(miReg.Fecha_prestamo);
                TimeSpan tSpan = FechaDevuelve - FechaDevolucion;
                int dias = tSpan.Days;

                if(FechaDevolucion != FechaHoy || FechaDevolucion < FechaPrestamo) 
                { 
                    alert("Fecha de Devolución debe ser la Fecha Actual [HOY] \n Fecha de Devolución debe ser Mayor a Fecha de Préstamo...");
                    return View(miReg);
                }
                
                if (dias > 0) { alert($"Quedan Pendientes {Math.Abs(dias)} Días de Préstamo"); }
                if(dias < 0) { alert($"Tiene Retraso de {Math.Abs(dias)} Días de Entrega de Herramientas"); }
                
                try
                {
                    using (SqlConnection objCon = new SqlConnection(conexion))
                    {
                        SqlCommand cmd = new SqlCommand("sp_UpdateRegistro", objCon);

                        cmd.Parameters.AddWithValue("Id_movimiento", miReg.Id_registro);
                        cmd.Parameters.AddWithValue("Fecha_devolucion", miReg.Fecha_devolucion);

                        cmd.CommandType = CommandType.StoredProcedure;
                        objCon.Open();

                        cmd.ExecuteNonQuery();
                        //return RedirectToAction("BuscarRegistroCedula", "Home");
                        ViewBag.Mensaje = "Herramienta Devuelta Correctamente, Dar Clic en Regresar al Menú...";
                        return View();
                    }                
                }
                catch (SqlException ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            //return RedirectToAction("Mensaje", "Home");
            return RedirectToAction("BuscarRegistroCedula", "Home");
            //return View();
        }

        public ActionResult Mensaje() 
        { 
            return View(); 
        }

        private void alert(string message)
        {
            Response.Write("<script>alert('" + message + "')</script>");           
        }
    }
}