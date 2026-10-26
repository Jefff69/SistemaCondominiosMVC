
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemaCondominiosMVC.Data
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            string cadena = ConfigurationManager
                .ConnectionStrings["PVI_ProyectoFinal"]
                .ConnectionString;

            SqlConnection conexion = new SqlConnection(cadena);

            return conexion;
        }



        public static string ProbarConexion()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    return "Conexión exitosa con SQL Server.";
                }
            }
            catch (Exception ex)
            {
                return "Error de conexión: " + ex.Message;
            }
        }





    }
}
