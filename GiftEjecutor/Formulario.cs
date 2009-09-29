using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
namespace GiftEjecutor
{
    

    public class Formulario
    {
        //Miembros
        private ConsultaFormulario consultaBD;
        private DataTable miembrosFormulario;
        private String nombre;
        private int IDForm;

        /// <summary>
        /// Constructor que indica el ID del formulario
        /// </summary>
        public Formulario(int IDFormulario)
        {
            consultaBD = new ConsultaFormulario();
            IDForm = IDFormulario;
            nombre = consultaBD.getNombreFormulario(IDForm);
            getTodosLosMiembros();            
        }

        /// <summary>
        /// Busca en la BD todos los miembros del formulario y los guarda en un dataTable
        /// </summary>
        public void getTodosLosMiembros() {
            object datos = consultaBD.getDatosFormulario(IDForm);

            miembrosFormulario = new DataTable();
            DataRow fila;
            DataColumn correlativo = new DataColumn();
            DataColumn nombre = new DataColumn();
            DataColumn valX = new DataColumn();
            DataColumn valY = new DataColumn();
            DataColumn ancho = new DataColumn();
            DataColumn alto = new DataColumn();
            DataColumn tipoLetra = new DataColumn();
            DataColumn color = new DataColumn();
            DataColumn tamanoLetra = new DataColumn();            
            DataColumn IDTipoCampo = new DataColumn();
            DataColumn IDCampo = new DataColumn();
            DataColumn tabIndex = new DataColumn();
            DataColumn estiloLetra = new DataColumn();

            correlativo.ColumnName = "correlativo";
            correlativo.DataType = Type.GetType("System.String");
            nombre.ColumnName = "nombre";
            nombre.DataType = Type.GetType("System.String");
            valX.ColumnName = "valX";
            valX.DataType = Type.GetType("System.String");    
            valY.ColumnName = "valY";
            valY.DataType = Type.GetType("System.String");
            ancho.ColumnName = "ancho";
            ancho.DataType = Type.GetType("System.String");
            alto.ColumnName = "alto";
            alto.DataType = Type.GetType("System.String");    
            tipoLetra.ColumnName = "tipoLetra";
            tipoLetra.DataType = Type.GetType("System.String");
            color.ColumnName = "color";
            color.DataType = Type.GetType("System.String");
            tamanoLetra.ColumnName = "tamanoLetra";
            tamanoLetra.DataType = Type.GetType("System.String");    
            IDTipoCampo.ColumnName = "IDTipoCampo";
            IDTipoCampo.DataType = Type.GetType("System.String");
            IDCampo.ColumnName = "IDCampo";
            IDCampo.DataType = Type.GetType("System.String");
            tabIndex.ColumnName = "tabIndex";
            tabIndex.DataType = Type.GetType("System.String");
            estiloLetra.ColumnName = "estiloLetra";
            estiloLetra.DataType = Type.GetType("System.String");

            miembrosFormulario.Columns.Add(correlativo);
            miembrosFormulario.Columns.Add(nombre);
            miembrosFormulario.Columns.Add(valX);
            miembrosFormulario.Columns.Add(valY);
            miembrosFormulario.Columns.Add(ancho);
            miembrosFormulario.Columns.Add(alto);
            miembrosFormulario.Columns.Add(tipoLetra);
            miembrosFormulario.Columns.Add(color);
            miembrosFormulario.Columns.Add(tamanoLetra);
            miembrosFormulario.Columns.Add(IDTipoCampo);
            miembrosFormulario.Columns.Add(IDCampo);
            miembrosFormulario.Columns.Add(tabIndex);
            miembrosFormulario.Columns.Add(estiloLetra);
            if (datos != null)
            {
                //Console.WriteLine("entre");
               // if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
               // {
                    while (((SqlDataReader)(datos)).Read())
                    {
                        fila = miembrosFormulario.NewRow();
                        fila["correlativo"] = ((SqlDataReader)(datos)).GetValue(0); 
                        fila["nombre"] = ((SqlDataReader)(datos)).GetValue(1);                        
                        fila["valX"] = ((SqlDataReader)(datos)).GetValue(2);
                        fila["valY"] = ((SqlDataReader)(datos)).GetValue(3);                        
                        fila["ancho"] = ((SqlDataReader)(datos)).GetValue(4);
                        fila["alto"] = ((SqlDataReader)(datos)).GetValue(5);                        
                        fila["tipoLetra"] = ((SqlDataReader)(datos)).GetValue(6);
                        fila["color"] = ((SqlDataReader)(datos)).GetValue(7);                        
                        fila["tamanoLetra"] = ((SqlDataReader)(datos)).GetValue(8);
                        fila["IDTipoCampo"] = ((SqlDataReader)(datos)).GetValue(9); 
                        fila["IDCampo"] = ((SqlDataReader)(datos)).GetValue(10);                        
                        fila["tabIndex"] = ((SqlDataReader)(datos)).GetValue(11);
                        fila["estiloLetra"] = ((SqlDataReader)(datos)).GetValue(12);
                        miembrosFormulario.Rows.Add(fila);
                    }
                /*}
                else
                {
                    if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona)
                    {
                        while (((MySqlDataReader)(datos)).Read())
                        {
                            fila = miembrosFormulario.NewRow();
                            fila["correlativo"] = ((MySqlDataReader)(datos)).GetValue(0); 
                            fila["nombre"] = ((MySqlDataReader)(datos)).GetValue(1);                        
                            fila["valX"] = ((MySqlDataReader)(datos)).GetValue(2);
                            fila["valY"] = ((MySqlDataReader)(datos)).GetValue(3);                        
                            fila["ancho"] = ((MySqlDataReader)(datos)).GetValue(4);
                            fila["alto"] = ((MySqlDataReader)(datos)).GetValue(5);                        
                            fila["tipoLetra"] = ((MySqlDataReader)(datos)).GetValue(6);
                            fila["color"] = ((MySqlDataReader)(datos)).GetValue(7);                        
                            fila["tamanoLetra"] = ((MySqlDataReader)(datos)).GetValue(8);
                            fila["IDTipoCampo"] = ((MySqlDataReader)(datos)).GetValue(9); 
                            fila["IDCampo"] = ((MySqlDataReader)(datos)).GetValue(10);                        
                            fila["tabIndex"] = ((MySqlDataReader)(datos)).GetValue(11);
                            fila["estiloLetra"] = ((MySqlDataReader)(datos)).GetValue(12);
                            miembrosFormulario.Rows.Add(fila);
                        }
                    }
                } */
            } //Termina la lectura d los datos hacia el dataTable
        } //fin método

