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
        public Usuario(int id)
        {
            correlativo = id;
            cargarDatosUsuario();
            cargarIDsExpedientes();
        }

        private void cargarDatosUsuario()
        {
            String[] datos = consultaBD.obtenerDatos(correlativo);
            nombre = datos[0];
            miPerfil = new Perfil(int.Parse(datos[1]));
        }

        private void cargarIDsExpedientes()
        {
            String[] datos = consultaBD.obtenerIDsExpedientes(correlativo);
            /*
            while....
            */ 
        }

    }
}
