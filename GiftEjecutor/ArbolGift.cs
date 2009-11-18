using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
namespace GiftEjecutor
{
    
    
    class ArbolGift
    {
        private TreeView directorio;
        private Usuario usuario;
        private Perfil perfil;
        public ArbolGift(TreeView directorio,Usuario usuario) {
            this.directorio = directorio;
            this.usuario = usuario;
            this.perfil = new Perfil(usuario.getCorrelativoPerfil());

        }

        public void setUsuario(Usuario usuario){
            this.usuario = usuario;
        }

        public Coleccion coleccionSeleccionada() { 
            Coleccion coleccion = null;
            if (directorio.SelectedNode != null && !(directorio.SelectedNode.Name.Contains("F") || directorio.SelectedNode.Name.Equals("0") || directorio.SelectedNode.Name.Contains("E")))
            {
                coleccion = (Coleccion)directorio.SelectedNode.Tag;
            }
            return coleccion;
        }

        public FlujoTrabajo flujoSeleccionado() {
            FlujoTrabajo flujo = null;
            if (directorio.SelectedNode!=null && this.directorio.SelectedNode.Name.Contains("F")) {
                flujo = (FlujoTrabajo)directorio.SelectedNode.Tag;
            }
            return flujo;
        }

        public Expediente expedienteSeleccionado() {
            Expediente exp = null;
            if (directorio.SelectedNode!=null && directorio.SelectedNode.Name.Contains("E")) {
                exp = (Expediente)directorio.SelectedNode.Tag;
            }
            return exp;
        }

        public void refrescar()
        {
            directorio.Nodes.Clear();
            Coleccion coleccion = new Coleccion("GIFT Ejecutor"/*, 0*/);
            TreeNode nodo = this.directorio.Nodes.Add("0", "GIFT Ejecutor");
            this.directorio.TopNode = nodo;

            List<Coleccion> coleccionesPerfil = perfil.obtenerColecciones();

            TreeNode nodoPadre = this.directorio.Nodes.Find("0", false)[0];
            TreeNode nodoFlujo;
            
            DataTable tablaFlujos = (new FlujoTrabajo()).getFlujosConstruidos();
            
            List<String[]> colecciones = coleccion.listarColecciones();
            /*  coleccion[0] Obtiene el correlativo,           coleccion[1] Obtiene el nombre
                coleccion[2] Obtiene el correlativo del padre, coleccion[3] Obtiene el correlativo del flujo al que pertenece*/


            List<String[]> expedientes = (new Expediente("0", 0, 0)).listarExpedientes();
            //expediente[0] Obtiene el correlativo,                    expediente[1] Obtiene el IDFlujo
            //expediente[2] Obtiene el IDColeccion a la que pertenece, expediente[3] Obtiene el nombre del expediente
                Boolean encontrado;
            
            if (usuario.getTipo() != 0)//!Admnistrador
            {
                for (int i = 0; i < expedientes.Count; i++) {
                    encontrado=false;
                    int []idExp = usuario.getIDsExpedientes();
                    for (int k = 0; !encontrado && idExp!=null && k < idExp.Length; k++) {
                        if (usuario.getIDsExpedientes()[k] == int.Parse(expedientes[i][0]))
                            encontrado = true;
                    }
                    if (!encontrado) {
                        expedientes.RemoveAt(i);
                        i--;
                    }

                }
            }

            
            for (int j = 0; j < tablaFlujos.Rows.Count; j++)
            {
                encontrado= usuario.getTipo()!=0? false : true;

                for (int k = 0; !encontrado && k < expedientes.Count; k++) 
                    if (tablaFlujos.Rows[j]["IDFlujo"].ToString().Equals(expedientes[k][1].ToString()))
                        encontrado = true;
                for(int l=0;!encontrado && l<coleccionesPerfil.Count;l++)
                    if(tablaFlujos.Rows[j]["IDFlujo"].ToString().Equals(coleccionesPerfil[l].getCorrelativoFlujo().ToString()))
                        encontrado = true;
                
                if (encontrado)
                {
                    nodoFlujo = nodo.Nodes.Add("F" + tablaFlujos.Rows[j]["IDFlujo"].ToString(), tablaFlujos.Rows[j]["nombre"].ToString());
                    nodoFlujo.Tag = new FlujoTrabajo(int.Parse(tablaFlujos.Rows[j]["IDFlujo"].ToString()), tablaFlujos.Rows[j]["nombre"].ToString(), "");
                    nodoFlujo.ForeColor = Color.Blue;
                }
                else {                                                  //Si no esta el flujo elimino las colecciones de ese flujo
                    for (int l = 0;l < colecciones.Count; l++) { 
                        if(colecciones[l][3].ToString().Equals(tablaFlujos.Rows[j]["IDFlujo"].ToString())){
                            colecciones.RemoveAt(l);
                            l--;
                        }
                    }
                }
                    
            }

  

            for (int i = 0; i < colecciones.Count; i++)
            {
                Console.WriteLine(colecciones[i][0] + colecciones[i][1] + colecciones[i][2]);

                int correlativoPadre = int.Parse(colecciones[i][2]);
                if (correlativoPadre == 0)
                {
                    nodoPadre = buscarNodoFlujo(colecciones[i][3]);
                }
                else
                {
                    nodoPadre = buscarNodoPadre(colecciones[i][2], this.directorio.TopNode);//El correlativo es el key en el directorio
                }

                if (nodoPadre != null)
                {
                    nodo = nodoPadre.Nodes.Add(colecciones[i][0], colecciones[i][1]);// "F" + colecciones[i][3];
                    nodo.Tag = new Coleccion(int.Parse(colecciones[i][0].ToString()), colecciones[i][1], int.Parse(colecciones[i][2].ToString()), int.Parse(colecciones[i][3]));
                    Boolean valido = false;
                    for (int k = 0; !valido && k < coleccionesPerfil.Count; k++)
                        if (colecciones[i][0].Equals(coleccionesPerfil[k].getCorrelativo().ToString()))
                            valido = true;
                    if (!valido&&usuario.getTipo()!=0) {
                        nodo.Remove();
                    }
                }
                else
                {
                    Console.WriteLine("No se encuentra el flujo de trabajo al que pertenece la colección " + colecciones[i][1]);
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
                        Expediente expedienteCreado = new Expediente(expedientes[k][3], int.Parse(nodo.Name), int.Parse(expedientes[k][1]));
                        int finalizado = expedienteCreado.yaFinalizado();
                        if (finalizado == 1)
                        {
                            creado.ForeColor = Color.Red;
                            creado.Text += " (Finalizado)";
                        }
                        else
                        {
                            creado.ForeColor = Color.Silver;
                        }
                        creado.Tag = expedienteCreado;
                    }
                }
            }
            directorio.ExpandAll();
        }

