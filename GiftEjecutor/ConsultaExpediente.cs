using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaExpediente : Consulta
    {
        /*Si se retorna un -1 indica que no se pudo crear debido a que ya existia una coleccion con ese nombre en esa Coleccion*/
        public int crearExpediente(String nombre, int correlativoColeccion,int IDFlujo){
            int correlativo = -1;
            String consulta = "Select correlativo From EXPEDIENTE where nombre = '" + nombre +
                               "' AND IDColeccion = " + correlativoColeccion + ";";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);

            if (!resultado.Read())
            {
                consulta = "INSERT INTO EXPEDIENTE ( nombre, IDColeccion, IDFlujo) VALUES ('" +
                            nombre + "'," + correlativoColeccion + ","+IDFlujo+"); SELECT correlativo FROM EXPEDIENTE WHERE nombre = '" + nombre + "' AND IDColeccion = " + correlativoColeccion + ";";
                resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
                resultado.Read();
                correlativo = int.Parse(resultado.GetValue(0).ToString());
            }
            return correlativo;
        }



        public List<String[]> listarExpedientes()
        {
            /****************************************************Probar con la base de datos***********************************************/
            String consulta = "SELECT correlativo, IDFlujo, IDColeccion, nombre From EXPEDIENTE;";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            String[] expediente;
            List<String[]> lista = new List<string[]>();
            while (resultado.Read())
            {
                expediente = new String[4];
                expediente[0] = resultado.GetValue(0).ToString();//Obtiene el correlativo
                expediente[1] = resultado.GetValue(1).ToString();//Obtiene el IDFlujo
                expediente[2] = resultado.GetValue(2).ToString();//Obtiene el IDColeccion a la que pertenece
                expediente[3] = resultado.GetValue(3).ToString();//Obtiene el nombre del expediente
                lista.Add(expediente);
            }
            return lista;
        }

        public String buscarNombreExpediente(int IDExpediente)
        {
            String consulta = "SELECT nombre From EXPEDIENTE where correlativo ="+ IDExpediente +";";
            Console.Write("consulta : " + consulta);
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            String nombreExpediente="";
            if (resultado.Read())
            {
                nombreExpediente = resultado.GetValue(0).ToString();
            }
            return nombreExpediente;
        }

        public int buscarCorrelativo(String nombre, int correlativoColeccion) {
            String consulta = "SELECT correlativo From EXPEDIENTE where nombre = '" + nombre + "' AND IDColeccion = "+correlativoColeccion+";";
            Console.Write("consulta : " + consulta);
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            int correlativo = -1;
            if (resultado.Read())
            {
                correlativo = int.Parse(resultado.GetValue(0).ToString());
            }
            return correlativo;
        }

        public void modificarNombre(int correlativoExpediente, String nombre)
        {
            String consulta = "UPDATE EXPEDIENTE SET nombre = '" + nombre + "' WHERE correlativo = " + correlativoExpediente + ";";
            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        public void eliminarExpediente(int correlativo) { 
            /*Bitacora ---> IDExpediente
Expediente---> correlativo*/
        }
    }
}
