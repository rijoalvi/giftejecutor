using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace GiftEjecutor
{
    class Jerarquia
    {
        //instancia de la clase que realiza las consultas a la BD
        ConsultaJerarquia consultaBD;
        private String nombreJerarquia;
        private int IDJerarquia;
        private int IDNodoRaiz;
        private TreeView miArbol;

        public Jerarquia(int IDJera) {
            consultaBD = new ConsultaJerarquia();
            IDJerarquia = IDJera;            
            //obtiene el nombre de la jerarquia, al igual q el nodo raiz
            SqlDataReader datos = consultaBD.getDatosJerarquia(IDJerarquia);
            nombreJerarquia = datos.GetValue(0).ToString(); //nombre
            IDNodoRaiz = int.Parse(datos.GetValue(1).ToString()); //IDRaiz                
            miArbol = new TreeView();            
            llenarArbol();
        }
        
        private void llenarArbol(){
            if (!isJerarquiaVacia()) {            
                String IDsHijos;
                String[] trimIDsHijos;
                miArbol.Nodes.Clear();
                TreeNode nodoTemp;
                TreeNode raizArbol = new TreeNode(buscarNombreNodo(IDNodoRaiz));
                IDsHijos = buscarIDsHijos(IDNodoRaiz);
                trimIDsHijos = IDsHijos.Split(';');
                if (trimIDsHijos.Length > 1)
                {
                    //Mientras tenga hijos la raiz
                    for (int j = 0; j < trimIDsHijos.Length-1; ++j)
                    {
                        Console.WriteLine("IDsHijos: " + trimIDsHijos[j]);
                        nodoTemp = llenarSubArbol(int.Parse(trimIDsHijos[j]));
                        raizArbol.Nodes.Add(nodoTemp);                        
                    }
                }
                /*
                else {
                    //si solo tiene un hijo... ? o si no tiene hijos...? :s
                    MessageBox.Show("aqui NUNCA deberia de entrar!!! ...creo :p Beto");
                    nodoTemp = llenarSubArbol(int.Parse(trimIDsHijos[0]));
                    nodoTemp.Nodes.Add(nodoTemp);    
                }
                */
                //agrega al arbol el nodo raiz que ya tiene asociado todos sus hijos y los hijos de sus hijos
                miArbol.Nodes.Add(raizArbol);                
            }
        }

        public TreeNode llenarSubArbol(int ID)
        {
            String IDsHijos;
            String[] trimIDsHijos;
            TreeNode nodoActual;
            String nombre = buscarNombreNodo(ID);
            TreeNode nodoTemp;
            nodoActual = new TreeNode(nombre);
            IDsHijos = buscarIDsHijos(ID); //IDs hijos
            trimIDsHijos = IDsHijos.Split(';');
            if (trimIDsHijos.Length > 1)
            {
                for (int j = 0; j < trimIDsHijos.Length-1; ++j) { //Mientras tenga hijos el nodo
                    nodoTemp = llenarSubArbol(int.Parse(trimIDsHijos[j]));
                    nodoActual.Nodes.Add(nodoTemp); 
                }
            }
            return nodoActual;
        }

        /// <summary>
        /// Indica si la jerarquia esta vacia
        /// </summary>
        /// <returns></returns>
        private bool isJerarquiaVacia() {
            return consultaBD.isJerarquiaVacia(nombreJerarquia);
        }

        

        /// <summary>
        /// Devuelve el nombre del nodo indicado por el ID
        /// </summary>
        /// <param name="IDNodo"></param>
        /// <returns></returns>
        private String buscarNombreNodo(int IDNodo) {
            return consultaBD.buscarNombreNodo(IDNodo);
        }

        /// <summary>
        /// Devuelve los IDs de los nodos hijos.
        /// </summary>
        /// <param name="IDNodo"></param>
        /// <returns></returns>
        private String buscarIDsHijos(int IDNodo) {
            return consultaBD.getIDsHijos(IDNodo);
        }

        public TreeView getArbol() {
            return miArbol;
        }

    }
}
