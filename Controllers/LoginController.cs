
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using SistemaCondominiosMVC.Data;
using SistemaCondominiosMVC.Models;

namespace SistemaCondominiosMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        // Muestra el formulario para iniciar sesión.
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        // Recibe y valida los datos enviados desde el formulario.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel modelo)
        {
            // Comprueba primero las validaciones del modelo.
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            try
            {
                // Preparamos los parámetros que necesita SP_ValidarLogin.
                SqlParameter[] parametros =
                {
                    new SqlParameter("@email", modelo.Email.Trim()),
                    new SqlParameter("@contrasena", modelo.Contrasena)
                };

                // Ejecutamos el procedimiento almacenado.
                DataTable resultado =
                    AccesoDatos.EjecutarConsultaConParametros(
                        "SP_ValidarLogin",
                        parametros);

                // Si no hay filas, las credenciales no son válidas
                // o la persona no está activa.
                if (resultado.Rows.Count == 0)
                {
                    ModelState.AddModelError(
                        "",
                        "Correo o contraseña incorrectos, o usuario inactivo.");

                    return View(modelo);
                }

                // Obtenemos los datos de la persona autenticada.
                DataRow persona = resultado.Rows[0];

                int idPersona = Convert.ToInt32(persona["id_persona"]);
                string nombre = persona["nombre"].ToString();
                string apellido = persona["apellido"].ToString();
                string tipoPersona = persona["tipo_persona"].ToString();

                // Guardamos en sesión los datos necesarios
                // para identificar a la persona durante su navegación.
                Session["IdPersona"] = idPersona;
                Session["NombreCompleto"] = nombre + " " + apellido;

                // Este indicador permitirá distinguir al personal empleado.
                Session["EsEmpleado"] = string.Equals(
                    tipoPersona,
                    "Empleado",
                    StringComparison.OrdinalIgnoreCase);

                // Al iniciar sesión correctamente, mostramos los cobros.
                return RedirectToAction("Index", "Cobros");
            }
            catch (Exception)
            {
                // No mostramos detalles técnicos de la base de datos
                // al usuario final.
                ModelState.AddModelError(
                    "",
                    "Ocurrió un error al iniciar sesión. Intenta nuevamente.");

                return View(modelo);
            }
        }




        // GET: Login/CerrarSesion
        // Finaliza la sesión de la persona autenticada.
        public ActionResult CerrarSesion()
        {
            // Eliminamos los datos de sesión del usuario actual.
            Session.Clear();

            // Invalidamos la sesión actual.
            Session.Abandon();

            // Regresamos a la pantalla de inicio de sesión.
            return RedirectToAction("Index", "Login");
        }






    }
}
