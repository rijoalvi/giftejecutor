using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    class ConstructorTablasFormularios
    {
        ConsultaConstructorTablasFormularios consultaBD;

     /*   public void buscarFormularios(String workflow) {

            //se busca en la BD configurador entre los formularios cuales pertenecen al flujo
            //puede ser crear un string dnd cada ';' sea un nuevo form
            String[] IDsFormularios = consultaBD.getIDsFormulariosDelFlujo(1);


            //se dividen todos esos formularios y a cada uno se le investiga los campos q tienen
            //busca para cada formulario
            for (int i = 0; i < IDsFormularios.Length; ++i)
            {
                String consultaCreaTabla = "CREATE TABLE ";
                //Busca el nombre del formulario y lo agrega a la consulta
                consultaCreaTabla += consultaBD.getNombreFormulario(IDsFormularios[i]);
                if (consultaBD.getConeccion() == 1) //MYSQL
                {
                    consultaCreaTabla += "( correlativo int auto_increment NOT NULL, ";
                }
                else {
                    if (consultaBD.getConeccion() == 2) { //SQLServer
                        consultaCreaTabla += "( correlativo int identity (1,1) NOT NULL, ";
                    }
                }
                
                //busca el ID y nombre de los tipos de campo
                String[] IDsTiposCampo = consultaBD.getIDsFormulariosDelFlujo( IDsFormularios[i]);
                //Para el tamaño del campo se ve el campo de "tamaño" en los de texto
                //para los binarios nada mas un true o false que indiq si ese campo esta activo.

                //para la jerarquia un campo de texto bn grande para poder poner todo el path necesario...
                //
                //se van creando entradas para cada campo, para desp crear la tabla cn todo.
                //como ir haciendo cada vez mas grande un string de "dataReader"

                //al final de este for se tiene q crear una tabla...
                //"CREATE TABLE '"+ nombre + "' y desp todos los valores..."
            }

            
        }*/

        /// <summary>
        /// Busca en la BD los formularios asociados al workflow
        /// </summary>
        /// <param name="workflow"></param>         
        public void buscarFormulariosasdf(String workflow)
        {
            //se busca en la BD configurador entre los formularios cuales pertenecen al flujo
            //puede ser crear un string dnd cada ';' sea un nuevo form
            

        }
    }
}
