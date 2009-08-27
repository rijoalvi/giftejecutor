using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace GiftEjecutor
{
    class ConstructorTablasFormularios
    {
        ConsultaConstructorTablasFormularios consultaBD;

        public ConstructorTablasFormularios()
        {
            consultaBD = ConsultaConstructorTablasFormularios.getInstancia();
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
                String consultaCreaTabla = "CREATE TABLE ";
                //Busca el nombre del formulario y lo agrega a la consulta
                nombreFormulario = consultaBD.getNombreFormulario(IDsFormularios[i]);
                consultaCreaTabla += nombreFormulario;
                if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona) //MYSQL
                {
                    consultaCreaTabla += "( correlativo int auto_increment NOT NULL, ";
                }
                else {
                    if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona) //SQLServer
                    { 
                        consultaCreaTabla += "( correlativo int identity (1,1) NOT NULL, ";
                    }
                }

                //crea un campo para poder almacenar la llave foranea a aquellos q son form maestros
                consultaCreaTabla += "formularioDetalle int ";
                //Revisa si es maestro de algun detalle
                String IDFormDetalle = consultaBD.soyMaestro(IDsFormularios[i]);
                if (IDFormDetalle != null)
                {
                    //pone el valor del detalle cmo default
                    consultaCreaTabla += "NOT NULL DEFAULT '" + IDFormDetalle + "', ";
                }
                else {
                    //nada mas va a dejar el campo vacio 
                    consultaCreaTabla += ", ";
                }
                
                //busca el ID y nombre de los tipos de campo
                String[] IDsTiposCampo = buscarTiposCampoDelFormulario(IDsFormularios[i]);
                for (int j = 0; j < IDsTiposCampo.Length-1; ++j) { 
                    //Si es de tipo numero
                    if (IDsTiposCampo[j + 1] != null)
                    {
                        if (IDsTiposCampo[j + 1] == "1")
                        {
                            consultaCreaTabla += IDsTiposCampo[j] + " int, ";
                        }
                        else
                        {
                            //Si es de tipoBinario
                            if (IDsTiposCampo[j + 1] == "2")
                            {
                                consultaCreaTabla += IDsTiposCampo[j] + " varchar(6), ";
                            }
                            //de momento todo el resto los tomamos iguales, con un tamaño preestablecido
                            else
                            {
                                //Tipo texto, el largo importa mucho
                                if (IDsTiposCampo[j + 1] == "4")
                                {
                                    //Aqui falta!!!!
                                    //int tamanoTexto = getLongitudDeTexto(IDsTiposCampo[
                                    const int TAMANOBD = 25;
                                    consultaCreaTabla += IDsTiposCampo[j] + " varchar(" + TAMANOBD + "), ";
                                }
                                else
                                {
                                    //Tipo jerarquia, campo mas grande
                                    if (IDsTiposCampo[j + 1] == "6")
                                    {
                                        const int TAMANOBD = 100;
                                        consultaCreaTabla += IDsTiposCampo[j] + " varchar(" + TAMANOBD + "), ";
                                    }
                                    else
                                    {
                                        //resto :p
                                        const int TAMANOBD = 30;
                                        consultaCreaTabla += IDsTiposCampo[j] + " varchar(" + TAMANOBD + "), ";
                                    }
                                }
                            }
                        }
                    }
                    j++; //pasa el valor del tipoCampo
                }
                
                //Para el tamaño del campo se ve el campo de "tamaño" en los de texto
                //para los binarios nada mas un true o false que indiq si ese campo esta activo.
                //para la jerarquia un campo de texto bn grande para poder poner todo el path necesario...
                //
                //se van creando entradas para cada campo, para desp crear la tabla cn todo.
                //como ir haciendo cada vez mas grande un string de "dataReader"

                //se termina la expresion para crear la tabla.
                consultaCreaTabla += "PRIMARY KEY (correlativo) );";
                Console.WriteLine("VOY A CREAR!");
                consultaBD.crearTablaFormulario(consultaCreaTabla);
                MessageBox.Show("Se acaba de crear la tabla correspondiente para el formulario "+nombreFormulario+"! ", "Aviso");                
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
                if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
                {
                    while (((SqlDataReader)(datos)).Read())
                    {
                        fila = tabla.NewRow();
                        fila["IDFormulario"] = ((SqlDataReader)(datos)).GetValue(0);
                        tabla.Rows.Add(fila);
                    }
                }
                if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona)
                {
                    while (((MySqlDataReader)(datos)).Read())
                    {
                        fila = tabla.NewRow();
                        fila["IDFormulario"] = ((MySqlDataReader)(datos)).GetValue(0);
                        tabla.Rows.Add(fila);
                    }
                }
            }
            Console.WriteLine("count = "+ tabla.Rows.Count);
            String[] IDs = new String[tabla.Rows.Count];
            for (int i = 0; i < tabla.Rows.Count; i++) {
                IDs[i] = tabla.Rows[i][0].ToString();                
            }
            return IDs;
        }

        public String[] buscarTiposCampoDelFormulario(String IDForm) {
            object datos = consultaBD.getIDsTiposCampo(IDForm);

            DataTable tabla = new DataTable();
            DataRow fila;
            DataColumn IDTipoCampo = new DataColumn();
            DataColumn NombreTipoCampo = new DataColumn();

            IDTipoCampo.ColumnName = "IDTipoCampo";
            IDTipoCampo.DataType = Type.GetType("System.String");

            NombreTipoCampo.ColumnName = "NombreTipoCampo";
            NombreTipoCampo.DataType = Type.GetType("System.String");

            tabla.Columns.Add(IDTipoCampo);
            tabla.Columns.Add(NombreTipoCampo);
            if (datos != null)
            {
                Console.WriteLine("entre");
                if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
                {
                    while (((SqlDataReader)(datos)).Read())
                    {
                        fila = tabla.NewRow();
                        fila["IDTipoCampo"] = ((SqlDataReader)(datos)).GetValue(0);
                        fila["NombreTipoCampo"] = ((SqlDataReader)(datos)).GetValue(1);
                        tabla.Rows.Add(fila);
                    }
                }
                else
                {
                    if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona)
                    {
                        while (((MySqlDataReader)(datos)).Read())
                        {
                            fila = tabla.NewRow();
                            fila["IDTipoCampo"] = ((MySqlDataReader)(datos)).GetValue(0);
                            fila["NombreTipoCampo"] = ((MySqlDataReader)(datos)).GetValue(1);
                            tabla.Rows.Add(fila);
                        }
                    }
                }
            }
            Console.WriteLine("count = " + tabla.Rows.Count);
            //entre ID y nombre hay un ';'
            String[] valores = new String[tabla.Rows.Count * 2];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                //toma el nombre, pero puede q venga con espacios
                String temporal = tabla.Rows[i][0].ToString();
                String[] tmp = temporal.Split(' ');
                temporal = "";
                for (int k = 0; k < tmp.Length; ++k)
                {
                    temporal += tmp[k];
                }
                valores[i  * 2] = temporal;
                valores[(i  * 2) + 1] = tabla.Rows[i][1].ToString();                
                Console.WriteLine("con i = " + i + " nombre: " + valores[i * 2] + " ID: " + valores[i * 2 + 1]); 
                //++i; //pasa un valor mas
            }
            return valores;
        }
        public void agregarFlujoTablaFlujos(int IDFlujo){
            string consulta = "";

             if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
                {
                    consulta = "insert into FLUJOSACTIVOS idFlujo = " + IDFlujo + ", activo = " + 0 + ";";                    
                }
                if (ControladorBD.MYSQL == ControladorBD.conexionSelecciona)
                {
                    consulta = "insert into FLUJOSACTIVOS idFlujo = " + IDFlujo + ", activo = " + 0 + ";";
                }
                consultaBD.agregarFlujoConstruido(consulta);
        }
    }
}
