using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    class Usuario
    {
        private ConsultaUsuario consultaBD;
        private int correlativo;
        private String nombre;
        private int[] IDsExpedientes;
        private Perfil miPerfil;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Usuario()
        {
            consultaBD = new ConsultaUsuario();            
        }

        /// <summary>
        /// Constructor para abrir los datos de un usario
        /// </summary>
        public Usuario(int id)
        {
            consultaBD = new ConsultaUsuario();
            correlativo = id;
            //carga todos los datos necesarios del usuario
            cargarDatosUsuario();
        }

        private void cargarDatosUsuario()
        {
            String[] datos = consultaBD.obtenerDatos(correlativo);
            nombre = datos[0];
            miPerfil = new Perfil(int.Parse(datos[1]));
            int[] misIds = consultaBD.obtenerIDsExpedientes(correlativo);
            //siempre q tenga expedientes asignados
            if (misIds != null)
            {
                IDsExpedientes = new int[misIds.Length];
                for (int i = 0; i < datos.Length; ++i)
                {
                    IDsExpedientes[i] = misIds[i];
                }
            }
        }

        /// <summary>
        /// Devuelve el ID del usuario si existe, de lo contrario devuelve un -1
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int comprobarUsuario(String nombre, String password) {
            return consultaBD.comprobarUsuario(nombre, password);
        }


    }
}
