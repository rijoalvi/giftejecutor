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

        FormGestionUsuarios gestionUsuarios;
        Usuario usuario;
        private bool estoyModificando;

        /// <summary>
        /// este constructor es para crear un nuevo usuario.
        /// </summary>
        public FormNuevoUsuario(FormGestionUsuarios f)
        {
            InitializeComponent();
            gestionUsuarios = f;
            usuario = new Usuario();
            textBoxNombreUsuario.Text = "";
            textBoxContrasena.Text = "";
            textBoxConfirmaContrasena.Text = "";
            textBoxPreguntaSecreta.Text = "";
            textBoxRespuesta.Text = "";
            estoyModificando = false;
            this.llenarComboPerfiles();
            comboPerfiles.SelectedIndex = -1;
            comboPerfiles.Refresh();
        }

        /// <summary>
        /// Este constructor es para editar los datos de un usuario existente
        /// </summary>
        /// <param name="IDUsuario"></param>
        public FormNuevoUsuario(int IDUsuario, FormGestionUsuarios f)
        {
            InitializeComponent();
            gestionUsuarios = f;
            usuario = new Usuario(IDUsuario);
            usuario.cargarDatosPrivados();
            textBoxNombreUsuario.Text = usuario.getNombre();
            textBoxContrasena.Text = usuario.getContrasena();
            textBoxConfirmaContrasena.Text = usuario.getContrasena();
            textBoxPreguntaSecreta.Text = usuario.getPregunta();
            textBoxRespuesta.Text = usuario.getRespuesta();
            estoyModificando = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!estoyModificando)
            {
                if(textBoxContrasena.Text == textBoxConfirmaContrasena.Text){

                    DataRow selectedDataRow = ((DataRowView)comboPerfiles.SelectedItem).Row;
                    int perfilId = Convert.ToInt32(selectedDataRow["Id"]);


                    usuario.crearNuevoUsuario(textBoxNombreUsuario.Text, textBoxContrasena.Text, textBoxPreguntaSecreta.Text, textBoxRespuesta.Text, perfilId);
                }
                else
                {
                    MessageBox.Show("¡La contraseña y la confirmación no concuerdan!");
                }
            }
            else
            {
            }

        }

        private void llenarComboPerfiles()
        {
            comboPerfiles.Items.Clear();
            Perfil p = new Perfil();
            List<Perfil> lista = p.getListTodosPerfiles();
            DataTable dataTable = new DataTable("elementosCombo");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("NombrePerfil");
            for (int i = 0; i < lista.Count; ++i)
            {
                dataTable.Rows.Add(lista[i].getCorrelativo(), lista[i].getNombre());
            }
            comboPerfiles.DataSource = dataTable;
            comboPerfiles.DisplayMember = "NombrePerfil";
            comboPerfiles.ValueMember = "Id";
        }
    }
}