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
    /// <summary>
    /// Ventana principal que se utiliza de fondo para las otras ventanas, esto hace que se tenga solamente una ventana abierta a la vez.
    /// </summary>
    public partial class Ventanota : Form
    {
        FormConexiones frm;
        Usuario usuario;

        /// <summary>
        /// Constructor por omisión
        /// </summary>
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

        /// <summary>
        /// Asigna un usuario a la ventana, esto se utiliza para mantener los datos del usuario logueado
        /// </summary>
        /// <param name="user"></param>
        public void setUsuario(Usuario user)
        {
            usuario = user;
        }

        /// <summary>
        /// Devuelve el usuario logueado
        /// </summary>
        /// <returns></returns>
        public Usuario getUsuario()
        {
            return usuario;
        }
    }
}