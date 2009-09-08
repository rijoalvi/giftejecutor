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
        private Formulario miFormulario; //El objeto formulario que tiene todos los datos dl configurador
     //   private System.Windows.Forms[] componentes;

        /// <summary>
        /// Constructor que abre un formulario creado en el constructor
        /// </summary>
        /// <param name="IDForm"></param>
        public FormFormulario(int IDFormulario)
        {
            InitializeComponent();
            IDForm = IDFormulario;
            miFormulario = new Formulario(IDForm);
            crearFormulario();
        }

        /// <summary>
        /// Encargado de armar el prototipo del formulario 
        /// </summary>
        public void crearFormulario() {

            int cant = miFormulario.getNumMiembros();
            //componentes = new System.Windows.Forms[cant];
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
                        this.Controls.Add(etiqueta);
                        break;
                    case 1:
                        //Numero
                        string mascara = miFormulario.getMascaraNumero(int.Parse(miembro[10]));
                        MaskedTextBox numero = new MaskedTextBox(mascara);
                        numero.Name = miembro[1];
                        numero.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        numero.TabIndex = int.Parse(miembro[11]);
                        //componentes[i] = numero;
                        this.Controls.Add(numero);
                        break;
                    case 2:
                        //Binario
                        RadioButton radio1 = new RadioButton();
                        radio1.Name = miembro[1];
                        radio1.Text = miembro[1];
                        radio1.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        radio1.TabIndex = int.Parse(miembro[11]);
                        //componentes[i] = radio1;
                        this.Controls.Add(radio1);

                        //Agrega el otro radio
                        ++i;
                        miembro = miFormulario.getMiembro(i);
                        RadioButton radio2 = new RadioButton();
                        radio2.Name = miembro[1];
                        radio2.Text = miembro[1];
                        radio2.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        radio2.TabIndex = int.Parse(miembro[11]);
                        //componentes[i] = radio2;
                        this.Controls.Add(radio2);

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
                        //componentes[i] = fecha;
                        this.Controls.Add(fecha);
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
                        //componentes[i] = texto;
                        this.Controls.Add(texto);
                        break;
                    case 5:
                        //Incremental
                        TextBox incremental = new TextBox();
                        incremental.Name = miembro[1];
                        string valInicial = miFormulario.getValInicial(int.Parse(miembro[10]));
                        incremental.Text = valInicial;
                        incremental.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        incremental.TabIndex = int.Parse(miembro[11]);
                        //componentes[i] = texto;
                        this.Controls.Add(incremental);
                        break;
                    case 6:
                        //Jerarquia
                        //0.correlativo, 1.nombre, 2.valX, 3.valY, 4.ancho, 5.alto, 6.tipoLetra, 7.color, 
                        //8.tamanoLetra, 9.IDTipoCampo, 10.IDCampo, 11.tabIndex, 12.estiloLetra
                        
                        TreeView jerarquia = new TreeView();
                        jerarquia.Name = miembro[1];
                        //componentes[i] = texto;
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
                        //componentes[i] = texto;
                        this.Controls.Add(comboBox);                        
                        break;
                    default:                         
                        break;
                }
            } //Fin for que agrega miembros

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            int cant = miFormulario.getNumMiembros();
            String[] miembro = new String[13];
            //0.correlativo, 1.nombre, 2.valX, 3.valY, 4.ancho, 5.alto, 6.tipoLetra, 7.color, 
            //8.tamanoLetra, 9.IDTipoCampo, 10.IDCampo, 11.tabIndex, 12.estiloLetra
            for (int i = 0; i < cant; i++)
            {
                miembro = miFormulario.getMiembro(i);
                int tipoCampo = int.Parse(miembro[9]);
                //Mientras no sea una etiqueta
                if (tipoCampo != 0) { 
                    
                }
            }
        }

    }
}