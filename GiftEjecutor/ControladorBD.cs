using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace GiftEjecutor
{
    class ControladorBD
    {//MySqlConnection mySqlConexion = new MySqlConnection("datasource=grupoingegift5.bluechiphosting.com;username=grupoin2_user;password=Qwerty123;database=grupoin2_GiftBD");
        private const int MYSQL = 1;
        private const int SQLSERVER = 2;
        private MySqlConnection MYSQLConexion = new MySqlConnection("datasource=grupoingegift5.bluechiphosting.com;username=grupoin2_user;password=Qwerty123;database=grupoin2_GiftBD");
        private MySqlConnection SQLServerConexion = new MySqlConnection("datasource=lucachaco.bluechiphosting.com;username=lucachac_user;password=todosepuede;database=lucachac_db");
        public static int conexionSelecciona;
        public MySqlDataReader hacerConsulta(string sentenciaMySql)
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
                        comando = new MySqlCommand(sentenciaMySql, SQLServerConexion);
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
    }
}
