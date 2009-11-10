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

        /// <summary>
        /// Devuelve un int indicando u tipo
        /// 0 = Administrador
        /// 1 = Dueño
        /// 2 = Creador
        /// 3 = Colaborador
        /// </summary>
        /// <returns></returns>
        public int getTipo() {
            String tipo = miPerfil.getTipo();
            int tipoInt = 0;
            if (tipo.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                tipoInt = 0;
            else
                if (tipo.Equals("Dueño", StringComparison.OrdinalIgnoreCase))
                    tipoInt = 1;
                else
                    if (tipo.Equals("Creador", StringComparison.OrdinalIgnoreCase))
                        tipoInt = 2;
                    else
                        if (tipo.Equals("Colaborador", StringComparison.OrdinalIgnoreCase))
                            tipoInt = 3;
            return tipoInt;
        }

        public void asignarExpediente(int idExpediente) {
            consultaBD.asignarExpediente(correlativo, idExpediente);
        }

        /// <summary>
        /// Devuelve 
        /// </summary>
        /// <returns></returns>
        public int[] getTodosLosUsuarios()
        {
            SqlDataReader datos;
            datos = consultaBD.obtenerTodosLosUsuarios();
            List<Usuario> usuarios = new List<Usuario>();
            if (datos != null)
            {
                while (datos.Read())
                {
                    int idUser = Int32.Parse(datos.GetValue(0).ToString());
                    lista.Add(new Usuario(idUser));
                }
            }
            return usuarios;
        }

    }
}