        private TreeNode buscarNodoFlujo(String correlativoFlujo)
        {
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

        private TreeNode buscarNodoPadre(String correlativoPadre, TreeNode nodoActual)
        {
            //int encontrado = 0;

            //int correlativoPadre = nodoBuscado[2];
            TreeNode nodoPadre = null;
            //if (nodoActual.Name.Equals("0") && nodoActual.Tag != null && ("F" + ((FlujoTrabajo)nodoActual.Tag).getCorrelativo()).Equals(correlativoPadre))
            //if (nodoActual.Name.Contains("F") && nodoActual.Tag != null && (/*"F" + */((FlujoTrabajo)nodoActual.Tag).getCorrelativo()).ToString().Equals(correlativoPadre))
            /*if(correlativoPadre.Equals("0") && 
            {
                Console.WriteLine("nodo hijo del flujo "+nodoActual.Name.ToString());
            }else */
            if (nodoActual.Name.Equals(correlativoPadre) && correlativoPadre != "0")
            {
                nodoPadre = nodoActual;
            }
            else if (nodoActual.Nodes.Find(correlativoPadre, false).Length > 0)
            {
                nodoPadre = nodoActual.Nodes.Find(correlativoPadre, false)[0];
            }
            else
            {
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

        private TreeNode nodoSeleccionado() {
            return directorio.SelectedNode;
        }

        public Boolean hayNodoSeleccionado() {
            Boolean seleccionado = true;
            if (directorio.SelectedNode == null) {
                seleccionado = false;
            }
            return seleccionado;
        }
    }
}
