
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaCondominiosMVC.Data
{
    public class AccesoDatos
    {
        public static DataTable EjecutarConsulta(string nombreProcedimiento)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand(nombreProcedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }




        // Ejecuta un procedimiento almacenado que necesita parámetros
        // y devuelve los resultados en una tabla.
        public static DataTable EjecutarConsultaConParametros(
            string nombreProcedimiento,
            SqlParameter[] parametros)
        {
            // La conexión se cierra automáticamente al terminar el bloque.
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // Indicamos que vamos a ejecutar un procedimiento almacenado.
                using (SqlCommand comando = new SqlCommand(nombreProcedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregamos los parámetros recibidos al comando.
                    // Así evitamos construir consultas concatenando datos del usuario.
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    // El adaptador ejecuta el procedimiento y llena la tabla.
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }




        // Ejecuta un procedimiento almacenado con un parámetro entero.
        // Se utilizará para filtrar los cobros por persona.
        public static DataTable EjecutarConsultaConId(
            string nombreProcedimiento,
            string nombreParametro,
            int? id)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand comando =
                    new SqlCommand(nombreProcedimiento, conexion))
                {
                    // Indicamos que se ejecutará un procedimiento almacenado.
                    comando.CommandType = CommandType.StoredProcedure;

                    // Si el ID es null, enviamos DBNull para que SQL Server
                    // pueda interpretar el parámetro como NULL.
                    SqlParameter parametro = new SqlParameter(
                        nombreParametro,
                        SqlDbType.Int);

                    parametro.Value = id.HasValue
                        ? (object)id.Value
                        : DBNull.Value;

                    comando.Parameters.Add(parametro);

                    // Ejecutamos el procedimiento y guardamos los resultados.
                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }




        // Ejecuta un procedimiento almacenado que realiza una operación,
        // como insertar, actualizar o eliminar registros.
        public static void EjecutarComando(
            string nombreProcedimiento,
            SqlParameter[] parametros)
        {
            // Abrimos la conexión y la cerramos automáticamente al finalizar.
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand comando =
                    new SqlCommand(nombreProcedimiento, conexion))
                {
                    // Indicamos que se ejecutará un procedimiento almacenado.
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregamos los parámetros que necesita el procedimiento.
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    // Ejecutamos el procedimiento sin esperar una tabla de resultados.
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }







    }
}
