
using System.Web.Mvc;

namespace SistemaCondominiosMVC.Filtros
{
    // Este filtro comprueba si existe una sesión iniciada.
    public class SesionActivaAttribute : ActionFilterAttribute
    {
        // Se ejecuta antes de que se ejecute la acción del controlador.
        public override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            // Consultamos si existe el identificador de la persona
            // que guardamos cuando inició sesión.
            object idPersona =
                filterContext.HttpContext.Session["IdPersona"];

            // Si no existe, significa que no hay una sesión válida.
            if (idPersona == null)
            {
                // Enviamos al usuario a la pantalla de inicio de sesión.
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "controller", "Login" },
                        { "action", "Index" }
                    });
            }

            // Si existe IdPersona, el filtro permite continuar.
        }
    }
}
