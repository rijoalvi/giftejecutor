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
    public partial class FormFormulario : Form
    {
        //Miembros
        private int IDForm; //ID del formulario con el q se esta trabajando
        private int IDExpediente; //ID del expediente al cual pertenecen los datos
        private int IDTupla;
        private int IDComandoConfig;
        private Formulario miFormulario; //El objeto formulario que tiene todos los datos dl configurador
     
        private Component[] componentes;
        private bool modificacion;
        private bool visualizacion;
        private bool eliminacion;
        private bool conMascara;
        private String[] nombresCamposTupla;


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
            conMascara = false;
            nombresCamposTupla = new String[miFormulario.getNumMiembros()];
            crearFormulario();
        }

        /// <summary>
        /// Constructor que abre un formulario que anteriormente fue llenado
        /// </summary>
        /// <param name="IDForm"></param>
        public FormFormulario(int IDFormulario, int IDExp, int IDdatos, int tipoComando, int IDComando, String datosConMascara)
        {
            InitializeComponent();
            IDForm = IDFormulario;
            IDTupla = IDdatos;
            IDExpediente = IDExp;
            IDComandoConfig = IDComando;
            miFormulario = new Formulario(IDForm);
            this.Text = miFormulario.getNombre();
            nombresCamposTupla = new String[miFormulario.getNumMiembros()];                     
            switch(tipoComando){
                case 1: //Creacion
                    InitializeComponent();                    
                    modificacion = false; //xq se va a crear una nueva tupla, no midificar otra
                    visualizacion = false; //no es comando d visualizar
                    eliminacion = false;
                    conMascara = false;
                    nombresCamposTupla = new String[miFormulario.getNumMiembros()];
                    crearFormulario();
                    break;
                case 2: //modificacion
                    modificacion = true; //xq se va a modificar una tupla, no crear una nueva
                    visualizacion = false; //no es comando d visualizar
                    eliminacion = false;
                    conMascara = false;
                    crearFormulario();
                    //llena los datos al leer la tupla especifica
                    llenarFormulario();
                    break;
                case 3: //visualizacion                    
                    modificacion = false;
                    visualizacion = true; //es comando d visualizar
                    eliminacion = false;
                    conMascara = false;
                    crearFormulario();
                    //llena los datos al leer la tupla especifica
                    llenarFormulario();
                    break;
                case 4: //borrado
                    modificacion = false;
                    visualizacion = true; //Es de borrado, pero esto es para hacer q sea de read-only
                    eliminacion = true;
                    conMascara = false;
                    crearFormulario();
                    //llena los datos al leer la tupla especifica
                    llenarFormulario();
                    botonAceptar.Text = "Borrar";
                    break;
                case 5: //con Mascara
                    modificacion = false;
                    visualizacion = true; //Es con mascara, pero esto es para hacer q sea de read-only
                    eliminacion = false;
                    conMascara = true;
                    crearFormulario();
                    //llena los datos al leer la tupla especifica
                    llenarFormulario();
                    botonAceptar.Visible = false;
                    botonCancelar.Text = "Cerrar";
                    MessageBox.Show("Este es el formulario resultante, luego de ejecutar el siguiente cambio del comando con máscara: \n"+ datosConMascara);
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
                        
                        TreeView jerarquia = new TreeView();
                        jerarquia.Name = miembro[1];
                        //componentes[i] = texto;
                        nombresCamposTupla[i] = miembro[1];
                        /* FALTA!!!!
                        campo = agregarTipoJerarquia(nombre, id);
                        actualizarComponente(textoDato.getText(), Integer.parseInt(valEjeX.getText()), Integer.parseInt(valEjeY.getText()), comboTipoLetra.getSelectedItem().toString(), colorDato.getForeground().getRGB(), Integer.parseInt(tamanoLetra.getText()), compEnUso.getWidth(), compEnUso.getHeight(), comboEstiloLetra.getSelectedItem().toString());
                        campo.setName("" + IDEnUso);
                        campo.addMouseListener(listener);
                        campo.addMouseMotionListener(motionListener);
                        frameVistaPrevia.add(campo);
                        campo.setBounds(valx, valy, 100, 20);
                        frameVistaPrevia.repaint();
                        componentes[tabIndex] = campo;
                        idsComponentes[tabIndex] = IDEnUso;
                         */ 
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
            } //Fin for que agrega miembros

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            //Si se va a modificar una tupla
            if (modificacion)
            {
                actualizarTupla();
                miFormulario.insertarEnBitacora(IDExpediente, -1, IDComandoConfig, 2, IDTupla, IDForm, true, "Se modificó la instancia del formulario "+ miFormulario.getNombre() + ".");
                this.Visible = false;
            }
            else 
            {
                if (eliminacion)
                {
                    miFormulario.eliminarTupla(IDTupla, miFormulario.getNombre());                    
                    miFormulario.insertarEnBitacora(IDExpediente, -1, IDComandoConfig, 3, IDTupla, IDForm, true, "Se eliminó la instancia del formulario "+ miFormulario.getNombre() + ".");
                    MessageBox.Show("¡Se eliminó correctamente la instancia seleccionada!"); 
                    this.Visible = false;
                }
                else
                {
                    if (visualizacion)
                    {
                        //no hace nada solo va a bitacora
                        miFormulario.insertarEnBitacora(IDExpediente, -1, IDComandoConfig, 3, IDTupla, IDForm, true, "Se visualizó la instancia del formulario" + miFormulario.getNombre() + ".");
                        this.Visible = false;
                    }
                    else //Si se va a crear una nueva tupla
                    {
                        //ingresa la tupla
                        ingresarNuevaTupla();
                        //ingresa el ingreso a la bitacora
                        miFormulario.insertarEnBitacora(IDExpediente, -1, IDComandoConfig, 1, IDTupla, IDForm, true, "Se agregó una nueva instancia del formulario " + miFormulario.getNombre() + ".");
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
            //insert into Vehiculo (Placa, Dueño, Estadoorden, Fecharecibido) 
            //Values(123456, 'Beto', 'recibido', '8-9-2009');
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
                        String laFecha = fecha.Value.ToString();
                        valoresCampos += "'" + laFecha.Substring(0, 10) + "'";
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
                        if ((i + 1) < cant)
                        {
                            valoresCampos += ", ";
                            nombresCampos += ", ";
                        }
                        break;
                    case 6:
                        //Jerarquia
                        /*
                        TreeView jera = (TreeView)(componentes[i]);
                        nombresCampos += jera.Name;
                        //este no sirve!!! ->
                        valoresCampos += "'"+ jera.Text.ToString()+"'";                        
                        if ((i+1) < cant )
                        {
                            valoresCampos += ", ";
                            nombresCampos += ", ";
                        } 
                        */
                        break;
                    case 7:
                        //Lista
                        ComboBox lista = (ComboBox)(componentes[i]);
                        nombresCampos += lista.Name;
                        valoresCampos += "'" + lista.SelectedItem.ToString() + "'";
                        //lista.SelectedText;
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
            valoresCampos += ")";
            nombresCampos += ") ";
            ingresoTupla += nombresCampos + valoresCampos;
            Console.WriteLine(ingresoTupla);
            IDTupla = miFormulario.insertarTuplaFormulario(ingresoTupla, nombreForm);            
        }

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
                        /*
                        TreeView jera = (TreeView)(componentes[i]);                        
                        //este no sirve!!! ->
                        consultaTupla += jera.Name " = '"+ jera.Text.ToString()+"'";                        
                        if ((i + 1) < cant)                        
                            consultaTupla += ", ";                                                  
                        */
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
                                /*
                                TreeView jera = (TreeView)(componentes[i]);                        
                                //este no sirve!!! ->
                                consultaTupla += jera.Name " = '"+ jera.Text.ToString()+"'";                        
                                jera.Text = datos.GetValue(valor).ToString();                                             
                                //si es comando d visualizacion
                                if (visualizacion)
                                    jera.ReadOnly = true;
                                 */
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

        /// <summary>
        /// Pone todos los componentes del formulario como "no editables"
        /// </summary>
        private void ponerSoloLectura() {
            for (int i = 0; i < componentes.Length; ++i) { 
               // componentes[i].
            }
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

    }
}