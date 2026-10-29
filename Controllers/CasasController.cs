using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SistemaCondominiosMVC.Data;
using SistemaCondominiosMVC.Models;
using SistemaCondominiosMVC.Filtros;

namespace SistemaCondominiosMVC.Controllers
{
    // Todas las acciones de este controlador requieren una sesión activa.
    [Empleado]
    public class CasasController : Controller
    {
        // GET: Casas
            public ActionResult Index()
        {
            DataTable tabla = AccesoDatos.EjecutarConsulta("SP_ConsultarCasas");

            List<Casa> casas = new List<Casa>();

            foreach (DataRow fila in tabla.Rows)
            {
                Casa casa = new Casa();

                casa.IdCasa = Convert.ToInt32(fila["id_casa"]);
                casa.NombreCasa = fila["nombre_casa"].ToString();
                casa.MetrosCuadrados = Convert.ToDecimal(fila["metros_cuadrados"]);
                casa.NumeroHabitaciones = Convert.ToInt32(fila["numero_habitaciones"]);
                casa.NumeroBanos = Convert.ToInt32(fila["numero_banos"]);
                casa.Precio = Convert.ToDecimal(fila["precio"]);

                casa.NombrePropietario = fila["nombre"].ToString();
                casa.ApellidoPropietario = fila["apellido"].ToString();
                casa.EmailPropietario = fila["email"].ToString();

                casas.Add(casa);
            }

            return View(casas);
        }

    }
}