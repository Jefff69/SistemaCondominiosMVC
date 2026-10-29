
using System.Web.Mvc;
using SistemaCondominiosMVC.Data;

namespace SistemaCondominiosMVC.Controllers
{
    public class PruebaConexionController : Controller
    {
        public ActionResult Index()
        {
            string resultado = Conexion.ProbarConexion();

            return Content(resultado);
        }
    }
}
