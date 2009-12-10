using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    /// <summary>
    /// Ventana que muestra todos los usuarios
    /// </summary>
    public partial class FormGestionUsuarios : Form
    {
        private Ventanota padreMDI;
        Usuario usuario;

        /// <summary>
        /// Constructor por omisión
        /// </summary>
        public FormGestionUsuarios()
        {
            this.usuario = new Usuario();
            InitializeComponent();
            //OJO, ESTO ES PARA QUE EL DATAGRID SE VEA "BONITO":
            dataGridViewUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);            
        }

        /// <summary>
        /// Asigna el padre MDI
        /// </summary>
        /// <param name="v"></param>
        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            this.actulizarDataGrid();
        }

        /// <summary>
        /// Actualiza la lista de usuarios
        /// </summary>
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

        private void buttonEliminarPerfil_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dataGridViewUsuarios.CurrentRow;
            if (filaSeleccionada != null)
            {
                int IDUsuario = Int32.Parse(filaSeleccionada.Cells[0].Value.ToString());
                usuario.borrarUsuario(IDUsuario);
                this.actulizarDataGrid();
            }
        }

        /// <summary>
        /// Aqui se edita un usuario o se abre para solo lectura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}