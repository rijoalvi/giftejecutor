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
        private bool soloLectura;
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
            this.Text = "Creación de un nuevo usuario";
            buttonEditar.Visible = false;
            soloLectura = false;
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
            this.llenarComboPerfiles();
            comboPerfiles.Refresh();
            comboPerfiles.SelectedValue = usuario.getCorrelativoPerfil();
            this.Text = "Edición del usuario "+ textBoxNombreUsuario.Text;


            textBoxNombreUsuario.Enabled = false;
            textBoxContrasena.Enabled = false;
            textBoxConfirmaContrasena.Enabled = false;
            textBoxPreguntaSecreta.Enabled = false;
            textBoxRespuesta.Enabled = false;
            comboPerfiles.Enabled = false;
            soloLectura = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!soloLectura)
            {
                if (!estoyModificando)
                {
                    if (textBoxContrasena.Text == textBoxConfirmaContrasena.Text)
                    {

                        DataRow selectedDataRow = ((DataRowView)comboPerfiles.SelectedItem).Row;
                        int perfilId = Convert.ToInt32(selectedDataRow["Id"]);


                        usuario.crearNuevoUsuario(textBoxNombreUsuario.Text, textBoxContrasena.Text, textBoxPreguntaSecreta.Text, textBoxRespuesta.Text, perfilId);
                        gestionUsuarios.actulizarDataGrid();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("¡La contraseña y la confirmación no concuerdan!");
                    }
                }
                else
                {
                    if (textBoxContrasena.Text == textBoxConfirmaContrasena.Text)
                    {
                        DataRow selectedDataRow = ((DataRowView)comboPerfiles.SelectedItem).Row;
                        int perfilId1 = Convert.ToInt32(selectedDataRow["Id"]);
                        usuario.editarUsuario(usuario.getCorrelativo(), textBoxNombreUsuario.Text, textBoxContrasena.Text, textBoxPreguntaSecreta.Text, textBoxRespuesta.Text, perfilId1);
                        gestionUsuarios.actulizarDataGrid();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("¡La contraseña y la confirmación no concuerdan!");
                    }
                }
            }
            else
            {
                this.Close();
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            editarComponentes();
            buttonEditar.Visible = false;
            soloLectura = false;
        }

        private void editarComponentes()
        {
            textBoxNombreUsuario.Enabled = true;
            textBoxContrasena.Enabled = true;
            textBoxConfirmaContrasena.Enabled = true;
            textBoxPreguntaSecreta.Enabled = true;
            textBoxRespuesta.Enabled = true;
            comboPerfiles.Enabled = true;
        }
    }
}