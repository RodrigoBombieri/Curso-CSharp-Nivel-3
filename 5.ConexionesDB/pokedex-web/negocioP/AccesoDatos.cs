﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace negocioP
{
    public class AccesoDatos
    {
        private SqlConnection conexion;

        private SqlCommand comando;
        
        private SqlDataReader lector;

        // para leer el lector desde el exterior (no escribirlo)
        public SqlDataReader Lector
        {
            get { return lector; }
        }


        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex; 
            }

        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                // se usa para cuando queremos ejecutar una accion desde la base de datos, y no una consulta (no query=no consulta)
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();
        }

        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                /// se usa para cuando queremos ejecutar una accion desde la base de datos, 
                /// y no una consulta (no query=no consulta) y devuelve un valor entero 
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
