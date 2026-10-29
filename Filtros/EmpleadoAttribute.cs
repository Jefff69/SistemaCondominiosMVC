
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaCondominiosMVC.Filtros
{
    // Este filtro permite el acceso únicamente a empleados autenticados.
    public class EmpleadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            // Comprobamos si hay una persona con sesión iniciada.
            object idPersona =
                filterContext.HttpContext.Session["IdPersona"];

            if (idPersona == null)
            {
                // Sin sesión, la persona debe iniciar sesión.
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Login" },
                        { "action", "Index" }
                    });

                return;
            }

            // Recuperamos el indicador de empleado guardado en el login.
            object esEmpleado =
                filterContext.HttpContext.Session["EsEmpleado"];

            // Solo permitimos continuar si el indicador es verdadero.
            if (!(esEmpleado is bool) || !(bool)esEmpleado)
            {
                // Un cliente no puede entrar a las funciones de gestión.
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Index" }
                    });
            }
        }
    }
}
