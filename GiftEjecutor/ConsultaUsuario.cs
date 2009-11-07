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
        /// Obtiene los IDs de los expedientes asociados al usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public int[] obtenerIDsExpedientes(int idUsuario)
        {
            String consulta = "SELECT IDExpediente FROM PermisosUsuario WHERE IDUsuario = '" + idUsuario + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            int cant = 0;
            String IDs = "";
            while(datos.Read())
            {
                IDs += int.Parse(datos.GetValue(0).ToString())+";";
            }
            if (IDs.Length > 0)
            {
                String[] losIdsStr = IDs.Split(';');
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
    }
}
