using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ControladorBD
    {//MySqlConnection mySqlConexion = new MySqlConnection("datasource=grupoingegift5.bluechiphosting.com;username=grupoin2_user;password=Qwerty123;database=grupoin2_GiftBD");
        public const int MYSQL = 1;
        public const int SQLSERVER = 2;
        private MySqlConnection MYSQLConexion = new MySqlConnection("datasource=grupoingegift5.bluechiphosting.com;username=grupoin2_user;password=Qwerty123;database=grupoin2_GiftBD");
        private SqlConnection SQLServerConexion = new SqlConnection("Data Source=BD;Initial Catalog=bdInge1g2_g2;Persist Security Info=True;User ID=usuarioInge1_g2;Password=ui1_g2");
        public static int conexionSelecciona;

        public MySqlDataReader hacerConsultaMySQL(string sentenciaMySql)
        {
            MySqlDataReader datos = null;
            MySqlCommand comando=null;
            MYSQLConexion.Open();
 
            try
            {
                switch(conexionSelecciona){
                    case MYSQL:
                        comando = new MySqlCommand(sentenciaMySql, MYSQLConexion);
                    break;
                    case SQLSERVER:
                      //  comando = new MySqlCommand(sentenciaMySql, SQLServerConexion);
                    break;
                    default:
                        MessageBox.Show("No se pudo conectar al servidor " , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                datos = comando.ExecuteReader();

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }


            return datos;
        }

        public SqlDataReader hacerConsultaSQLServer(string sentenciaSQLServer)
        {
            SqlDataReader datos = null;
            SqlCommand comando = null;
            SQLServerConexion.Open();

            try
            {
                comando = new SqlCommand (sentenciaSQLServer, SQLServerConexion);
                datos = comando.ExecuteReader();

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

            return datos;
        }

        /// <summary>
        /// Devuelve la coneccion que esta siendo utilizada
        /// </summary>
        /// <returns></returns>
        public int getConeccionSeleccionada() {
            return conexionSelecciona;
        }
    }
}
