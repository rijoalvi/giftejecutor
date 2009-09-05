using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormConexiones : Form
    {
        private const int MYSQL=1;
        private const int SQLSERVER=2;

        private const int CONEXION_EXTERNA = 1;
        private const int CONEXION_ECCI = 2;

        private int conexionEjecutorSeleccionada = CONEXION_EXTERNA;// por default
        private int conexionConfiguradorSeleccionada = CONEXION_EXTERNA;
        public FormConexiones()
        {
            InitializeComponent();
        }

        private void FormConexiones_Load(object sender, EventArgs e)
        {

        }

        private void radioButtonMYSQL_CheckedChanged(object sender, EventArgs e)
        {
   
            if (true == radioButtonMySQLEjecutor.Checked)
            {
                conexionEjecutorSeleccionada = MYSQL;
            }
            else {
                conexionEjecutorSeleccionada = SQLSERVER;
            }
            System.Console.Write(conexionEjecutorSeleccionada);
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = new FormPrincipal(this.conexionEjecutorSeleccionada);

            ControladorBD.conexionConfiguracionSeleccionada = conexionConfiguradorSeleccionada;
            formPrincipal.Show();
            //this.Close(); ni este ni dispose me estan funcionando porq mata todo el programa... :s -- es que formPrincipal esta declarado aquì, tons cuando ud mata Formconexiones, esta matando a form principal, luisk
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             //  string target = e.Link.LinkData as string;

        // If the value looks like a URL, navigate to it.
        // Otherwise, display it in a message box.

           System.Diagnostics.Process.Start("http://www.bluechiphosting.com/");

        }

        private void mySqlConnection1_StateChange(object sender, StateChangeEventArgs e)
        {

        }

        private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {

        }

        private void radioButtonConfiguradorEEUU_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonConexionExternaConfigurador_CheckedChanged(object sender, EventArgs e)
        {
            if (true == this.radioButtonConexionExternaConfigurador.Checked)
            {
                this.conexionConfiguradorSeleccionada = CONEXION_EXTERNA;
            }
            else
            {
                this.conexionConfiguradorSeleccionada = CONEXION_ECCI;
            }
            System.Console.Write(conexionEjecutorSeleccionada);
        }

        private void radioButtonSQLServerConfigurador_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}