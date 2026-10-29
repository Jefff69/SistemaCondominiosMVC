using SistemaCondominiosMVC.Data;
using SistemaCondominiosMVC.Filtros;
using SistemaCondominiosMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;


namespace SistemaCondominiosMVC.Controllers
{

    // Todas las acciones requieren una sesión activa.
    [SesionActiva]
    public class CategoriasController : Controller
    {

        public ActionResult Index()
        {
            DataTable tabla = AccesoDatos.EjecutarConsulta("SP_ConsultarCategorias");

            List<Categoria> categorias = new List<Categoria>();

            foreach (DataRow fila in tabla.Rows)
            {
                Categoria categoria = new Categoria();

                categoria.IdCategoria = Convert.ToInt32(fila["id_categoria"]);
                categoria.Nombre = fila["nombre"].ToString();
                categoria.Descripcion = fila["descripcion"].ToString();
                categoria.Estado = Convert.ToBoolean(fila["estado"]);

                categorias.Add(categoria);
            }

            return View(categorias);
        }
    }
}
