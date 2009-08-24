using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace GiftEjecutor
{
    /// <summary>
    /// Hereda de clase consulta donde esta el "ControladorBD"
    /// </summary>
    class ConsultaConstructorTablasFormularios : Consulta
    {
        public String[] getIDsFormulariosDelFlujo(int IDflujo)
        {
            
            //Toma todos los IDs de los formularios q trabajan con ese flujo
            string strConsulta = "SELECT FORMULARIO.correlativo " +
                                 "FROM FLUJO, ACTIVIDAD, MIEMBROACTIVIDADSIMPLE, COMANDO, FORMULARIO "+
                                 "WHERE ACTIVIDAD.correlativoFlujo = FLUJO.correlativo "+
                                 "AND MIEMBROACTIVIDADSIMPLE.correlativoMadre = ACTIVIDAD.correlativo "+
                                 "AND COMANDO.ID = MIEMBROACTIVIDADSIMPLE.correlativoComando "+
                                 "AND COMANDO.IDFormulario = FORMULARIO.correlativo;";                
            MySqlDataReader datos = this.controladoBD.hacerConsulta(strConsulta);
            Console.WriteLine("hay " + datos.FieldCount + " numero de datos");
            String[] IDs = new string[datos.FieldCount];
            for (int i = 0; i < datos.FieldCount; i++) {
                IDs[i] = ""+datos.GetValue(i)+";";
            }
            return IDs;
        }


    }
}
