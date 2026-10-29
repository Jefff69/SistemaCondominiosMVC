using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using SistemaCondominiosMVC.Data;
using SistemaCondominiosMVC.Models;
using SistemaCondominiosMVC.Filtros;

namespace SistemaCondominiosMVC.Controllers
{
    public class ServiciosController : Controller
    {
        // Solo los empleados autenticados pueden gestionar servicios.
        [Empleado]
        public ActionResult Index()
        {
            DataTable tabla = AccesoDatos.EjecutarConsulta("SP_ConsultarServicios");

            List<Servicio> servicios = new List<Servicio>();

            foreach (DataRow fila in tabla.Rows)
            {
                Servicio servicio = new Servicio();

                servicio.IdServicio = Convert.ToInt32(fila["id_servicio"]);
                servicio.Nombre = fila["nombre"].ToString();
                servicio.Descripcion = fila["descripcion"].ToString();
                servicio.Precio = Convert.ToDecimal(fila["precio"]);
                servicio.IdCategoria = Convert.ToInt32(fila["id_categoria"]);
                servicio.Estado = Convert.ToBoolean(fila["estado"]);

                servicios.Add(servicio);
            }

            return View(servicios);
        }
    }
}
