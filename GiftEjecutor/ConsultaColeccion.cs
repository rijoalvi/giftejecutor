using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaColeccion : Consulta
    {
        /*Si se retorna un -1 indica que no se pudo crear debido a que ya existia una coleccion con ese nombre en esa Coleccion*/
        public int crearColeccion(String nombre, int correlativoPadre, int correlativoFlujo){
            int correlativo = -1;
            String consulta = "Select correlativo From COLECCION where nombre = '" + nombre +
                               "' AND correlativoPadre = " + correlativoPadre + ";";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);

            if (!resultado.Read())
            {
                consulta = "INSERT INTO COLECCION ( nombre, correlativoPadre, correlativoFlujo) VALUES ('" +
                    nombre + "'," + correlativoPadre + ","+ correlativoFlujo +"); SELECT correlativo FROM COLECCION WHERE nombre = '" + nombre + "' AND correlativoPadre = " + correlativoPadre + ";";
                resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
                resultado.Read();
                correlativo = int.Parse(resultado.GetValue(0).ToString());
            }
            return correlativo;
        }


        /*POR AHORA LAS COLECCIONES TIENEN QUE SER DE DISTINTO NOMBRE.....*/
        public String[] coleccionesHijas(String nombre/*, String nombrePadre*/) { 
            /*Consulta = "SELECT nombre FROM COLECCION c1 where c1.correlativoPadre = "+
                       "(SELECT correlativo FROM COLECCION c2 where c2.nombre = '"+ nombre+"' AND "       
                        +"c2.correlativo" +nombre = '"+nombre+"' AND "+*/
            
            /***********************AVERIGUAR CORRELATIVO DEL PADRE *******************************/
            
            String consulta = "SELECT correlativo FROM COLECCION where nombre = '" + nombre + "'";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            
            String []hijos = null;
            
            if( nombre == "raiz" || (resultado.IsClosed && resultado.Read())){
                int correlativo=0;
                if(nombre!="raiz")
                    correlativo = int.Parse(resultado.GetValue(0).ToString());


                /***********************AVERIGUAR CUANTOS SON *******************************/
                consulta = "SELECT count(*) FROM COLECCION where correlativoPadre = " + correlativo + ";";
                resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
                if(resultado.Read()){


                    hijos = new String[int.Parse(resultado.GetValue(0).ToString())];
                    consulta = "SELECT nombre FROM COLECCION where correlativoPadre = " +correlativo+ "";
                    resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
                
                         
                    int i =0;
                    while(resultado.Read()){
                        hijos[i] = resultado.GetValue(0).ToString();
                        i++;            
                    }
                }
            }else if(nombre == "raiz"){
                
            
            }
            return hijos;
        }


        public List<String[]> listarColecciones() {
            /****************************************************Probar con la base de datos***********************************************/
            // this.controladoBD.hacerConsultaEjecutor("DELETE FROM COLECCION");
            String consulta = "SELECT correlativo, nombre, correlativoPadre, correlativoFlujo From COLECCION;";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            String[] coleccion;
            List<String[]> lista = new List<string[]>();
            while (resultado.Read()) {
                coleccion = new String[4];
                coleccion[0] = resultado.GetValue(0).ToString();//Obtiene el correlativo
                coleccion[1] = resultado.GetValue(1).ToString();//Obtiene el nombre
                coleccion[2] = resultado.GetValue(2).ToString();//Obtiene el correlativo del padre
                coleccion[3] = resultado.GetValue(3).ToString();//Obtiene el correlativo del flujo al que pertenece
                lista.Add(coleccion);            
            }
            
            /****************************************************Probar sin la base de datos***********************************************

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
            lista.Add(coleccion);            */
            
            return lista;
        }
    }
}
