using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ControladorBD
    {//MySqlConnection mySqlConexion = new MySqlConnection("datasource=grupoingegift5.bluechiphosting.com;username=grupoin2_user;password=Qwerty123;database=grupoin2_GiftBD");
        //public const int MYSQL = 1;
        //public const int SQLSERVER = 2;

        public const int CONEXION_EXTERNA = 1;
        public const int CONEXION_ECCI = 2;

  


        //private MySqlConnection MYSQLConexion = new MySqlConnection("datasource=grupoingegift5.bluechiphosting.com;username=grupoin2_user;password=Qwerty123;database=grupoin2_GiftBD");
        //private SqlConnection SQLServerConexion = new SqlConnection("Data Source=BD;Initial Catalog=bdInge1g2_g2;Persist Security Info=True;User ID=usuarioInge1_g2;Password=ui1_g2");

        private SqlConnection conexionConfigurador;
        //private SqlConnection conexionEjecutor;


        public static int conexionConfiguracionSeleccionada;
       // public static int conexionEjecutonSeleccionada;

        /*public MySqlDataReader hacerConsultaMySQL(string sentenciaMySql)
        {
            MYSQLConexion.Close();
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
            //MYSQLConexion.Close();
            return datos;
        }*/

        /*public SqlDataReader hacerConsultaSQLServer(string sentenciaSQLServer)
        {
            SQLServerConexion.Close();
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
            //SQLServerConexion.Close();
            return datos;
        }*/




     /*   /// <summary>
        /// Devuelve la coneccion que esta siendo utilizada
        /// </summary>
        /// <returns></returns>
        public int getConeccionSeleccionada() {
            return conexionSelecciona;
        }
*/


        //por default es sqlServer
        public SqlDataReader hacerConsultaConfigurador(string sentencia)
        {
            SqlDataReader datos = null;
            SqlCommand comando = null;
            this.conexionConfigurador = this.getConnectionConfigurador();
            this.conexionConfigurador.Open();

            try
            {
                comando = new SqlCommand(sentencia, this.conexionConfigurador);
                datos = comando.ExecuteReader();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return datos;
        }

        public SqlDataReader hacerConsultaEjecutor(string sentencia)
        {
            SqlDataReader datos = null;
            SqlCommand comando = null;
            this.conexionConfigurador = this.getConnectionStringEjecutor();
            this.conexionConfigurador.Open();
            try
            {
                comando = new SqlCommand(sentencia, this.conexionConfigurador);
                datos = comando.ExecuteReader();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return datos;
        }

        public SqlConnection getConnectionConfigurador()
        {
            SqlConnection connectionStringConfigurador = null;
            if(ControladorBD.conexionConfiguracionSeleccionada==ControladorBD.CONEXION_EXTERNA){

                //connectionStringConfigurador = new SqlConnection("Data Source=DESCEPTICON;Initial Catalog=bdInge1g2_g2;Integrated Security=True");
                connectionStringConfigurador = new SqlConnection("Data Source=GiftConfigurador.db.3946477.hostedresource.com;Initial Catalog=GiftConfigurador;Persist Security Info=True;User ID=GiftConfigurador;Password=Qwerty123");
            }
            else
            {//Conexion ECCI
                connectionStringConfigurador = new SqlConnection("Data Source=BD;Initial Catalog=bdInge1g2_g2;Persist Security Info=True;User ID=usuarioInge1_g2;Password=ui1_g2");
            }
            return connectionStringConfigurador;
        }
        public SqlConnection getConnectionStringEjecutor()
        {
            SqlConnection connectionStringEjecutor = null;
            if (ControladorBD.conexionConfiguracionSeleccionada == ControladorBD.CONEXION_EXTERNA)
            {
                //connectionStringEjecutor = new SqlConnection("Data Source=DESCEPTICON;Initial Catalog=bdInge1g2_g2_ejecucion;Integrated Security=True");
                connectionStringEjecutor = new SqlConnection("Data Source=GiftEjecutor.db.3946477.hostedresource.com;Initial Catalog=GiftEjecutor;Persist Security Info=True;User ID=GiftEjecutor;Password=Qwerty123");
            }
            else//Conexion ECCI
            {
                connectionStringEjecutor = new SqlConnection("Data Source=BD;Initial Catalog=bdInge1g2_g2_ejecucion;Persist Security Info=True;User ID=usuarioInge1_g2;Password=ui1_g2");
            }
            return connectionStringEjecutor;
        }
    }
}
