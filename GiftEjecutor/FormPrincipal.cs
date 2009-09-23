using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace GiftEjecutor
{
    public partial class FormPrincipal : Form
    {
        /**
         * Para recordar!!!
         * //Son los macros que se usan para seleccion del combo box.
         * static final int NUMERO = 1;
         * static final int BINARIO = 2;
         * static final int FECHAHORA = 3;
         * static final int TEXTO = 4;
         * static final int INCREMENTAL = 5;         
         * static final int JERARQUIA = 6
         * static final int LISTA = 7;
         * Hola muchachos!!!
         */
     
        
        
        
        
        public FormPrincipal()
        {
            InitializeComponent();
           
        }

        public FormPrincipal(int conexionSeleccionada)
        {
           //ControladorBD.conexionSelecciona = conexionSeleccionada;

            //ControladorBD.conexionConfiguracionSeleccionada = conexionConfiguradorSeleccionada;
            InitializeComponent();
            //refrescarDirectorio();            
        }
        
        private void constructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConstructor constructor = new FormConstructor();
            constructor.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int IDExpediente = 999;
            //int IDActividad = 19;

            int IDActividad = 32;
            FormActividad formActividad = new FormActividad(IDActividad, IDExpediente);
            formActividad.Show();
        }

        private void buttonActividad_Click(object sender, EventArgs e)
        {
            int IDExpediente = 999;
            int IDActividad = 1;
            FormListadoActividad formListadoActividad = new FormListadoActividad(IDActividad, IDExpediente);
            formListadoActividad.Show();
        }

        private void refrescarDirectorio() {
            directorio.Nodes.Clear();
            Coleccion coleccion = new Coleccion("Raiz"/*, 0*/);
            TreeNode nodo = this.directorio.Nodes.Add("0", "GIFT Ejecutor");

            TreeNode nodoPadre = this.directorio.Nodes.Find("0", false)[0];

            List<String[]> colecciones = coleccion.listarColecciones();
            List<String[]> expedientes = (new Expediente("0", 0, 0)).listarExpedientes();

            for (int i = 0; i < colecciones.Count; i++)
            {
                Console.WriteLine(colecciones[i][0] + colecciones[i][1] + colecciones[i][2]);
                int correlativoPadre = int.Parse(colecciones[i][2]);
                nodoPadre = buscarNodoPadre(colecciones[i][2], this.directorio.TopNode);//El correlativo es el key en el directorio
                nodo = nodoPadre.Nodes.Add(colecciones[i][0], colecciones[i][1]);
                for (int k = 0; k < expedientes.Count; k++)
                { //correlativo, IDFlujo, IDColeccion, nombre
                    if (int.Parse(nodo.Name) == int.Parse(expedientes[k][2]))
                    {//si la coleccion es igual a la coleccion a la que pertenece el expediente
                        nodo.Nodes.Add("e" + expedientes[k][1], expedientes[k][3]).ForeColor = Color.Silver; ;

                    }

                }
            }
        
        }

        private void botonActualizarTreeView_Click(object sender, EventArgs e)
        {
            refrescarDirectorio();
            /*directorio.Nodes.Clear();
            Coleccion coleccion = new Coleccion("Raiz"/*, 0*);
            TreeNode nodo = this.directorio.Nodes.Add("0","Raiz");

            TreeNode nodoPadre = this.directorio.Nodes.Find("0", false)[0];

            List<String[]> colecciones = coleccion.listarColecciones();
            List<String[]> expedientes = (new Expediente("0", 0,0)).listarExpedientes();

            for (int i = 0; i < colecciones.Count; i++) {
                Console.WriteLine(colecciones[i][0] + colecciones[i][1] + colecciones[i][2]);
                int correlativoPadre = int.Parse(colecciones[i][2]);
                nodoPadre = buscarNodoPadre(colecciones[i][2],this.directorio.TopNode);//El correlativo es el key en el directorio
                nodo = nodoPadre.Nodes.Add(colecciones[i][0], colecciones[i][1]);
                for (int k = 0; k < expedientes.Count; k++) { //correlativo, IDFlujo, IDColeccion, nombre
                    if(int.Parse(nodo.Name) == int.Parse(expedientes[k][2]) ){//si la coleccion es igual a la coleccion a la que pertenece el expediente
                        nodo.Nodes.Add("e" + expedientes[k][1], expedientes[k][3]).ForeColor = Color.Silver; ;

                    }
                
                }
            }/*
          /*  for (int i = 0; i < hijas.Length; i++)
            {
                nodo.Nodes.Add(hijas[i]);
            }*/
        }

        private TreeNode buscarNodoPadre(String correlativoPadre, TreeNode nodoActual) { 
            //int encontrado = 0;

            //int correlativoPadre = nodoBuscado[2];
            TreeNode nodoPadre = null;
            if(nodoActual.Name.Equals( correlativoPadre)){
                nodoPadre = nodoActual;
            }else if(nodoActual.Nodes.Find(correlativoPadre,false).Length>0){
                nodoPadre = nodoActual.Nodes.Find(correlativoPadre,false)[0];
            }else{
                int cantidadHijos = nodoActual.GetNodeCount(false);
                nodoActual = nodoActual.FirstNode;
                int i = 0;
                while (nodoPadre == null && i < cantidadHijos)
                {
                    nodoPadre = buscarNodoPadre(correlativoPadre, nodoActual);
                    nodoActual = nodoActual.NextNode;
                    i++;
                    /*while (!encontrado && y < arbol[x].Count)
                {
                    if (arbol[x][y][1] != nodoBuscado[2]) //SI EL CORRELATIVO DEL NODO EN EL ARBOL ES DIFERENTE AL CORRELATIVO DEL PADRE DEL NODO BUSCADO
                    {
                        nodoPadre.t
                    }
                    else {
                        encontrado = 1;
                    }
                }*/
                }
            }
            return nodoPadre;
        }

        private void actualizarDirectorio()
        {
            this.directorio.Nodes.Clear();
            Coleccion coleccion = new Coleccion("Raiz"/*, 0*/);
            TreeNode nodoActual = this.directorio.Nodes.Add("0","Raiz");
            TreeNode nodoPadre = this.directorio.Nodes.Find("0", false)[0];

            List<String[]> expedientes = (new Expediente("0")).listarExpedientes();
            List<String[]> colecciones = coleccion.listarColecciones();

            for (int i = 0; i < colecciones.Count; i++) {
                Console.WriteLine(colecciones[i][0] + colecciones[i][1] + colecciones[i][2]);
                int correlativoPadre = int.Parse(colecciones[i][2]);
                nodoPadre = buscarNodoPadre(colecciones[i][2],this.directorio.TopNode);//El correlativo es el key en el directorio
                nodoActual = nodoPadre.Nodes.Add(colecciones[i][0], colecciones[i][1]);
                /*Agregar los expedientes que pertenezcan a esta coleccion*/

                for (int k = 0; k < expedientes.Count; k++) {
                    if (int.Parse(expedientes[k][2]) == int.Parse(nodoActual.Name)) {
                        nodoActual.Nodes.Add("e" + expedientes[k][0].ToString(), expedientes[k][3].ToString()).ForeColor = Color.Silver;
                        expedientes.Remove(expedientes[k]);
                    }
                    
                }
            }
         /*   if (directorio.SelectedNode != null)
            {
                Console.Write(directorio.SelectedNode.FullPath);
                Console.Write(directorio.SelectedNode.Level);
                Console.Write(directorio.SelectedNode.Index);

                

                String nombre = directorio.SelectedNode.Text;
                //String nombrePadre = directorio.SelectedNode.FullPath;

                Coleccion coleccion = new Coleccion(nombre/*,0/);
                TreeNode nodo;
                nodo = directorio.SelectedNode;//this.directorio.Nodes.Add("Raiz");
                String[] hijas = coleccion.coleccionesHijas();
                if (hijas != null)
                    for (int i = 0; i < hijas.Length; i++)
                    {
                        nodo.Nodes.Add(hijas[i]);
                    }
                /*
                    node.Nodes.Insert(1, "1");
                this.directorio.Nodes.Insert(2, "2");
                this.directorio.Nodes.Insert(3, "3");
                this.directorio.Nodes.Insert(4, "4");*/
            
        }


        private void directorio_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //actualizarDirectorio();
        }

        private void agregarExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFlujosConstruidos flujosConstruidos = new FormFlujosConstruidos(directorio.SelectedNode.Name);
            flujosConstruidos.Show();

            //OJO!!!!!!!
            //ESTO NO VA AQUI!
            //Primero se escoje cual flujo quiere ejecutar, y desp se le pide a cual coleccion quiere agregarlo
            /*
            FormNuevoExpediente nuevaColeccion = new FormNuevoExpediente(this, this.directorio.SelectedNode.Name);
            nuevaColeccion.Show();
            */ 
        }

        private void agregarColeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNuevaColeccion c = new FormNuevaColeccion(this,this.directorio.SelectedNode.Name);
            c.Show();
        }

        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            refrescarDirectorio();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ComandoMascara cm = new ComandoMascara();
            cm.setAtributosComandoMascaraSegunID(8);
            MessageBox.Show(cm.ToString());


            ConsultaFormulario cf = new ConsultaFormulario();
            cf.actualizarUnCampoSegunID(1, "Vehiculo", "placa", "77777", "int");

            //ConsultaFormulario cf = new ConsultaFormulario();
            cf.actualizarUnCampoSegunID(1, "Vehiculo", "dueño", "cambiado", "varchar");
        }

        private void botonForm1_Click(object sender, EventArgs e)
        {
            FormFormulario c = new FormFormulario(1, 1, 1, 3, 2);
            c.Show();
            //FormFormulario(int IDFormulario)
        }


      /*  private void directorio_Click(object sender, EventArgs e)
        {
            actualizarDirectorio();
        }*/

        /*private void button3_Click(object sender, EventArgs e)
        {
            int IDExpediente = 999;
            int IDFlujo = 2;
            FormListadoActividad formListadoActividad = new FormListadoActividad(IDFlujo, IDExpediente);
            formListadoActividad.Show();
        }*/
    }
}