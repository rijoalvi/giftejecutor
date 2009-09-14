﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormNuevaColeccion : Form
    {
        Form formPrincipal;
        int correlativoPadre;
        public FormNuevaColeccion(Form principal, String correlativoPadre)
        {
            this.correlativoPadre = int.Parse(correlativoPadre);
            this.formPrincipal = principal;
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNombre.Text.Length!=0)
            {
                this.btnAceptar.Enabled = true;
            }
            else {
                this.btnAceptar.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Coleccion coleccion = new Coleccion(this.txtNombre.Text,correlativoPadre);
            coleccion.crearColeccion();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}