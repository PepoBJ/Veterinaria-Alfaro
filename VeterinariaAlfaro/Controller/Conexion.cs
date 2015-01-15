using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace VeterinariaAlfaro.Controller
{
    public class Conexion
    {
        private String cadenaConexion;
        private String query;
        SqlConnection conexion;
        private SqlDataAdapter adaptador;
        DataTable data;
        
        public String CadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }
        public String Query
        {
            get { return query; }
            set { query = value; }
        }

        public Conexion( String cadenaC = "")
        {
            if (cadenaC != "")
                this.CadenaConexion = cadenaC;

            this.CadenaConexion = WebConfigurationManager.ConnectionStrings["veterinaria"].ConnectionString;
            conexion = new SqlConnection(this.CadenaConexion);
            data = new DataTable();
        }

        public bool abrirConexion()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }
            return true;
        }

        public void cerrarConexion()
        {
            conexion.Close();
        }

        public DataTable getQuery(string _query)
        {
            this.abrirConexion();
            data.Clear();

            try
            {
                SqlCommand cmd = new SqlCommand(_query, conexion);
                adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                this.cerrarConexion();
            }
            
            return data;
        }

        
        public bool getNonQuery(string _query)
        {
            adaptador = new SqlDataAdapter();
            this.abrirConexion();

            try
            {
                SqlCommand cmd = new SqlCommand(_query, conexion);                
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                this.cerrarConexion();
            }

            return true;
        }
    }
}