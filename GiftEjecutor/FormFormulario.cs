using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormFormulario : Form
    {
        //Miembros
        public int IDForm; //ID del formulario con el q se esta trabajando
        public int IDExpediente; //ID del expediente al cual pertenecen los datos
        public Formulario miFormulario; //El objeto formulario que tiene todos los datos dl configurador
        

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
                        etiqueta.Text = miembro[1];
                        etiqueta.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        this.Controls.Add(etiqueta);
                        break;
                    case 1:
                        //Numero
                        string mascara = miFormulario.getMascaraNumero(int.Parse(miembro[10]));
                        MaskedTextBox numero = new MaskedTextBox(mascara);
                        numero.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        numero.TabIndex = int.Parse(miembro[11]);
                        this.Controls.Add(numero);
                        break;
                    case 2:
                        //Binario
                        RadioButton radio1 = new RadioButton();
                        radio1.Text = miembro[1];
                        radio1.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        radio1.TabIndex = int.Parse(miembro[11]);
                        this.Controls.Add(radio1);

                        //Agrega el otro radio
                        ++i;
                        miembro = miFormulario.getMiembro(i);
                        RadioButton radio2 = new RadioButton();
                        radio2.Text = miembro[1];
                        radio2.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        radio2.TabIndex = int.Parse(miembro[11]);
                        this.Controls.Add(radio2);

                        //Podrian meterse dentro de un panel, para asi poder tener varios grupos de radios por aparte sin q se anulen entre si...
                        //Ver aqui, la parte de "comentarios":
                        //http://msdn.microsoft.com/es-es/library/system.windows.forms.radiobutton%28VS.80%29.aspx
                        break;
                    case 3:
                        //FechaHora
                        DateTimePicker fecha = new DateTimePicker();
                        fecha.Text = miembro[1];
                        fecha.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        fecha.TabIndex = int.Parse(miembro[11]);
                        this.Controls.Add(fecha);
                        break;
                    case 4:
                        //Texto
                        TextBox texto = new TextBox();
                        string textoDefecto = miFormulario.getTextoDefecto(int.Parse(miembro[10]));
                        texto.Text = textoDefecto;
                        texto.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        texto.TabIndex = int.Parse(miembro[11]);
                        this.Controls.Add(texto);
                        break;
                    case 5:
                        //Incremental
                        TextBox incremental = new TextBox();
                        string valInicial = miFormulario.getValInicial(int.Parse(miembro[10]));
                        incremental.Text = valInicial;
                        incremental.SetBounds(int.Parse(miembro[2]), int.Parse(miembro[3]), int.Parse(miembro[4]), int.Parse(miembro[5]));
                        incremental.TabIndex = int.Parse(miembro[11]);
                        this.Controls.Add(incremental);
                        break;
                    case 6:
                        //Jerarquia
                      //  TreeView treeView1;
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
                    //    ComboBox comboBox1;
                        /* FALTA!!!!!!!!
                        campo = agregarTipoLista(nombre, id);
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
                    default:                         
                        break;
                }
            }

        }

    }
}