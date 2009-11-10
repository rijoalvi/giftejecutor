using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaUsuario : Consulta
    {

        /// <summary>
        /// Obtiene los datos del usuario: nombre, perfil
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public String[] obtenerDatos(int idUsuario){
            String[] respuesta = { "", "" };
            String consulta = "SELECT nombreUsuario, IDPerfil FROM Usuario WHERE correlativo = '" + idUsuario + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            if(datos.Read()) {
                respuesta[0] = datos.GetValue(0).ToString();
                respuesta[1] = datos.GetValue(1).ToString();
            }
            return respuesta;
        }

        /// <summary>
        /// obtiene la contraseña, pregunta secreta y respuesta del usuario
        /// </summary>
        /// <param name="correlativo"></param>
        /// <returns></returns>
        public String[]obtenerDatosPrivados(int correlativo)
        {
            String[] respuesta = { "", "" };
            String consulta = "SELECT contrasena, preguntaSecreta, respuesta FROM Usuario WHERE correlativo = '" + correlativo + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            if(datos.Read()) {
                respuesta[0] = datos.GetValue(0).ToString();
                respuesta[1] = datos.GetValue(1).ToString();
                respuesta[2] = datos.GetValue(2).ToString();
            }
            return respuesta;
        }


        /// <summary>
        /// Obtiene los IDs de los expedientes asociados al usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public int[] obtenerIDsExpedientes(int idUsuario)
        {
            String consulta = "SELECT IDExpediente FROM PermisosUsuario WHERE IDUsuario = '" + idUsuario + "' ORDER BY IDExpediente;";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            String IDs = "";
            while(datos.Read())
            {
                IDs += int.Parse(datos.GetValue(0).ToString())+";";
            }
            if (IDs.Length > 0)
            {
                String[] losIdsStr = IDs.Substring(0, IDs.Length-1).Split(';');
                int[] losIds = new int[losIdsStr.Length];
                for (int k = 0; k < losIdsStr.Length; ++k)
                    losIds[k] = int.Parse(losIdsStr[k]);
                return losIds;
            }
            return null;
        }

        /// <summary>
        /// Indica el ID del usuario si los datos son correctos, de lo contrario devuelve un -1
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int comprobarUsuario(String user, String password)
        {
            String consulta = "SELECT correlativo FROM Usuario WHERE nombreUsuario = '" + user + "' AND contrasena = '" + password + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            if (datos.Read())
            {
                return int.Parse(datos.GetValue(0).ToString());
            }
            return -1;
        }

        /// <summary>
        /// Devuelve todos los datos de la tabla usuario 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public String[] obtenerTodosLosDatos(int idUsuario)
        {
            String[] respuesta = { "", "" };
            String consulta = "SELECT nombreUsuario, IDPerfil, contrasena, preguntaSecreta, respuesta FROM Usuario WHERE correlativo = '" + idUsuario + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            if (datos.Read())
            {
                respuesta[0] = datos.GetValue(0).ToString();
                respuesta[1] = datos.GetValue(1).ToString();
                respuesta[2] = datos.GetValue(2).ToString();
                respuesta[3] = datos.GetValue(3).ToString();
                respuesta[4] = datos.GetValue(4).ToString();

            }
            return respuesta;
        }

        /// <summary>
        /// Asigna un expediente a un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idExpediente"></param>
        public void asignarExpediente(int idUsuario, int idExpediente)
        {
            String consulta = "INSERT INTO PermisosUsuario(IDUsuario ,IDExpediente) VALUES('" + idUsuario + "', '" + idExpediente + "');";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        public SqlDataReader obtenerTodosLosUsuarios()
        {
            String consulta = "SELECT correlativo FROM Usuario ORDER BY correlativo;";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            return datos;
        }

        /// <summary>
        /// Obtiene los datos de todos los usuarios en el sistema
        /// </summary>
        /// <returns></returns>
        public SqlDataReader getTodosUsuarios()
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("SELECT correlativo, nombreUsuario, IDPerfil, contrasena, preguntaSecreta, respuesta, fechaActualizacion FROM Usuario;");
            return dataReader;
        }

        public void crearUsuario(String nombre, String contrasena, String pregunta, String respuesta, int IDPerfil)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("insert into Usuario (nombreUsuario, contrasena, preguntaSecreta, respuesta,IDPerfil) VALUES ('" + nombre + "','" + contrasena + "','" + pregunta + "','" + respuesta + "');");
        }
    }
}
