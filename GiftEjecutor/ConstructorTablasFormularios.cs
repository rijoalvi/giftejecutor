using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace GiftEjecutor
{
    class ConstructorTablasFormularios
    {
        ConsultaConstructorTablasFormularios consultaBD;

        public ConstructorTablasFormularios()
        {
            //consultaBD = ConsultaConstructorTablasFormularios.getInstancia();
            consultaBD = new ConsultaConstructorTablasFormularios();
        }

        public void construirTablas(String IDWorkflow) {
        
            //se busca en la BD configurador entre los formularios cuales pertenecen al flujo
            //puede ser crear un string dnd cada ';' sea un nuevo form

            //Esto es temporeal, el parametro dbe pasar el ID del workflow...
            String[] IDsFormularios = buscarFormularios(IDWorkflow);
            String nombreFormulario = "";
            
            //se dividen todos esos formularios y a cada uno se le investiga los campos q tienen
            //busca para cada formulario
            for (int i = 0; i < IDsFormularios.Length; ++i)
            {
                if (IDsFormularios[i] != null)
                {
                    String consultaCreaTabla = "CREATE TABLE ";
                    //Busca el nombre del formulario y lo agrega a la consulta
                    nombreFormulario = consultaBD.getNombreFormulario(IDsFormularios[i]);
                    consultaCreaTabla += nombreFormulario;
                    /*if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona) //MYSQL
                    {
                        consultaCreaTabla += "( correlativo int auto_increment NOT NULL, ";
                    }
                    else
                    {
                        if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona) //SQLServer
                        {*/
                            consultaCreaTabla += "( correlativo int identity (1,1) NOT NULL, ";
                   //     }
                   // }

                    /*
                    //crea un campo para poder almacenar la llave foranea a aquellos q son form maestros
                    consultaCreaTabla += "formularioDetalle int ";
                    //Revisa si es maestro de algun detalle
                    String IDFormDetalle = consultaBD.soyMaestro(IDsFormularios[i]);
                    if (IDFormDetalle != null)
                    {
                        //pone el valor del detalle cmo default
                        consultaCreaTabla += "NOT NULL DEFAULT '" + IDFormDetalle + "', ";
                    }
                    else
                    {
                        //nada mas va a dejar el campo vacio 
                        consultaCreaTabla += ", ";
                    }
                    */


                    /*
                    //AQUI VOY A BUSCAR LOS ELEM SIMETRICOS
                    string relaciones[][] = buscarRelacionesSimetricas(IDsFormularios);
                    string consulta;
                    string correlativo1;
                    string correlativo2;
                    int temp;
                    
                    while (relaciones[temp][0]!=NULL){

                        correlativo1= //consultaBD.getNombreFormulario(relaciones[temp][0]); //HAY QUE HACER LA CONSULTA DE ESTO
                        correlativo1= //select correlativo from correlativo1.toString();  //HAY QUE HACER LA CONSULTA DE ESTO
                        
                     correlativo2= //consultaBD.getNombreFormulario(relaciones[temp][1]); //HAY QUE HACER LA CONSULTA DE ESTO
                     correlativo2= //select correlativo from correlativo2.toString();  //HAY QUE HACER LA CONSULTA DE ESTO
                    
                    
                        if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
                        {
                            consulta = "insert into RELACIONESSIMETRICAS (idFormulario1, idFormulario2, idRelacionConfigurador) VALUES ('" + correlativo1 + "','" + correlativo2 + "','" + relaciones[temp][2] + "')'")";
                        }
                        if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona)
                        {
                            consulta = "insert into RELACIONESSIMETRICAS (idFormulario1, idFormulario2, idRelacionConfigurador) VALUES ('" + correlativo1 + "','" + correlativo2 + "','" + relaciones[temp][2] + "')'")";
                        }
                        consultaBD.agregarRelacionSimetrica(consulta);
                     }
                    
                    */


                    //busca el ID y nombre de los tipos de campo
                    String[] IDsTiposCampo = buscarTiposCampoDelFormulario(IDsFormularios[i]);
                    for (int j = 0; j < IDsTiposCampo.Length - 1; ++j)
                    {
                        //Si es de tipo numero
                        if (IDsTiposCampo[j + 1] != null)
                        {
                            switch(int.Parse(IDsTiposCampo[j+1])){
                                case 1: //numero
                                    consultaCreaTabla += IDsTiposCampo[j] + " int, ";
                                    break;
                                case 2: //Binario
                                    //para los binarios nada mas un true o false que indiq si ese campo esta activo.                    
                                    consultaCreaTabla += IDsTiposCampo[j] + " varchar(6), ";
                                    break;
                                case 3: //FechaHora
                                    //if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
                                        consultaCreaTabla += IDsTiposCampo[j] + " SMALLDATETIME, ";
                                   // else
                                    //    if(ControladorBD.MYSQL == ControladorBD.conexionSelecciona)
                                    //        consultaCreaTabla += IDsTiposCampo[j] + " TIMESTAMP, ";
                                    break;
                                case 4: //Texto
                                    int tamanoTexto = consultaBD.getLongitudDeTexto(IDsTiposCampo[j + 2]);
                                    consultaCreaTabla += IDsTiposCampo[j] + " varchar(" + tamanoTexto + "), ";
                                    break;
                                case 5: //Incremental
                                    consultaCreaTabla += IDsTiposCampo[j] + " int, ";
                                    break;
                                case 6: //Jerarquia
                                    //para la jerarquia un campo de texto bn grande para poder poner todo el path necesario...
                                    int tamañoPath = 100;
                                    consultaCreaTabla += IDsTiposCampo[j] + " varchar(" + tamañoPath + "), ";
                                    break; 
                                case 7: //Lista
                                    int size = 30;
                                    consultaCreaTabla += IDsTiposCampo[j] + " varchar(" + size + "), ";
                                    break;
                            }
                        }                        
                        j+=2; //pasa al inicio del sig miembroFormulario
                    } //fin for
                    
                    //se termina la expresion para crear la tabla.
                    consultaCreaTabla += "PRIMARY KEY (correlativo) );";
                    Console.WriteLine("VOY A CREAR! " + consultaCreaTabla);
                    consultaBD.crearTablaFormulario(consultaCreaTabla);
                    MessageBox.Show("Se acaba de crear la tabla correspondiente para el formulario " + nombreFormulario + "! ", "Aviso");
                }
            } //fin for
        /* */
        }

        /// <summary>
        /// Busca en la BD los formularios asociados al workflow
        /// </summary>
        /// <param name="workflow"></param>         
        public String[] buscarFormularios(String IDWorkflow)
        {
            //se busca en la BD configurador entre los formularios cuales pertenecen al flujo
            //puede ser crear un string dnd cada ';' sea un nuevo form 
            object datos = consultaBD.getIDsFormulariosDelFlujo(IDWorkflow);

            DataTable tabla = new DataTable();
            DataRow fila;
            DataColumn IDFormulario = new DataColumn();

            IDFormulario.ColumnName = "IDFormulario";
            IDFormulario.DataType = Type.GetType("System.String");

            tabla.Columns.Add(IDFormulario);
            if (datos != null)
            {
                //if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
                //{
                    while (((SqlDataReader)(datos)).Read())
                    {
                        fila = tabla.NewRow();
                        fila["IDFormulario"] = ((SqlDataReader)(datos)).GetValue(0);
                        tabla.Rows.Add(fila);
                    }
               // }
               /* if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona)
                {
                    while (((MySqlDataReader)(datos)).Read())
                    {
                        fila = tabla.NewRow();
                        fila["IDFormulario"] = ((MySqlDataReader)(datos)).GetValue(0);
                        tabla.Rows.Add(fila);
                    }
                }*/
            }
            Console.WriteLine("count = "+ tabla.Rows.Count);
            String[] IDs = new String[tabla.Rows.Count];
            for (int i = 0; i < tabla.Rows.Count; i++) {
                IDs[i] = tabla.Rows[i][0].ToString();                
            }
            String[] IDsSinRepetidos = quitarRepetidos(IDs);
            return IDsSinRepetidos;
        }

        public String[] quitarRepetidos(String[] IDs){
            String[] real = new String[IDs.Length];
            String tmp = "";
            real[0] = IDs[0];
            int cant = 1;
            for (int i = 1; i < IDs.Length; ++i) {
                bool repetido = false;
                tmp = IDs[i]; //copia el nuevo valor
                for (int k = 0; k < i; ++k) {
                    if (tmp == IDs[k])
                    {
                        repetido = true;
                    }                    
                }
                if (!repetido) {
                    real[cant] = IDs[i];
                    cant++;
                }
            }
            return real;
        }

        public String[] buscarTiposCampoDelFormulario(String IDForm)
        {
            SqlDataReader datos = consultaBD.getIDsTiposCampo(IDForm);

            DataTable tabla = new DataTable();
            DataRow fila;
            DataColumn NombreTipoCampo = new DataColumn();
            DataColumn IDTipoCampo = new DataColumn();
            DataColumn IDCampo = new DataColumn();

            NombreTipoCampo.ColumnName = "NombreTipoCampo";
            NombreTipoCampo.DataType = Type.GetType("System.String");

            IDTipoCampo.ColumnName = "IDTipoCampo";
            IDTipoCampo.DataType = Type.GetType("System.String");

            IDCampo.ColumnName = "IDCampo";
            IDCampo.DataType = Type.GetType("System.String");            
                        
            tabla.Columns.Add(NombreTipoCampo);
            tabla.Columns.Add(IDTipoCampo);
            tabla.Columns.Add(IDCampo);
            if (datos != null)
            {
                Console.WriteLine("entre");
               // if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
               // {
                    while (datos.Read())
                    {
                        fila = tabla.NewRow();
                        fila["NombreTipoCampo"] = datos.GetValue(0); 
                        fila["IDTipoCampo"] = datos.GetValue(1);                        
                        fila["IDCampo"] = datos.GetValue(2);
                        tabla.Rows.Add(fila);
                    }
               // }
               /* else
                {
                    if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona)
                    {
                        while (((MySqlDataReader)(datos)).Read())
                        {
                            fila = tabla.NewRow();
                            fila["NombreTipoCampo"] = ((MySqlDataReader)(datos)).GetValue(0);
                            fila["IDTipoCampo"] = ((MySqlDataReader)(datos)).GetValue(1);
                            fila["IDCampo"] = ((MySqlDataReader)(datos)).GetValue(2);
                            tabla.Rows.Add(fila);
                        }
                    }
                }*/
            }

            ////////pasa del dataTable a un array de strings
            Console.WriteLine("count = " + tabla.Rows.Count);
            //entre ID y nombre hay un ';'
            String[] valores = new String[tabla.Rows.Count * 3];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                //toma el nombre, pero puede q venga con espacios
                String temporal = tabla.Rows[i]["NombreTipoCampo"].ToString();
                String[] tmp = temporal.Split(' ');
                temporal = "";
                for (int k = 0; k < tmp.Length; ++k)
                {
                    temporal += tmp[k];
                }
                valores[i  * 3] = temporal;
                valores[(i * 3) + 1] = tabla.Rows[i]["IDTipoCampo"].ToString();
                valores[(i * 3) + 2] = tabla.Rows[i]["IDCampo"].ToString();
                Console.WriteLine("con i = " + i + " nombre: " + valores[i * 2] + " TipoCampo: " + valores[(i * 2) + 1] + " IDCampo: " + valores[(i * 2) + 2]);
                i += 3;
            }
            ///////////////////

            return valores;
        }



        public void agregarFlujoTablaFlujos(int IDFlujo){
            string consulta = "";

             //if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
             //   {
                    consulta = "insert into FLUJOSACTIVOS (idflujo, activo) VALUES ('" + IDFlujo + "','"+ 0 +"')";
                
            //    }
             /*   if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona)
                {
                    consulta = "insert into FLUJOSACTIVOS (idflujo, activo) VALUES ('" + IDFlujo + "','" + 0 + "')";
                }*/
                consultaBD.agregarFlujoConstruido(consulta);
        }

        public string[][] buscarRelacionesSimetricas(string[] formulariosActivos){
            /* MAE RICARDO ESTO NO COMPILA
            int fila = 0;
            int columna = 0;
            string resultado[][];
            while (fila < formulariosActivos.Length)
            {
                //necesito buscar en SIMETRICOS todos en los que IDForm1 sea = formulariosActivos[fila]
                //y meter en resultado[fila][columna] el IDForm1, IDForm2, y correlativo de SIMETRICOS que use. 
            }
            return resultado;
             */
            return null;
        }
    }
}
