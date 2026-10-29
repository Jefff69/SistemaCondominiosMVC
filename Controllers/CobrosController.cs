
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using SistemaCondominiosMVC.Data;
using SistemaCondominiosMVC.Models;
using SistemaCondominiosMVC.Filtros;

namespace SistemaCondominiosMVC.Controllers
{
    // Todas las acciones de cobros requieren una sesión activa.
    [SesionActiva]
    // Controlador encargado de consultar los cobros.
    public class CobrosController : Controller
    {
        // Obtiene los cobros y los envía a la vista.
        public ActionResult Index()
        {


            // Recuperamos el ID de la persona que inició sesión.
            int idPersona = Convert.ToInt32(Session["IdPersona"]);

            // Por defecto, filtramos los cobros por esa persona.
            int? filtroPersona = idPersona;

            // Los empleados pueden consultar todos los cobros.
            if (Session["EsEmpleado"] is bool esEmpleado && esEmpleado)
            {
                filtroPersona = null;
            }

            // Ejecutamos el procedimiento con el filtro correspondiente.
            DataTable tabla = AccesoDatos.EjecutarConsultaConId(
                "SP_ConsultarCobros",
                "@id_persona",
                filtroPersona);




            // Lista donde guardaremos los resultados.
            List<Cobro> cobros = new List<Cobro>();

            // Recorremos cada registro devuelto por SQL Server.
            foreach (DataRow fila in tabla.Rows)
            {
                Cobro cobro = new Cobro();

                // Datos propios del cobro.
                cobro.IdCobro = Convert.ToInt32(fila["id_cobro"]);
                cobro.Mes = Convert.ToInt32(fila["mes"]);
                cobro.Anno = Convert.ToInt32(fila["anno"]);
                cobro.Estado = fila["estado"].ToString();
                cobro.Monto = Convert.ToDecimal(fila["monto"]);

                // La fecha puede ser NULL si no se ha pagado.
                cobro.FechaPagada =
                    fila["fecha_pagada"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(fila["fecha_pagada"]);

                // Datos de la casa y su propietario obtenidos mediante JOIN.
                cobro.NombreCasa = fila["nombre_casa"].ToString();
                cobro.NombrePropietario = fila["nombre"].ToString();
                cobro.ApellidoPropietario = fila["apellido"].ToString();

                // Agregamos el cobro completo a la lista.
                cobros.Add(cobro);
            }

            // Enviamos los resultados a Views/Cobros/Index.cshtml.
            return View(cobros);
        }
    }
}
