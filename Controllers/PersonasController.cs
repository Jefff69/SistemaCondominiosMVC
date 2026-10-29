
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
    // Controlador encargado de gestionar las solicitudes
    // relacionadas con las personas del sistema.
    public class PersonasController : Controller
    {

        // Método Index: consulta las personas y envía
        // la información a la vista para mostrarla.
        public ActionResult Index()
        {
            // Ejecuta el procedimiento almacenado en SQL Server.
            // Los resultados se reciben en una tabla de datos.
            DataTable tabla = AccesoDatos.EjecutarConsulta(
                "SP_ConsultarPersonas"
            );

            // Creamos una lista vacía para guardar las personas.
            List<Persona> personas = new List<Persona>();

            // Recorremos cada fila que devolvió la consulta SQL.
            foreach (DataRow fila in tabla.Rows)
            {
                // Creamos un objeto Persona para cada registro.
                Persona persona = new Persona();

                // Copiamos los valores de SQL Server al objeto Persona.
                persona.IdPersona = Convert.ToInt32(fila["id_persona"]);
                persona.Nombre = fila["nombre"].ToString();
                persona.Apellido = fila["apellido"].ToString();
                persona.Email = fila["email"].ToString();
                persona.Telefono = fila["telefono"].ToString();
                persona.Direccion = fila["direccion"].ToString();

                // Si la fecha es NULL en SQL Server, guardamos null.
                // De lo contrario, convertimos el valor a DateTime.
                persona.FechaNacimiento =
                    fila["fecha_nacimiento"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(fila["fecha_nacimiento"]);

                // El estado también permite NULL en la base de datos.
                // Por eso comprobamos el valor antes de convertirlo.
                persona.Estado =
                    fila["estado"] == DBNull.Value
                    ? (bool?)null
                    : Convert.ToBoolean(fila["estado"]);

                // Obtenemos el tipo de persona.
                persona.TipoPersona = fila["tipo_persona"].ToString();

                // Agregamos la persona completa a nuestra lista.
                personas.Add(persona);
            }

            // Enviamos la lista a la vista Index.cshtml.
            // La vista utilizará estos datos para construir la tabla.
            return View(personas);
        }
    }
}
