using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaColeccion : Consulta
    {
        /*Si se retorna un -1 indica que no se pudo crear debido a que ya existia una coleccion con ese nombre en esa Coleccion*/
        public int crearColeccion(String nombre, int correlativoPadre){
            int correlativo = -1;
            String consulta = "Select correlativo From COLECCION where nombre = '" + nombre +
                               "' AND correlativoPadre = " + correlativoPadre + ";";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);

            if (!resultado.Read())
            {
                consulta = "INSERT INTO COLECCION ( nombre, correlativoPadre) VALUES ('" +
                            nombre + "'," + correlativoPadre + "); SELECT correlativo FROM COLECCION WHERE nombre = '" + nombre + "' AND correlativoPadre = " + correlativoPadre + ";";
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
    }
}
