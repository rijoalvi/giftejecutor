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
        private Ventanota padreMDI;
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
            constructor.MdiParent = padreMDI;
            constructor.setPadreMDI(padreMDI);
            constructor.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void buttonActividad_Click(object sender, EventArgs e)
        {
            int IDExpediente = 13;
            int IDFlujo = 4;
            FormListadoActividad formListadoActividad = new FormListadoActividad(IDFlujo, IDExpediente, true);
            formListadoActividad.MdiParent = padreMDI;
            formListadoActividad.setPadreMDI(padreMDI);
            formListadoActividad.Show();
        }

        public void refrescarDirectorio() {
            directorio.Nodes.Clear();
            Coleccion coleccion = new Coleccion("GIFT Ejecutor"/*, 0*/);
            TreeNode nodo = this.directorio.Nodes.Add("0", "GIFT Ejecutor");

            TreeNode nodoPadre = this.directorio.Nodes.Find("0", false)[0];
            TreeNode nodoFlujo;
            /**
             
             * */
            
            DataTable tablaFlujos = (new FlujoTrabajo()).getFlujosConstruidos();
            List<String[]> colecciones = coleccion.listarColecciones();
            /*  coleccion[0] Obtiene el correlativo,           coleccion[1] Obtiene el nombre
                coleccion[2] Obtiene el correlativo del padre, coleccion[3] Obtiene el correlativo del flujo al que pertenece*/

            
            List<String[]> expedientes = (new Expediente("0", 0, 0)).listarExpedientes();
            //expediente[0] Obtiene el correlativo,                    expediente[1] Obtiene el IDFlujo
            //expediente[2] Obtiene el IDColeccion a la que pertenece, expediente[3] Obtiene el nombre del expediente

            for (int j = 0; j < tablaFlujos.Rows.Count; j++)
            {
                nodoFlujo = nodo.Nodes.Add("F" + tablaFlujos.Rows[j]["IDFlujo"].ToString(), tablaFlujos.Rows[j]["nombre"].ToString());
                nodoFlujo.Tag = new FlujoTrabajo(int.Parse(tablaFlujos.Rows[j]["IDFlujo"].ToString()), tablaFlujos.Rows[j]["nombre"].ToString(), "");
                nodoFlujo.ForeColor = Color.Blue;
            }
            for (int i = 0; i < colecciones.Count; i++)
            {
                Console.WriteLine(colecciones[i][0] + colecciones[i][1] + colecciones[i][2]);
                
                int correlativoPadre = int.Parse(colecciones[i][2]);
                if(correlativoPadre == 0){
                    nodoPadre = buscarNodoFlujo(colecciones[i][3]);
                }else{
                    nodoPadre = buscarNodoPadre(colecciones[i][2], this.directorio.TopNode);//El correlativo es el key en el directorio
                }
                
                if (nodoPadre != null)
                {
                    nodo = nodoPadre.Nodes.Add(colecciones[i][0], colecciones[i][1]);// "F" + colecciones[i][3];
                    nodo.Tag = new Coleccion(colecciones[i][0], int.Parse(colecciones[i][2].ToString()), int.Parse(colecciones[i][3]));
                }
                else { 
                    Console.WriteLine("No se encuentra el flujo de trabajo al que pertenece la colección "+colecciones[i][1]);
                    colecciones.Remove(colecciones[i]);
                    nodo = null;
                }

                /*String correlativoFlujo;
                String correlativoPadre;
                if (nodoPadre.Name.Contains("F"))
                {
                    correlativoFlujo = nodoPadre.Name.Substring(1);
                    correlativoPadre = "0";
                }else {
                    correlativoFlujo = ((Coleccion)nodoPadre.Tag).getCorrelativoFlujo().ToString();
                    correlativoPadre = nodoPadre.Name;
                }*/
                //nodo.Tag = new Coleccion(colecciones[i][0] , int.Parse(colecciones[i][2].ToString()),nodoPadre.);
                
              //  ((Coleccion)nodo.Tag).setCorrelativoFlujo(int.Parse(colecciones[i][3].ToString()));
                for (int k = 0; k < expedientes.Count; k++)
                {
                    if (nodo != null && int.Parse(nodo.Name) == int.Parse(expedientes[k][2]))
                    {   //si la coleccion es igual a la coleccion a la que pertenece el expediente
                        TreeNode creado = nodo.Nodes.Add("E" + expedientes[k][0], expedientes[k][3]);
                        creado.ForeColor = Color.Silver;                        
                        creado.Tag = new Expediente(expedientes[k][3], int.Parse(nodo.Name), int.Parse(expedientes[k][1]));
                    }
                }
            }        
        }

        private TreeNode buscarNodoFlujo(String correlativoFlujo) {
            TreeNode nodoActual = directorio.TopNode;
            int cantidadHijos = nodoActual.GetNodeCount(false);  
            nodoActual = nodoActual.FirstNode;
            int i = 0;
            TreeNode nodoPadre = null;
            while (nodoPadre == null && i < cantidadHijos)
            {
                //nodoPadre = buscarNodoPadre(correlativoPadre, nodoActual);
                if (nodoActual.Name.Equals("F" + correlativoFlujo))
                {
                    nodoPadre = nodoActual;
                }
                else
                {
                    nodoActual = nodoActual.NextNode;
                    i++;
                }
            }
            return nodoPadre;
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
            //if (nodoActual.Name.Equals("0") && nodoActual.Tag != null && ("F" + ((FlujoTrabajo)nodoActual.Tag).getCorrelativo()).Equals(correlativoPadre))
            //if (nodoActual.Name.Contains("F") && nodoActual.Tag != null && (/*"F" + */((FlujoTrabajo)nodoActual.Tag).getCorrelativo()).ToString().Equals(correlativoPadre))
            /*if(correlativoPadre.Equals("0") && 
            {
                Console.WriteLine("nodo hijo del flujo "+nodoActual.Name.ToString());
            }else */
            if(nodoActual.Name.Equals(correlativoPadre) && correlativoPadre != "0"){
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

      


        private void directorio_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // refrescarDirectorio();
        }

        private void agregarExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (directorio.SelectedNode != null)
            {

                if (directorio.SelectedNode.Name.Contains("F") || directorio.SelectedNode.Name.Equals("0")||directorio.SelectedNode.Name.Contains("E"))
                {
                    MessageBox.Show("Solo se pueden crear expedientes dentro de una coleccion");
                }
                else
                {
                    String correlativoPadre = directorio.SelectedNode.Name;
                    String correlativoFlujo = ((Coleccion)directorio.SelectedNode.Tag).getCorrelativoFlujo().ToString();
                    FormFlujosConstruidos flujosConstruidos = new FormFlujosConstruidos(this, correlativoPadre, correlativoFlujo);
                    flujosConstruidos.MdiParent = padreMDI;
                    flujosConstruidos.setPadreMDI(padreMDI);
                    flujosConstruidos.Show();
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar el Flujo de trabajos o la colección en la que se creará la colección en el directorio");
            }
        }

        private void agregarColeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.directorio.SelectedNode != null)
            {
                String correlativoFlujo;
                String correlativoPadre;
                if (this.directorio.SelectedNode.Name.Contains("F"))
                {
                    correlativoFlujo = directorio.SelectedNode.Name.Substring(1);
                    correlativoPadre = "0";
                    FormNuevaColeccion c = new FormNuevaColeccion(this, correlativoPadre, correlativoFlujo);
                    c.MdiParent = padreMDI;
                    c.setPadreMDI(padreMDI);
                    c.Show();
                }
                else if (!this.directorio.SelectedNode.Name.Contains("E") && !this.directorio.SelectedNode.Name.Equals("0"))
                {
                    correlativoFlujo = ((Coleccion)directorio.SelectedNode.Tag).getCorrelativoFlujo().ToString();
                    correlativoPadre = directorio.SelectedNode.Name;
                    FormNuevaColeccion c = new FormNuevaColeccion(this, correlativoPadre, correlativoFlujo);
                    c.MdiParent=padreMDI;
                    c.setPadreMDI(padreMDI);
                    c.Show();
                }
                else
                {
                    MessageBox.Show("Solo es posible crear Colecciones dentro de un Flujo de trabajo o dentro de otra Colección");
                }
            }
            else {
                MessageBox.Show("Se debe seleccionar el Flujo de trabajos o la colección en la que se creará la colección en el directorio");
            }
            
        }

        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            refrescarDirectorio();
        }

        private void cambiarNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String correlativoFlujo;
            String correlativoPadre;
            if (this.directorio.SelectedNode.Name.Contains("F"))
            {
                MessageBox.Show("No es posible cambiarle el nombre a un flujo de trabajo");
            }
            else if (this.directorio.SelectedNode.Name.Equals("0"))
            {
                MessageBox.Show("No es posible cambiarle el nombre a la raíz del directorio");
            }else if (this.directorio.SelectedNode.Name.Contains("E"))
            {
                correlativoFlujo = ((Expediente)directorio.SelectedNode.Tag).getCorrelativoFlujo().ToString();
                correlativoPadre = ((Expediente)directorio.SelectedNode.Tag).getCorrelativoColeccion().ToString();
                String correlativoExpediente = ((Expediente)directorio.SelectedNode.Tag).getCorrelativo().ToString();
                FormFlujosConstruidos form = new FormFlujosConstruidos(this,correlativoExpediente,correlativoPadre,correlativoFlujo);
                form.MdiParent=padreMDI;
                form.setPadreMDI(padreMDI);
                form.Show();
            }
            else
            {
                correlativoFlujo = ((Coleccion)directorio.SelectedNode.Tag).getCorrelativoFlujo().ToString();
                correlativoPadre = directorio.SelectedNode.Name;
                FormNuevaColeccion coleccion = new FormNuevaColeccion(this, int.Parse(this.directorio.SelectedNode.Name));
                coleccion.MdiParent=padreMDI;
                coleccion.setPadreMDI(padreMDI);
                coleccion.Show();
            }
            
        }

        private void botonPruebaBitacora_Click(object sender, EventArgs e)
        {
            FormVistaBitacora bit = new FormVistaBitacora(999);
            bit.MdiParent=padreMDI;
            bit.setPadreMDI(padreMDI);
            bit.Show();
        }

        private void directorio_DoubleClick(object sender, EventArgs e)
        {
            abrirExpediente();
        }

        private void abrirExpediente() {
            TreeNode seleccionado = directorio.SelectedNode;
            if (seleccionado != null && seleccionado.Name.Contains("E"))
            {
                //MessageBox.Show("Se selecciono el Expediente " + directorio.SelectedNode.Name+" "+directorio.SelectedNode.Text);
               
                int correlativoFlujo = ((Expediente)seleccionado.Tag).getCorrelativoFlujo();
                //MessageBox.Show("Correlativo Flujo" + correlativoFlujo);
                int correlativoExpediente = ((Expediente)seleccionado.Tag).getCorrelativo();
                //MessageBox.Show("correlativo expediente " + correlativoExpediente);
                FormListadoActividad actividad = new FormListadoActividad(correlativoFlujo, correlativoExpediente, true);
                actividad.MdiParent=padreMDI;
                actividad.setPadreMDI(padreMDI);
                actividad.Show();
            }
            
        }

        private void eliminarBETAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode seleccionado = directorio.SelectedNode;
            if (seleccionado != null && seleccionado.Name.Contains("E")) {
                FormEliminar eliminar = new FormEliminar(this,((Expediente)seleccionado.Tag).getNombre(),seleccionado.Name.Substring(1),"Expediente");
                eliminar.MdiParent = padreMDI;
                eliminar.setPadreMDI(padreMDI);
                eliminar.Show();
            }
        }
        
        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActividadCompuesta ac = new ActividadCompuesta();
            ac.setAtributosSegunID(38);
            MessageBox.Show(ac.ToString());
            FormListadoActividad fa = new FormListadoActividad(38, 999, false);
            fa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormFormulario formFormulario = new FormFormulario(4, 1, 1, 0, 2, 1,"", null);
            //FormFormulario formFormulario = new FormFormulario(IDFormulario, IDExpediente, IDActividad, IDTupla, tipoComando, IDComando, "", miPadre);
            formFormulario.Show();
        }
    }
}