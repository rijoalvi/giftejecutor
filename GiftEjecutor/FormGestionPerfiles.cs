using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormGestionPerfiles : Form
    {
        private Ventanota padreMDI;
        Perfil perfil;

        public FormGestionPerfiles()
        {
            this.perfil = new Perfil();
            InitializeComponent();
        }

        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }

        private void GestionPerfiles_Load(object sender, EventArgs e)
        {
            this.actulizarDataGrid();
        }
        public void actulizarDataGrid(){
            this.dataGridViewPerfiles.DataSource = this.perfil.getDataTableTodosPerfiles();
            this.dataGridViewPerfiles.Columns[0].Visible = false;
            this.dataGridViewPerfiles.Columns[4].Visible = false;
        }
        private void buttonAgregarPerfil_Click(object sender, EventArgs e)
        {
            FormNuevoPerfil nuevoPerfil = new FormNuevoPerfil(this);
            nuevoPerfil.Show();
        }

        private void dataGridViewPerfiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

         /*   System.Windows.Forms.DataGridViewCellStyle b = new DataGridViewCellStyle();
            b.BackColor = System.Drawing.Color.White;

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < this.dataGridViewPerfiles.RowCount; i++)
                {
                    this.dataGridViewPerfiles[j, i].Style = b;

                }
            }

            System.Windows.Forms.DataGridViewCellStyle azul = new DataGridViewCellStyle();
            azul.BackColor = System.Drawing.Color.RoyalBlue;
            azul.ForeColor = Color.White;

            for (int i = 0; i < 3; i++)
            {
                this.dataGridViewPerfiles[i, this.dataGridViewPerfiles.CurrentRow.Index].Style = azul;
            }*/
            
        }

        private void dataGridViewPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            System.Windows.Forms.DataGridViewCellStyle b = new DataGridViewCellStyle();
            b.BackColor = System.Drawing.Color.White;

            for (int j = 0; j < this.dataGridViewPerfiles.ColumnCount; j++)
            {
                for (int i = 0; i < this.dataGridViewPerfiles.RowCount; i++)
                {
                    this.dataGridViewPerfiles[j, i].Style = b;

                }
            }

            System.Windows.Forms.DataGridViewCellStyle azul = new DataGridViewCellStyle();
            azul.BackColor = System.Drawing.Color.RoyalBlue;
            azul.ForeColor = Color.White;

            for (int i = 0; i < this.dataGridViewPerfiles.ColumnCount; i++)
            {
                this.dataGridViewPerfiles[i, this.dataGridViewPerfiles.CurrentRow.Index].Style = azul;
            }
            this.buttonEliminarPerfil.Enabled = true;
        }

        private void buttonEliminarPerfil_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Eliminar: "+this.dataGridViewPerfiles[0,this.dataGridViewPerfiles.CurrentRow.Index].Value.ToString());
            int IDPerfilSeleccionado = Int32.Parse(this.dataGridViewPerfiles[0, this.dataGridViewPerfiles.CurrentRow.Index].Value.ToString());
            this.perfil.deletePerfil(IDPerfilSeleccionado);

            MessageBox.Show("Eliminado perfil: " + this.dataGridViewPerfiles[1, this.dataGridViewPerfiles.CurrentRow.Index].Value.ToString());
            this.actulizarDataGrid();
        }

        private void buttonDetalles_Click(object sender, EventArgs e)
        {
            //FormDetallesPerfil formDetallesPerfil = new FormDetallesPerfil();
           // formDetallesPerfil.Show();
            int IDPerfilSeleccionado = Int32.Parse(this.dataGridViewPerfiles[0, this.dataGridViewPerfiles.CurrentRow.Index].Value.ToString());
            FormDetallesPerfil formDetallesPerfil = new FormDetallesPerfil(IDPerfilSeleccionado);
            formDetallesPerfil.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}