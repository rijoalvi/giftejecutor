using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class Usuario
    {
        private ConsultaUsuario consultaBD;
        private int correlativo;
        private String nombre;
        private int[] IDsExpedientes;
        private Perfil miPerfil;
        private String contrasena;
        private String pregunta;
        private String respuesta;
        private List<Perfil> listaPerfiles;

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

        public void cargarDatosPrivados()
        {
            String[] datos = consultaBD.obtenerDatosPrivados(correlativo);
            contrasena = datos[0];
            pregunta = datos[1];
            respuesta = datos[2];
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
        /// 1 = Due�o
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
                if (tipo.Equals("Due�o", StringComparison.OrdinalIgnoreCase))
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


        /// <summary>
        /// Devuelve un datGridView con todos los usuarios que hay en el sistema
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTableTodosUsuarios()
        {
            DataTable tablaUsuarios = new DataTable();
            DataRow fila;

            DataColumn IDUsuario = new DataColumn();
            DataColumn nombre = new DataColumn();
            DataColumn tipo = new DataColumn();
            DataColumn contrasena = new DataColumn();
            DataColumn preguntaSecreta = new DataColumn();
            DataColumn respuesta = new DataColumn();
            DataColumn fechaActualizacion = new DataColumn();
            DataColumn IDPerfil = new DataColumn();

            IDUsuario.ColumnName = "IDUsuario";
            nombre.ColumnName = "Nombre de Usuario";
            tipo.ColumnName = "Perfil";
            contrasena.ColumnName = "Contrase�a";
            preguntaSecreta.ColumnName = "Pregunta Secreta";
            respuesta.ColumnName = "Respuesta";
            fechaActualizacion.ColumnName = "Fecha de Actualizaci�n";
            IDPerfil.ColumnName = "IDPerfil";

            IDUsuario.DataType = Type.GetType("System.String");
            nombre.DataType = Type.GetType("System.String");
            tipo.DataType = Type.GetType("System.String");
            contrasena.DataType = Type.GetType("System.String");
            preguntaSecreta.DataType = Type.GetType("System.String");
            respuesta.DataType = Type.GetType("System.String");
            fechaActualizacion.DataType = Type.GetType("System.String");
            IDPerfil.DataType = Type.GetType("System.String");

            tablaUsuarios.Columns.Add(IDUsuario);
            tablaUsuarios.Columns.Add(nombre);
            tablaUsuarios.Columns.Add(tipo);
            tablaUsuarios.Columns.Add(contrasena);
            tablaUsuarios.Columns.Add(preguntaSecreta);
            tablaUsuarios.Columns.Add(respuesta);
            tablaUsuarios.Columns.Add(fechaActualizacion);
            tablaUsuarios.Columns.Add(IDPerfil);

            
            SqlDataReader datos;
            datos = this.consultaBD.getTodosUsuarios();
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaUsuarios.NewRow();
                    fila["IDUsuario"] = datos.GetValue(0).ToString(); ;
                    fila["Nombre de Usuario"] = datos.GetValue(1).ToString();
                    Perfil p = new Perfil(Int32.Parse(datos.GetValue(2).ToString()));
                    String perfilVerdadero = p.getNombre();
                    fila["Perfil"] = perfilVerdadero;
                    fila["Contrase�a"] = datos.GetValue(3).ToString();
                    fila["pregunta Secreta"] = datos.GetValue(4).ToString();
                    fila["Respuesta"] = datos.GetValue(5).ToString();
                    fila["Fecha de Actualizaci�n"] = datos.GetValue(6).ToString();
                    fila["IDPerfil"] = (datos.GetValue(2).ToString());
                    tablaUsuarios.Rows.Add(fila);
                }
            }
            return tablaUsuarios;
        }

        public String getContrasena() 
        {
            return contrasena;
        }

        public String getPregunta()
        {
            return pregunta;
        }

        public String getRespuesta()
        {
            return respuesta;
        }
        public String getNombre()
        {
            return nombre;
        }
        public void crearNuevoUsuario(String nombre, String contrasena, String pregunta, String respuesta, int IDPerfil)
        {
            consultaBD.crearUsuario(nombre, contrasena,pregunta,respuesta,IDPerfil);
        }
    }
}
