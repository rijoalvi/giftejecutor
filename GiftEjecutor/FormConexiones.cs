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
        private int conexionSeleccionada=1;
        public FormConexiones()
        {
            InitializeComponent();
        }

        private void FormConexiones_Load(object sender, EventArgs e)
        {

        }

        private void radioButtonMYSQL_CheckedChanged(object sender, EventArgs e)
        {
   
            if (true == radioButtonMYSQL.Checked)
            {
                conexionSeleccionada = MYSQL;
            }
            else {
                conexionSeleccionada = SQLSERVER;
            }
            System.Console.Write(conexionSeleccionada);
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = new FormPrincipal(this.conexionSeleccionada);
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
    }
}