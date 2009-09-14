using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaExpediente : Consulta
    {
        /*Si se retorna un -1 indica que no se pudo crear debido a que ya existia una coleccion con ese nombre en esa Coleccion*/
        public int crearExpediente(String nombre, int correlativoColeccion){
            int correlativo = -1;
            String consulta = "Select correlativo From EXPEDIENTE where nombre = '" + nombre +
                               "' AND correlativoColeccion = " + correlativoColeccion + ";";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);

            if (!resultado.Read())
            {
                consulta = "INSERT INTO EXPEDIENTE ( nombre, correlativoColeccion) VALUES ('" +
                            nombre + "'," + correlativoColeccion + "); SELECT correlativo FROM EXPEDIENTE WHERE nombre = '" + nombre + "' AND correlativoPadre = " + correlativoColeccion + ";";
                resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
                resultado.Read();
                correlativo = int.Parse(resultado.GetValue(0).ToString());
            }
            return correlativo;
        }



        public List<String[]> listarExpedientes() {
            /****************************************************Probar con la base de datos***********************************************/
           /* String consulta = "SELECT correlativo, nombre, correlativoColeccion From EXPEDIENTE;";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            String[] expediente;
            List<String[]> lista = new List<string[]>();
            while (resultado.Read()) {
                expediente = new String[3];
                expediente[0] = resultado.GetValue(0);//Obtiene el correlativo
                expediente[1] = resultado.GetValue(1);//Obtiene el nombre
                expediente[2] = resultado.GetValue(2);//Obtiene el correlativo del padre
                lista.Add(coleccion);            
            }*/
            
            /****************************************************Probar sin la base de datos***********************************************/

            String[] coleccion;
            List<String[]> lista = new List<string[]>();
            coleccion = new String[3];
            coleccion[0] = "1";//Obtiene el correlativo
            coleccion[1] = "Canciones";//Obtiene el nombre
            coleccion[2] = "0";//Obtiene el correlativo del padre
            lista.Add(coleccion);

            coleccion = new String[3];
            coleccion[0] = "2";//Obtiene el correlativo
            coleccion[1] = "Libros";//Obtiene el nombre
            coleccion[2] = "0";//Obtiene el correlativo del padre
            lista.Add(coleccion);

            coleccion = new String[3];
            coleccion[0] = "3";//Obtiene el correlativo
            coleccion[1] = "Peliculas";//Obtiene el nombre
            coleccion[2] = "0";//Obtiene el correlativo del padre
            lista.Add(coleccion);

            coleccion = new String[3];
            coleccion[0] = "4";//Obtiene el correlativo
            coleccion[1] = "Bendita la luz";//Obtiene el nombre
            coleccion[2] = "1";//Obtiene el correlativo del padre
            lista.Add(coleccion);

            coleccion = new String[3];
            coleccion[0] = "5";//Obtiene el correlativo
            coleccion[1] = "Noche de entierro";//Obtiene el nombre
            coleccion[2] = "1";//Obtiene el correlativo del padre
            lista.Add(coleccion);

            coleccion = new String[3];
            coleccion[0] = "6";//Obtiene el correlativo
            coleccion[1] = "Terminator";//Obtiene el nombre
            coleccion[2] = "3";//Obtiene el correlativo del padre
            lista.Add(coleccion);

            coleccion = new String[3];
            coleccion[0] = "7";//Obtiene el correlativo
            coleccion[1] = "THE NOTHEBOOK";//Obtiene el nombre
            coleccion[2] = "3";//Obtiene el correlativo del padre
            lista.Add(coleccion);

            coleccion = new String[3];
            coleccion[0] = "8";//Obtiene el correlativo
            coleccion[1] = "Annie";//Obtiene el nombre
            coleccion[2] = "7";//Obtiene el correlativo del padre
            lista.Add(coleccion);

            coleccion = new String[3];
            coleccion[0] = "9";//Obtiene el correlativo
            coleccion[1] = "Noa";//Obtiene el nombre
            coleccion[2] = "7";//Obtiene el correlativo del padre
            lista.Add(coleccion);            
            
            return lista;
        }
    }
}
