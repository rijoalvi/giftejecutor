using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    class ConstructorTablasFormularios
    {
        ConsultaConstructorTablasFormularios consultaBD;

        public void buscarFormularios(String workflow) { 
            //se busca en la BD configurador entre los formularios cuales pertenecen al flujo
            //puede ser crear un string dnd cada ';' sea un nuevo form
            String[] IDsFormularios = consultaBD.getIDsFormulariosDelFlujo(1);


            //se dividen todos esos formularios y a cada uno se le investiga los campos q tienen
            for (int i = 0; i < IDsFormularios.Length; ++i)
            {
                //busca para cada formulario
               // String[] IDsTiposCampo = consultaBD.getIDsFormulariosDelFlujo( IDsFormularios[i]);
                //Para el tama�o del campo se ve el campo de "tama�o" en los de texto
                //para los binarios nada mas un true o false que indiq si ese campo esta activo.

                //para la jerarquia un campo de texto bn grande para poder poner todo el path necesario...
                //
                //se van creando entradas para cada campo, para desp crear la tabla cn todo.
                //como ir haciendo cada vez mas grande un string de "dataReader"

                //al final de este for se tiene q crear una tabla...
                //"CREATE TABLE '"+ nombre + "' y desp todos los valores..."
            }

            
        }

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
