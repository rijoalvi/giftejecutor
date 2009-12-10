using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace GiftEjecutor
{
    /// <summary>
    /// Ventana que permite mostrar lso formularios
    /// </summary>
    public partial class FormFormulario : Form
    {
        private Ventanota padreMDI;

        //Miembros
        private int IDForm; //ID del formulario con el q se esta trabajando
        private int IDExpediente; //ID del expediente al cual pertenecen los datos
        private int IDTupla;
        private int IDComandoConfig;
        private int IDActividad;

        private int tipoComando;//hecho por luisk
        private int IDFormularioDetalleSeleccionado;//para cuando se va a crear un detalle nuevo, saber cual?

        private TabPage tabPage;

        private String nombreTablaSelecionada;
        private int IDFormSelecionado;
        private int IDDatosSeleccionados;

        private FormActividad miPadre;
        private Formulario miFormulario; //El objeto formulario que tiene todos los datos dl configurador
     
        private Component[] componentes;
        private bool modificacion;
        private bool visualizacion;
        private bool eliminacion;
        private bool noEsComando;
        private String[] nombresCamposTupla;
        private int idMaestro;

        private String nombreFormDetalleSeleccionado;

        /// <summary>
        /// Constructor que muestra un formulario creado en el constructor
        /// </summary>
        /// <param name="IDForm"></param>
        public FormFormulario(int IDFormulario)
        {
            InitializeComponent();
            IDForm = IDFormulario;
            miFormulario = new Formulario(IDForm);
            this.Text = miFormulario.getNombre();
            modificacion = false; //xq se va a crear una nueva tupla, no midificar otra
            visualizacion = false; //no es comando d visualizar
            eliminacion = false;
            nombresCamposTupla = new String[miFormulario.getNumMiembros()];
            crearFormulario();
        }

        /// <summary>
        /// Constructor que abre un formulario que anteriormente fue llenado
        /// </summary>
        /// <param name="IDForm"></param>
        public FormFormulario(int IDFormulario, int IDExp, int IDAct, int IDdatos, int tipoComando, int IDComando, String datosConMascara, FormActividad padre, int idMaest)
        {
            InitializeComponent();
            IDForm = IDFormulario;
            IDTupla = IDdatos;
            IDExpediente = IDExp;
            IDActividad = IDAct;
            IDComandoConfig = IDComando;
            miPadre = padre;
            this.idMaestro = idMaest;
            noEsComando = false;
            miFormulario = new Formulario(IDForm);
            this.Text = miFormulario.getNombre();
            nombresCamposTupla = new String[miFormulario.getNumMiembros()];
            this.tipoComando = tipoComando;//luisk, para mandar a los detalles      
            switch(tipoComando){
                case 1: //Creacion
                    InitializeComponent();                    
                    modificacion = false; //xq se va a crear una nueva tupla, no midificar otra
                    visualizacion = false; //no es comando d visualizar
                    eliminacion = false;
                    noEsComando = false;
                    nombresCamposTupla = new String[miFormulario.getNumMiembros()];
                    crearFormulario();
                    break;
                case 2: //modificacion
                    modificacion = true; //xq se va a modificar una tupla, no crear una nueva
                    visualizacion = false; //no es comando d visualizar
                    eliminacion = false;
                    noEsComando = false;
                    crearFormulario();
                    //llena los datos al leer la tupla especifica
                    llenarFormulario();
                    break;
                case 3: //visualizacion                    
                    modificacion = false;
                    visualizacion = true; //es comando d visualizar
                    eliminacion = false;
                    noEsComando = false;
                    crearFormulario();
                    //llena los datos al leer la tupla especifica
                    llenarFormulario();
                    break;
                case 4: //borrado
                    modificacion = false;
                    visualizacion = true; //Es de borrado, pero esto es para hacer q sea de read-only
                    eliminacion = true;
                    noEsComando = false;
                    crearFormulario();
                    //llena los datos al leer la tupla especifica
                    llenarFormulario();
                    botonAceptar.Text = "Borrar";
                    break;
                case 5: //con Mascara
                    modificacion = false;
                    visualizacion = true; //Es con mascara, pero esto es para hacer q sea de read-only
                    eliminacion = false;
                    noEsComando = false;
                    crearFormulario();
                    //llena los datos al leer la tupla especifica
                    llenarFormulario();
                    //cambia el texto del boton Cancelar, para cerrar nada mas el form
                    botonAceptar.Visible = false;
                    botonCancelar.Text = "Cerrar";
                    //refresca la ventana de los comandos d la actividad
                   // miPadre.cargarDataGridComandos();
                    MessageBox.Show("Este es el formulario resultante, luego de ejecutar el siguiente cambio del comando con máscara: \n"+ datosConMascara);
                    break;
                case 6: //visualizacion de los formularios en el fram principal
                    modificacion = false;
                    visualizacion = true; //es comando d visualizar
                    eliminacion = false;
                    noEsComando = true;
                    crearFormulario();
                    //llena los datos al leer la tupla especifica
                    llenarFormulario();
                    //cambia el texto del boton Cancelar, para cerrar nada mas el form
                    botonAceptar.Visible = false;
                    botonCancelar.Text = "Cerrar";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Encargado de armar el prototipo del formulario 
        /// </summary>
        public void crearFormulario() {

            int cant = miFormulario.getNumMiembros();
            componentes = new Component[cant];
            String[] miembro = new String[13];
            for (int i = 0; i < cant; i++) {
                //Orden de los datos dentro de miembro:
                //0.correlativo, 1.nombre, 2.valX, 3.valY, 4.ancho, 5.alto, 6.tipoLetra, 7.color, 
                //8.tamanoLetra, 9.IDTipoCampo, 10.IDCampo, 11.tabIndex, 12.estiloLetra
                miembro = miFormulario.getMiembro(i);                
                int tipoCampo = int.Parse(miembro[9]);
                switch (tipoCampo) {
                    case 0:
                        //Etiqueta
                        Label etiqueta = new Label();
                        miembro[1] = miembro[1].Substring(4);
                        etiqueta.Text = miembro[1];
                        etiqueta.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        componentes[i] = etiqueta;
                        this.Controls.Add(etiqueta);
                        nombresCamposTupla[i] = null;
                        break;
                    case 1:
                        //Numero
                        string mascara = miFormulario.getMascaraNumero(int.Parse(miembro[10]));
                        MaskedTextBox numero = new MaskedTextBox(mascara);
                        numero.Name = miembro[1];
                        numero.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        numero.TabIndex = int.Parse(miembro[11]);
                        componentes[i] = numero;
                        this.Controls.Add(numero);
                        nombresCamposTupla[i] = miembro[1];
                        break;
                    case 2:
                        //Binario
                        RadioButton radio1 = new RadioButton();
                        radio1.Name = miembro[1];
                        radio1.Text = miembro[1];
                        radio1.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        radio1.TabIndex = int.Parse(miembro[11]);
                        componentes[i] = radio1;
                        this.Controls.Add(radio1);
                        nombresCamposTupla[i] = miembro[1];
                        
                        //Agrega el otro radio
                        ++i;
                        miembro = miFormulario.getMiembro(i);
                        RadioButton radio2 = new RadioButton();
                        radio2.Name = miembro[1];
                        radio2.Text = miembro[1];
                        radio2.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        radio2.TabIndex = int.Parse(miembro[11]);
                        componentes[i] = radio2;
                        this.Controls.Add(radio2);
                        nombresCamposTupla[i] = miembro[1];
                        
                        //Podrian meterse dentro de un panel, para asi poder tener varios grupos de radios por aparte sin q se anulen entre si...
                        //Ver aqui, la parte de "comentarios":
                        //http://msdn.microsoft.com/es-es/library/system.windows.forms.radiobutton%28VS.80%29.aspx
                        break;
                    case 3:
                        //FechaHora
                        DateTimePicker fecha = new DateTimePicker();
                        fecha.Name = miembro[1];
                        //fecha.Format = DateTimePickerFormat.Short;
                        fecha.CustomFormat = "dd MMM yyyy";
                        fecha.Format = DateTimePickerFormat.Custom;
                        
                        //fecha.Text = miembro[1];
                        fecha.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        fecha.TabIndex = int.Parse(miembro[11]);
                        componentes[i] = fecha;
                        this.Controls.Add(fecha);
                        nombresCamposTupla[i] = miembro[1];
                        break;
                    case 4:
                        //Texto
                        TextBox texto = new TextBox();
                        texto.Name = miembro[1];
                        string textoDefecto = miFormulario.getTextoDefecto(int.Parse(miembro[10]));
                        texto.MaxLength = miFormulario.getMaxLengthTexto(int.Parse(miembro[10]));
                        texto.Text = textoDefecto.Trim();
                        texto.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        texto.TabIndex = int.Parse(miembro[11]);
                        componentes[i] = texto;
                        this.Controls.Add(texto);
                        nombresCamposTupla[i] = miembro[1];
                        break;
                    case 5:
                        //Incremental
                        TextBox incremental = new TextBox();
                        incremental.Name = miembro[1];
                        string valInicial = miFormulario.getValInicial(int.Parse(miembro[10]));
                        incremental.Text = valInicial;
                        incremental.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        incremental.TabIndex = int.Parse(miembro[11]);
                        componentes[i] = incremental;
                        this.Controls.Add(incremental);
                        nombresCamposTupla[i] = miembro[1];
                        break;
                    case 6:
                        //Jerarquia
                        //0.correlativo, 1.nombre, 2.valX, 3.valY, 4.ancho, 5.alto, 6.tipoLetra, 7.color, 
                        //8.tamanoLetra, 9.IDTipoCampo, 10.IDCampo, 11.tabIndex, 12.estiloLetra
                                                
                        Jerarquia miJerarquia = new Jerarquia(int.Parse(miembro[10]));
                        TreeView jerarquia = miJerarquia.getArbol();
                        jerarquia.Name = miembro[1];
                        jerarquia.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        jerarquia.TabIndex = int.Parse(miembro[11]);                        
                        jerarquia.Refresh();
                        componentes[i] = jerarquia;
                        this.Controls.Add(jerarquia);
                        nombresCamposTupla[i] = miembro[1];
                         
                        break;
                    case 7:
                        //Lista
                        ComboBox comboBox = new ComboBox();
                        comboBox.Name = miembro[1];                        
                        String[] miembrosLista = miFormulario.getMiembrosLista(int.Parse(miembro[10]));
                        for (int k = 0; k < miembrosLista.Length; ++k)
                        {
                            comboBox.Items.Add(miembrosLista[k].Trim());
                        }                          
                        comboBox.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        comboBox.TabIndex = int.Parse(miembro[11]);
                        componentes[i] = comboBox;
                        this.Controls.Add(comboBox);
                        nombresCamposTupla[i] = miembro[1];
                        break;
                    default:                         
                        break;
                }
            }//Fin for que agrega miembros


            llenarMaestroDetalle();
            


        }

        private void llenarMaestroDetalle()
        {
            if (this.visualizacion || this.modificacion)
            {
                MaestroDetalle maestro = new MaestroDetalle();
                List<String> IDFormularioMaestro = new List<String>();
                IDFormularioMaestro = maestro.getDetallesIDs(this.IDForm);
                String campoSolo = null;
                foreach (String campo in IDFormularioMaestro)
                {
                    Console.WriteLine(campo);
                    campoSolo += " " + campo;
                }
                int cantidadDetalles = IDFormularioMaestro.Count / 2;
                TabControl tabControl = new TabControl();
                tabControl.Width = 1000;
                tabControl.SetBounds(0, 450, 600, 150);
                for (int i = 0; i < cantidadDetalles; i++)
                {
                    String nombreTabla = IDFormularioMaestro[(i * 2) + 1];                    
                    tabPage = new TabPage("detalles " + nombreTabla);
                    this.nombreFormDetalleSeleccionado = nombreTabla;
                    DataGridView dg = new DataGridView();
                    dg.BackgroundColor = Color.Beige;
                    dg.Name = nombreTabla;
                    //dg. quiero quitarle q deje editar las filas, pero no puedo... :s
                    dg.Width = 600;
                    dg.DataSource = maestro.getDataTableDetallesDinamicos(Int32.Parse(IDFormularioMaestro[i * 2]), nombreTabla, this.IDTupla);

                    //dg.Columns[0].Visible = false;
                    // dg.Columns[1].Visible = false;

                    tabPage.Controls.Add(dg);
                    tabControl.Controls.Add(tabPage);

                    //dg.CellContentClick += new DataGridViewCellEventHandler(funcionClickDeDataGrid);
                    dg.CellClick += new DataGridViewCellEventHandler(funcionClickDeDataGrid);

                }
                this.Controls.Add(tabControl);
            }
        }

        private void funcionClickDeDataGrid(object sender, DataGridViewCellEventArgs e)
        {
            int rowSeleccionada = ((DataGridView)sender).CurrentRow.Index;

            this.nombreTablaSelecionada = ((DataGridView)sender).Name.ToString();
            ConsultaFormulario cf = new ConsultaFormulario();
            this.IDFormSelecionado = cf.getIDFormularioPorNombre(this.nombreTablaSelecionada);
            if ( !((DataGridView)sender)[1, rowSeleccionada].Value.ToString().Equals("") )
            {
                this.IDDatosSeleccionados = Int32.Parse(((DataGridView)sender)[1, rowSeleccionada].Value.ToString());
                // MessageBox.Show(" " + this.nombreTablaSelecionada + " ID: " + this.IDFormSelecionado + " IDDatos: " + this.IDDatosSeleccionados);
                this.buttonVerDetalle.Enabled = true;
                this.buttonVerDetalle.Text = "Ver detalle " + this.nombreTablaSelecionada + " seleccionado";
            }
            this.buttonNuevoDetalle.Enabled = true;
            this.buttonNuevoDetalle.Text = "Nuevo detalle " + this.nombreTablaSelecionada;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            //Si se va a modificar una tupla
            if (modificacion)
            {
                actualizarTupla();
                miFormulario.insertarEnBitacora(IDExpediente, IDActividad, IDComandoConfig, 2, IDTupla, IDForm, true, "El usuario " + padreMDI.getUsuario() +" modificó la instancia del formulario " + miFormulario.getNombre() + ".");
                this.Visible = false;
            }
            else 
            {
                if (eliminacion)
                {
                    miFormulario.eliminarTupla(IDTupla, miFormulario.getNombre());
                    miFormulario.insertarEnBitacora(IDExpediente, IDActividad, IDComandoConfig, 3, IDTupla, IDForm, true, "El usuario " + padreMDI.getUsuario() + " eliminó la instancia del formulario " + miFormulario.getNombre() + ".");
                    MessageBox.Show("¡Se eliminó correctamente la instancia seleccionada!");
                    //refresca la ventana de los comandos d la actividad
                    miPadre.cargarDataGridComandos();
                    this.Visible = false;
                }
                else
                {
                    if (visualizacion)
                    {
                        //no hace nada solo va a bitacora
                        miFormulario.insertarEnBitacora(IDExpediente, IDActividad, IDComandoConfig, 3, IDTupla, IDForm, true, "El usuario " + padreMDI.getUsuario() + " visualizó la instancia del formulario" + miFormulario.getNombre() + ".");
                        //refresca la ventana de los comandos d la actividad
                        miPadre.cargarDataGridComandos();
                        this.Visible = false;
                    }
                    else //Si se va a crear una nueva tupla
                    {
                        //ingresa la tupla
                        ingresarNuevaTupla();
                        //ingresa el ingreso a la bitacora
                        if (padreMDI != null)
                        {
                            miFormulario.insertarEnBitacora(IDExpediente, IDActividad, IDComandoConfig, 1, IDTupla, IDForm, true, "El usuario " + padreMDI.getUsuario() + " agregó una nueva instancia del formulario " + miFormulario.getNombre() + ".");
                        }
                        //refresca la ventana de los comandos d la actividad
                        if (miPadre != null)
                        {//luisk
                            miPadre.cargarDataGridComandos();
                        }
                        this.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Ingresa una tupla segun el formulario que el usuario haya estado mostrando
        /// </summary>
        private void ingresarNuevaTupla()
        {
            int cant = miFormulario.getNumMiembros();
            String[] miembro = new String[13];
            String nombreForm = miFormulario.getNombre();
            //0.correlativo, 1.nombre, 2.valX, 3.valY, 4.ancho, 5.alto, 6.tipoLetra, 7.color, 
            //8.tamanoLetra, 9.IDTipoCampo, 10.IDCampo, 11.tabIndex, 12.estiloLetra
            //for (int k = 0; k < componentes.Length; ++k) { 
            String ingresoTupla = "INSERT into " + nombreForm;
            //Guarda el nombre del campo en la tabla
            String nombresCampos = "(";
            //Guarda lo que el usuario ingreso en el campo especifico
            String valoresCampos = "Values(";
            for (int i = 0; i < cant; i++)
            {
                miembro = miFormulario.getMiembro(i);
                int tipoCampo = int.Parse(miembro[9]);
                //Mientras no sea una etiqueta
                switch (tipoCampo)
                {
                    case 1:
                        //Numero                        
                        MaskedTextBox tmp = (MaskedTextBox)(componentes[i]);
                        nombresCampos += tmp.Name;
                        valoresCampos += tmp.Text.ToString();
                        //esto es por si quedan mas campos por ingresar
                        if ((i + 1) < cant)
                        {
                            valoresCampos += ", ";
                            nombresCampos += ", ";
                        }
                        break;
                    case 2:
                        //Binario
                        RadioButton radio = (RadioButton)(componentes[i]);
                        nombresCampos += radio.Name;
                        valoresCampos += "'" + radio.Checked + "'";
                        //esto es por si quedan mas campos por ingresar
                        if ((i + 1) < cant)
                        {
                            valoresCampos += ", ";
                            nombresCampos += ", ";
                        }
                        break;
                    case 3:
                        //FechaHora
                        DateTimePicker fecha = (DateTimePicker)(componentes[i]);
                        nombresCampos += fecha.Name;
                        //MessageBox.Show(fecha.Value.ToString());
                        //MessageBox.Show(fecha.Value.ToString("MM/dd/yyyy"));
                        //String laFecha = fecha.Value.ToString("MM/dd/yyyy");
                        String laFecha = fecha.Value.ToString();
                        laFecha = laFecha.Substring(0, 10);
                        DateTime fecha2;
                        if (DateTime.TryParse(laFecha, out fecha2))
                        {
                            String miFecha = fecha2.Month + "/" + fecha2.Day + "/" + fecha2.Year;
                            valoresCampos += "'" + miFecha + "'";                            
                        }
                        else
                        {
                            MessageBox.Show("Fecha definida con formato incorrecto, por favor revisar");
                        }
                        //esto es por si quedan mas campos por ingresar
                        if ((i + 1) < cant)
                        {
                            valoresCampos += ", ";
                            nombresCampos += ", ";
                        }
                        break;
                    case 4:
                        //Texto
                        TextBox texto = (TextBox)(componentes[i]);
                        nombresCampos += texto.Name;
                        valoresCampos += "'" + texto.Text.ToString() + "'";
                        if ((i + 1) < cant)
                        {
                            valoresCampos += ", ";
                            nombresCampos += ", ";
                        }
                        break;
                    case 5:
                        //Incremental
                        TextBox inc = (TextBox)(componentes[i]);
                        nombresCampos += inc.Name;
                        valoresCampos += "'" + inc.Text.ToString() + "'";
                        //esto es por si quedan mas campos por ingresar
                        if ((i + 1) < cant)
                        {
                            valoresCampos += ", ";
                            nombresCampos += ", ";
                        }
                        break;
                    case 6:
                        //Jerarquia
                        
                        TreeView jera = (TreeView)(componentes[i]);
                        nombresCampos += jera.Name;
                        valoresCampos += "'" + jera.SelectedNode.FullPath + "'";
                        //esto es por si quedan mas campos por ingresar
                        if ((i + 1) < cant)
                        {
                            valoresCampos += ", ";
                            nombresCampos += ", ";
                        } 
                        
                        break;
                    case 7:
                        //Lista
                        ComboBox lista = (ComboBox)(componentes[i]);
                        nombresCampos += lista.Name;
                        valoresCampos += "'" + lista.SelectedItem.ToString() + "'";
                        //lista.SelectedText;
                        //esto es por si quedan mas campos por ingresar
                        if ((i + 1) < cant)
                        {
                            valoresCampos += ", ";
                            nombresCampos += ", ";
                        }
                        break;
                    default:
                        //Soy una etiqueta, no hago nada :p
                        break;
                }



            } //fin for
            valoresCampos += ", " + this.idMaestro + ")";
            nombresCampos += ", IDMaestro) ";
            ingresoTupla += nombresCampos + valoresCampos;
            Console.WriteLine(ingresoTupla);
            IDTupla = miFormulario.insertarTuplaFormulario(ingresoTupla, nombreForm);            
        }

        /*
        public String obtenerPathJerarquia(TreeView jera){
            //pone el nombre dl nodo seleccionado
            String path = jera.SelectedNode.Text;
            //sigue buscando recursivamente los otros nombres del nodo
            path = obtenerPathNodo(jera.SelectedNode.Parent) + jera.SelectedNode.Text;
            return path;
        }

        private String obtenerPathNodo(TreeNode nodo){
            String path = "";
            path = obtenerPathNodo(nodo.Parent) + jera.SelectedNode.Text;
        }
        */ 

        /// <summary>
        /// Actualiza una tupla segun el formulario que el usuario haya estado mostrando
        /// </summary>
        private void actualizarTupla()
        {
            int cant = miFormulario.getNumMiembros();
            String[] miembro = new String[13];
            String nombreForm = miFormulario.getNombre();
            //0.correlativo, 1.nombre, 2.valX, 3.valY, 4.ancho, 5.alto, 6.tipoLetra, 7.color, 
            //8.tamanoLetra, 9.IDTipoCampo, 10.IDCampo, 11.tabIndex, 12.estiloLetra
            //update Vehiculo (Placa, Dueño, Estadoorden, Fecharecibido) 
            //Values(123456, 'Beto', 'recibido', '8-9-2009');
            String consultaTupla = "UPDATE " + nombreForm + " set ";
            
            for (int i = 0; i < cant; i++)
            {
                miembro = miFormulario.getMiembro(i);
                int tipoCampo = int.Parse(miembro[9]);
                //Mientras no sea una etiqueta
                switch (tipoCampo)
                {
                    case 1:
                        //Numero                        
                        MaskedTextBox tmp = (MaskedTextBox)(componentes[i]);
                        consultaTupla += tmp.Name + " = " + tmp.Text.ToString();
                        if ((i + 1) < cant)                        
                            consultaTupla += ", ";                                                  
                        break;
                    case 2:
                        //Binario
                        RadioButton radio = (RadioButton)(componentes[i]);
                        consultaTupla += radio.Name + " = '" + radio.Checked + "'";
                        if ((i + 1) < cant)
                            consultaTupla += ", ";
                        break;
                    case 3:
                        //FechaHora
                        DateTimePicker fecha = (DateTimePicker)(componentes[i]);
                        String laFecha = fecha.Value.ToString();
                        consultaTupla += fecha.Name + " = '" + laFecha.Substring(0, 10) + "'";
                        if ((i + 1) < cant)
                            consultaTupla += ", ";
                        break;
                    case 4:
                        //Texto
                        TextBox texto = (TextBox)(componentes[i]);
                        consultaTupla += texto.Name + " = '" + texto.Text.ToString() + "'";
                        if ((i + 1) < cant)
                            consultaTupla += ", ";
                        break;
                    case 5:
                        //Incremental
                        TextBox inc = (TextBox)(componentes[i]);
                        consultaTupla += inc.Name + " = '" + inc.Text.ToString() + "'";
                        if ((i + 1) < cant)
                            consultaTupla += ", ";
                        break;
                    case 6:
                        //Jerarquia
                        TreeView jera = (TreeView)(componentes[i]);
                        consultaTupla += "'" + jera.SelectedNode.FullPath + "'";
                        //esto es por si quedan mas campos por ingresar
                        if ((i + 1) < cant)
                        {
                            consultaTupla += ", ";
                        } 
                        break;
                    case 7:
                        //Lista
                        ComboBox lista = (ComboBox)(componentes[i]);
                        consultaTupla += lista.Name + " = '" + lista.SelectedItem.ToString() + "'";
                        //lista.SelectedText;
                        if ((i + 1) < cant)
                            consultaTupla += ", ";
                        break;
                    default:
                        //Soy una etiqueta, no hago nada :p
                        break;
                }

            } //fin for
            consultaTupla += " where correlativo = " + IDTupla + ";";
            Console.WriteLine(consultaTupla);
            miFormulario.ejecutarConsultaEjecutor(consultaTupla);            
        }

        private void llenarFormulario() {                        
            String consultaTupla = "SELECT * FROM " + miFormulario.getNombre() + " WHERE correlativo = " + IDTupla + ";";
            SqlDataReader datos = miFormulario.ejecutarConsultaEjecutor(consultaTupla);
            if(datos.Read()){ //Mientras hayan datos
                String[] miembro = new String[13];
                int valor = 1;
                for (int i = 0; i < nombresCamposTupla.Length; ++i)
                {
                    //siempre q no sea una etiqueta
                    if (nombresCamposTupla[i] != null)
                    {
                        miembro = miFormulario.getMiembro(i);
                        int tipoCampo = int.Parse(miembro[9]);
                        //Mientras no sea una etiqueta
                        switch (tipoCampo)
                        {
                            case 1:
                                //Numero                        
                                MaskedTextBox tmp = (MaskedTextBox)(componentes[i]);
                                tmp.Text = datos.GetValue(valor).ToString();
                                //si es comando d visualizacion
                                if (visualizacion)
                                    tmp.ReadOnly = true;
                                break;
                            case 2:
                                //Binario
                                RadioButton radio = (RadioButton)(componentes[i]);
                                if (datos.GetValue(valor).ToString().Equals("True"))
                                    radio.Checked = true;
                                else
                                    radio.Checked = false;
                                //si es comando d visualizacion
                                if (visualizacion)
                                    radio.Enabled = false;
                                break;
                            case 3:
                                //FechaHora
                                DateTimePicker fecha = (DateTimePicker)(componentes[i]);
                                fecha.Value = ((System.DateTime)(datos.GetValue(valor)));
                                //si es comando d visualizacion
                                if (visualizacion)
                                    fecha.Enabled = false; 
                                break;
                            case 4:
                                //Texto
                                TextBox texto = (TextBox)(componentes[i]);
                                texto.Text = datos.GetValue(valor).ToString();
                                //si es comando d visualizacion
                                if (visualizacion)
                                    texto.ReadOnly = true;
                                break;
                            case 5:
                                //Incremental
                                TextBox inc = (TextBox)(componentes[i]);
                                inc.Text = datos.GetValue(valor).ToString();
                                //si es comando d visualizacion
                                if (visualizacion)
                                    inc.ReadOnly = true;
                                break;
                            case 6:
                                //Jerarquia
                                TreeView jera = (TreeView)(componentes[i]);
                                jera.ExpandAll();
                                //selecciona el nodo en la jerarquia
                                seleccionarNodo(jera, datos.GetValue(valor).ToString());
                                //si es comando d visualizacion
                                /*if (visualizacion)
                                    jera.Enabled = false;*/
                                break;
                            case 7:
                                //Lista
                                ComboBox lista = (ComboBox)(componentes[i]);
                                lista.SelectedItem = datos.GetValue(valor).ToString();
                                //si es comando d visualizacion
                                if (visualizacion)
                                    lista.Enabled = false;
                                break;
                            default:
                                //Soy una etiqueta, no hago nada :p
                                break;
                        }
                        valor++;
                    }
                } //fin for nombres
            }
        
        }

        private void seleccionarNodo(TreeView jera, String path)
        {
            //mientras no este vacío
            for(int i = 0; i < jera.Nodes.Count; ++i)
            {
                if (jera.Nodes[i].FullPath.Equals(path))
                {
                    jera.Nodes[i].BackColor = Color.Red;
                    i = jera.Nodes.Count;
                }
                //recursivamente revisa para abajo.
                else
                {
                    if(jera.Nodes[i].Nodes.Count > 0)
                        seleccionarNodoSubArbol(jera.Nodes[i], path);
                }
            }
        }
        
        private void seleccionarNodoSubArbol(TreeNode jera, String path)
        {
            //mientras no este vacío
            for (int i = 0; i < jera.Nodes.Count; ++i)
            {
                if (jera.Nodes[i].FullPath.Equals(path))
                {
                    jera.Nodes[i].BackColor = Color.Red;
                    i = jera.Nodes.Count;
                }
                //recursivamente revisa para abajo.
                else
                {
                    if (jera.Nodes[i].Nodes.Count > 0)
                        seleccionarNodoSubArbol(jera.Nodes[i], path);
                }
            }
        }

        /// <summary>
        /// Asigna el padre MDI
        /// </summary>
        /// <param name="v"></param>
        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void buttonNuevoDetalle_Click(object sender, EventArgs e)
        {                                                                                                                                      //el 1 es de creacion
            FormFormulario formFormulario = new FormFormulario(this.IDFormSelecionado, this.IDExpediente, this.IDActividad, this.IDDatosSeleccionados, 1, this.IDComandoConfig, "", null, this.IDTupla);
            formFormulario.MdiParent = padreMDI;
            formFormulario.setPadreMDI(padreMDI);                           
            formFormulario.Show();
        }

        private void buttonVerDetalle_Click(object sender, EventArgs e)
        {
            FormFormulario formFormulario = new FormFormulario(this.IDFormSelecionado, this.IDExpediente, this.IDActividad, this.IDDatosSeleccionados, this.tipoComando, this.IDComandoConfig, "", null, -1);
            formFormulario.MdiParent = padreMDI;
            formFormulario.setPadreMDI(padreMDI);
            formFormulario.Show();
        }

        private void FormFormulario_Enter(object sender, EventArgs e)
        {
            llenarMaestroDetalle();
        }

        private void FormFormulario_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            llenarMaestroDetalle();
        }

    }
}