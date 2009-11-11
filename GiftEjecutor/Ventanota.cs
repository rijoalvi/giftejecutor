using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GiftEjecutor
{
    public partial class Ventanota : Form
    {
        FormConexiones frm;
        Usuario usuario;
        public Ventanota()
        {
            InitializeComponent();
            Thread t1 = new Thread(new ThreadStart(SplashForm));
            t1.Start();
            Thread.Sleep(2500); // The amount of time we want our splash form visible
            t1.Abort();
            Thread.Sleep(1000);
        }

        private void SplashForm()
        {
            Splash newSplashForm = new Splash();
            newSplashForm.ShowDialog();
            newSplashForm.Dispose();
        }

        private void Ventanota_Load_1(object sender, EventArgs e)
        {
            frm = new FormConexiones();
            frm.MdiParent = this;
            frm.setPadreMDI(this);
            frm.Show();
        }

        public void setUsuario(Usuario user)
        {
            usuario = user;
        }

        public Usuario getUsuario()
        {
            return usuario;
        }
    }
}