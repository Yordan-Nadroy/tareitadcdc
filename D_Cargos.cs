﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace pjGestionEmpleados.Datos
{
    namespace pjGestionEmpleados.Datos
    {
        public class D_Cargos
        {
            public DataTable Listar_Cargos()
            {
                MySqlDataReader resultado;
                DataTable tabla = new DataTable();
                MySqlConnection SqlCon = new MySqlConnection();

                try
                {
                    SqlCon = Conexion.CrearInstancia().CrearConexion();
                    MySqlCommand comando = new MySqlCommand("SP_LISTAR_CARGOS", SqlCon);
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlCon.Open();
                    resultado = comando.ExecuteReader();
                    tabla.Load(resultado);
                    return tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                }
                finally
                {
                    if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                }
            }
        }
    }
}