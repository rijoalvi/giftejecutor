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
            String consulta = "SELECT nombreUsuario, IDPerfil FROM Usuario WHERE correlativo = " + idUsuario + ";";
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
        public String[] obtenerIDsExpedientes(int idUsuario)
        {
            String[] respuesta = { "", "" };
            String consulta = "SELECT IDExpediente FROM PermisosUsuario WHERE IDUsuario = " + idUsuario + ";";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            int cant = 0;
            while(datos.Read())
            {
                respuesta[cant] = datos.GetValue(0).ToString();
            }
            return respuesta;
        }

    }
}
