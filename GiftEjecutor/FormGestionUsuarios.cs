using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormGestionUsuarios : Form
    {
        Usuario usuario;
        public FormGestionUsuarios()
        {
            this.usuario = new Usuario();
            InitializeComponent();

            //OJO, ESTO ES PARA QUE EL DATAGRID SE VEA "BONITO":
            dataGridViewUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
            
        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            this.actulizarDataGrid();
        }
        public void actulizarDataGrid(){
            this.dataGridViewUsuarios.DataSource = this.usuario.getDataTableTodosUsuarios();
            this.dataGridViewUsuarios.Columns[0].Visible = false;
            this.dataGridViewUsuarios.Columns[3].Visible = false;
            this.dataGridViewUsuarios.Columns[4].Visible = false;
            this.dataGridViewUsuarios.Columns[5].Visible = false;
            this.dataGridViewUsuarios.Columns[7].Visible = false;
        }
        private void buttonAgregarPerfil_Click(object sender, EventArgs e)
        {
            FormNuevoUsuario nuevoUsuario = new FormNuevoUsuario(this);
            nuevoUsuario.Show();
        }

        private void dataGridViewPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*System.Windows.Forms.DataGridViewCellStyle b = new DataGridViewCellStyle();
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
            this.buttonEliminarPerfil.Enabled = true;*/
        }

        private void buttonEliminarPerfil_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Eliminar: "+this.dataGridViewPerfiles[0,this.dataGridViewPerfiles.CurrentRow.Index].Value.ToString());
            /*int IDPerfilSeleccionado = Int32.Parse(this.dataGridViewPerfiles[0, this.dataGridViewPerfiles.CurrentRow.Index].Value.ToString());
            this.perfil.deletePerfil(IDPerfilSeleccionado);

            MessageBox.Show("Eliminado perfil: " + this.dataGridViewPerfiles[1, this.dataGridViewPerfiles.CurrentRow.Index].Value.ToString());
            this.actulizarDataGrid();*/
        }

        private void buttonDetalles_Click(object sender, EventArgs e)
        {
            /*           //FormDetallesPerfil formDetallesPerfil = new FormDetallesPerfil();
                      // formDetallesPerfil.Show();
                       int IDPerfilSeleccionado = Int32.Parse(this.dataGridViewPerfiles[0, this.dataGridViewPerfiles.CurrentRow.Index].Value.ToString());
                       FormDetallesPerfil formDetallesPerfil = new FormDetallesPerfil(IDPerfilSeleccionado);
                       formDetallesPerfil.Show();*/
        }

        private void dataGridViewUsuarios_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dataGridViewUsuarios.CurrentRow;
            if (filaSeleccionada != null)
            {
                int IDUsuario = Int32.Parse(filaSeleccionada.Cells[0].Value.ToString());
                FormNuevoUsuario nuevoUsuario = new FormNuevoUsuario(IDUsuario, this);
                nuevoUsuario.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}