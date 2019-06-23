using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.conexion = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = correo-sp-2017; Integrated Security = True");
        }

        public static bool Insertar(Paquete p)
        {            
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;                
            comando.CommandText = String.Format("INSERT INTO [dbo].[Paquetes] (direccionEntrega, trackingID, alumno) VALUES('{0}', '{1}', '{2}')", p.DireccionEntrega, p.TrackingID, "Bednarz Jorge");
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            return true;            
        }        
    }
}