        /// <summary>
        /// Devuelve todos los datos de un miembro como un vector de Strings...
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public String[] getMiembro(int index) {
            String[] miembro = new String[13];
            String[] valores = {"correlativo", "nombre", "valX", "valY", "ancho", "alto", "tipoLetra", "color", "tamanoLetra", "IDTipoCampo", "IDCampo", "tabIndex", "estiloLetra"};
            for(int i = 0; i < 13; ++i){
                miembro[i] = miembrosFormulario.Rows[index][valores[i]].ToString();                
                //Console.WriteLine(miembro[i]);
            }

            return miembro;
        }

        /// <summary>
        /// Indica la cantidad de miembros que posee el formulario
        /// </summary>
        /// <returns></returns>
        public int getNumMiembros(){
            return miembrosFormulario.Rows.Count;
        }

        /// <summary>
        /// Devuelve la mascara del tipoCampo numero indicado por el parametro
        /// </summary>
        /// <param name="IDCampo"></param>
        /// <returns></returns>
        public String getMascaraNumero(int IDCampo){
            return consultaBD.getMascaraNumero(IDCampo);
        }

        /// <summary>
        /// Devuelve el texto por defecto del Campo especifico
        /// </summary>
        /// <param name="IDCampo"></param>
        /// <returns></returns>
        public String getTextoDefecto(int IDCampo){
            return consultaBD.getTextoDefecto(IDCampo);
        }

        public String getValInicial(int IDCampo){
            return consultaBD.getValInicialIncremental(IDCampo);
        }

        /// <summary>
        /// Devuelve un vector de strings con todos los diferentes valores de los miembros de la lista
        /// </summary>
        /// <param name="IDCampo"></param>
        /// <returns></returns>
        public String[] getMiembrosLista(int IDCampo) {
            object datos = consultaBD.getMiembrosLista(IDCampo);
            
            DataTable miembrosLista = new DataTable();
            DataRow fila;
            DataColumn valor = new DataColumn();
            
            valor.ColumnName = "valor";
            valor.DataType = Type.GetType("System.String");

            miembrosLista.Columns.Add(valor);
            if (datos != null)
            {
                while (((SqlDataReader)(datos)).Read())
                {
                    fila = miembrosLista.NewRow();
                    fila["valor"] = ((SqlDataReader)(datos)).GetValue(0);
                    miembrosLista.Rows.Add(fila);
                }
            }

            int count = miembrosLista.Rows.Count;
            String[] miembros = new String[count];
            for (int i = 0; i < count; ++i)
            {
                miembros[i] = miembrosLista.Rows[i]["valor"].ToString();
                Console.WriteLine(miembros[i]);
            }
            return miembros;
        }

        public int getMaxLengthTexto(int IDCampo) {
            return consultaBD.getMaxLengthTexto(IDCampo);
        }

        public String getNombre() {
            return nombre;
        }

        public SqlDataReader ejecutarConsultaConfigurador(String consulta)
        {
            return consultaBD.ejecutarConsultaConfigurador(consulta);
        }

        public SqlDataReader ejecutarConsultaEjecutor(String consulta)
        {
            return consultaBD.ejecutarConsultaEjecutor(consulta);
        }

        public int insertarTuplaFormulario(String ingresoTupla, String nombreTabla)
        {
            return consultaBD.insertarInstanciaFormulario(ingresoTupla, nombreTabla);
        }

        public SqlDataReader insertarEnBitacora(int IDExp, int IDAct, int IDCom, int tipoCom, int IDInstForm, int IDFormConfig, bool ejec, String descripcion)
        {
            return consultaBD.insertarEnBitacora(IDExp, IDAct, IDCom, tipoCom, IDInstForm, IDFormConfig, ejec, descripcion);
        }

        /// <summary>
        /// Elimina una tupla de la tabla del formulario indicado.
        /// </summary>
        /// <param name="IDTupla"></param>
        /// <param name="nombreFormulario"></param>
        /// <returns></returns>
        public SqlDataReader eliminarTupla(int IDTupla, String nombreFormulario) { 
            return consultaBD.eliminarTupla(IDTupla, nombreFormulario);
        }
        
    }
}
