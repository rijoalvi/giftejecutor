using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormNuevoUsuario : Form
    {
        FormGestionUsuarios gestionPerfiles;
        Usuario usuario;

        /// <summary>
        /// este constructor es para crear un nuevo usuario.
        /// </summary>
        public FormNuevoUsuario()
        {
            InitializeComponent();
            usuario = new Usuario();
        }

        /// <summary>
        /// Este constructor es para editar los datos de un usuario existente
        /// </summary>
        /// <param name="IDUsuario"></param>
        public FormNuevoUsuario(int IDUsuario)
        {
            InitializeComponent();
            usuario = new Usuario(IDUsuario);
        }


    }
}