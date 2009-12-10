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
    /// Ventana que permite la asignacion de actividades a un usuario
    /// </summary>
    public partial class FormAsignacionActividades : Form
    {
        private Ventanota padreMDI;
        private Expediente miExpediente;
        private Usuario usuarioEnEdicion;

        /// <summary>
        /// Constructor por omisión
        /// </summary>
        public FormAsignacionActividades()
        {
            InitializeComponent();
        }

        /// <summary>
        /// carga el combo de usuarios con todos los usuarios que hay en el sistema
        /// </summary>
        private void cargarDatosComboUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = padreMDI.getUsuario().getTodosLosUsuarios();
            comboUsuarios.Items.Clear();
            for (int i = 0; i < usuarios.Count; i++)
            {
                comboUsuarios.Items.Add(usuarios[i]);
            }
        }

        /// <summary>
        /// carga los expedientes del usuario seleccionado
        /// </summary>
        private void cargarDatosComboExpedientes()
        {
            miExpediente = new Expediente("basura");
            List<Expediente> expedientes = new List<Expediente>();
            expedientes = miExpediente.getTodosLosExpedientes(((Usuario)(comboUsuarios.SelectedItem)).getCorrelativo());
            comboExpedientes.Items.Clear();
            comboExpedientes.Text = "";
            for (int i = 0; i < expedientes.Count; i++)
            {
                comboExpedientes.Items.Add(expedientes[i]);
            }             
        }


        private void cargarDataGrid()
        {
            Usuario user = new Usuario(((Usuario)(comboUsuarios.SelectedItem)).getCorrelativo());
            dataGridActividadesSeleccionadas1.DataSource = user.getDataTableActividadesAsignadasPorExpediente(((Expediente)(comboExpedientes.SelectedItem)).getCorrelativo());
            dataGridActividadesSeleccionadas1.Columns[0].Visible = false;
            this.dataGridActividadesSeleccionadas1.Refresh();

            dataGridActividadesNoSeleccionadas1.DataSource = user.getDataTableActividadesNoAsignadasPorExpediente(((Expediente)(comboExpedientes.SelectedItem)).getCorrelativo());
            dataGridActividadesNoSeleccionadas1.Columns[0].Visible = false;
            this.dataGridActividadesNoSeleccionadas1.Refresh();

        }

        /// <summary>
        /// referencia al padreMDI
        /// </summary>
        /// <param name="v"></param>
        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }

        private void FormAsignacionActividades_Load(object sender, EventArgs e)
        {
            this.cargarDatosComboUsuarios();
            comboExpedientes.Enabled = false;
        }

        private void comboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarDatosComboExpedientes();
            comboExpedientes.Enabled = true;
        }

        private void comboExpedientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarDataGrid();
        }

        private void dataGridActividades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewActividadesSeleccionadas1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int filaSeleccionada =dataGridActividadesNoSeleccionadas1.CurrentCell.RowIndex;
            int IDActividadSeleccionada = Int32.Parse(dataGridActividadesNoSeleccionadas1[0,filaSeleccionada].Value.ToString());

            String nombreActividadSeleccionada = dataGridActividadesNoSeleccionadas1[1,filaSeleccionada].Value.ToString();
            Console.Write("\n" + nombreActividadSeleccionada + "\n");

            Usuario user = new Usuario(((Usuario)(comboUsuarios.SelectedItem)).getCorrelativo());
            user.asignarActividad(((Expediente)(comboExpedientes.SelectedItem)).getCorrelativo(),IDActividadSeleccionada);

            cargarDataGrid();


        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}