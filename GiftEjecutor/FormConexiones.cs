using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormConexiones : Form
    {
        private Ventanota padreMDI;

        private const int MYSQL=1;
        private const int SQLSERVER=2;

        private const int CONEXION_EXTERNA = 1;
        private const int CONEXION_ECCI = 2;

        private int conexionEjecutorSeleccionada = CONEXION_EXTERNA;// por default
        private int conexionConfiguradorSeleccionada = CONEXION_EXTERNA;
        public FormConexiones()
        {
            InitializeComponent();
/*
            Thread t1 = new Thread(new ThreadStart(SplashForm));
            t1.Start();
            Thread.Sleep(5000); // The amount of time we want our splash form visible
            t1.Abort();
            Thread.Sleep(1000);*/
        }

        private void FormConexiones_Load(object sender, EventArgs e)
        {

        }

        private void radioButtonMYSQL_CheckedChanged(object sender, EventArgs e)
        {
   
            if (true == radioButtonEjecutorExterna.Checked)
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
            ControladorBD.conexionConfiguracionSeleccionada = conexionConfiguradorSeleccionada;
            FormPrincipal formPrincipal = new FormPrincipal(this.conexionEjecutorSeleccionada);

           // formPrincipal.MdiParent = padreMDI;
            formPrincipal.setPadreMDI(padreMDI);
            this.Hide();
            formPrincipal.Show();
            //Este si lo esconde, pero entonces nunk se mata el programa, asi q no funca
            //this.Visible = false;            
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
            if (true == this.radioButtonConfiguradorExterna.Checked)
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
            if (radioButtonEjecutorECCI.Checked)
            {
                radioButtonConfiguradorECCI.Checked = true;
                radioButtonConfiguradorExterna.Checked = false;
            }
            else
            {
                radioButtonConfiguradorECCI.Checked = false;
                radioButtonConfiguradorExterna.Checked = true;
            }
        }

        private void SplashForm()
        {
            Splash newSplashForm = new Splash();
            newSplashForm.ShowDialog();
            newSplashForm.Dispose();
        }

        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }
    }
}