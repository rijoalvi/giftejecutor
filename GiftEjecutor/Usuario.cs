using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que almacena usuarios. Se relaciona con un perfil.
    /// </summary>
    public class Usuario
    {
        private ConsultaUsuario consultaBD;
        private int correlativo;
        private String nombre;
        private int[] IDsExpedientes;
        private Perfil miPerfil;
        private String contrasena;
        private String pregunta;
        private String respuesta;
        private DataTable actividadesPropias;

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

        /// <summary>
        /// Devuelve los IDs de los expedientes que tiene asignados
        /// </summary>
        /// <returns></returns>
        public int[] getIDsExpedientes() {
            return this.IDsExpedientes;
        }

        /// <summary>
        /// Actualiza los IDs de los expedientes asignados
        /// </summary>
        public void actualizarIdsExpedientes() {
            int[] misIds = consultaBD.obtenerIDsExpedientes(correlativo);
            //siempre q tenga expedientes asignados
            if (misIds != null)
            {
                IDsExpedientes = new int[misIds.Length];
                for (int i = 0; i < misIds.Length; ++i)
                {
                    IDsExpedientes[i] = misIds[i];
                }
            }
        }

        private void cargarDatosUsuario()
        {
            String[] datos = consultaBD.obtenerDatos(correlativo);
            nombre = datos[0];
            miPerfil = new Perfil(int.Parse(datos[1]));
            this.actualizarIdsExpedientes();
            llenarActividadesPropias();
        }


        public void cargarDatosPrivados()
        {
            String[] datos = consultaBD.obtenerDatosPrivados(correlativo);
            contrasena = datos[0];
            pregunta = datos[1];
            respuesta = datos[2];
        }

        /// <summary>
        /// Devuelve el DataTable de las actividades asignadas a él
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTableActividadesPropias()
        {
            return this.actividadesPropias;
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

        /// <summary>
        /// Asigna un expediente al usuario
        /// </summary>
        /// <param name="idExpediente"></param>
        public void asignarExpediente(int idExpediente) {
            consultaBD.asignarExpediente(correlativo, idExpediente);
        }

        /// <summary>
        /// Devuelve 
        /// </summary>
        /// <returns></returns>
        public List<Usuario> getTodosLosUsuarios()
        {
            SqlDataReader datos;
            datos = consultaBD.obtenerTodosLosUsuarios();
            List<Usuario> usuarios = new List<Usuario>();
            if (datos != null)
            {
                while (datos.Read())
                {
                    int idUser = Int32.Parse(datos.GetValue(0).ToString());
                    usuarios.Add(new Usuario(idUser));
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
            contrasena.ColumnName = "Contraseña";
            preguntaSecreta.ColumnName = "Pregunta Secreta";
            respuesta.ColumnName = "Respuesta";
            fechaActualizacion.ColumnName = "Fecha de Actualización";
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
                    fila["Contraseña"] = datos.GetValue(3).ToString();
                    fila["pregunta Secreta"] = datos.GetValue(4).ToString();
                    fila["Respuesta"] = datos.GetValue(5).ToString();
                    fila["Fecha de Actualización"] = datos.GetValue(6).ToString();
                    fila["IDPerfil"] = (datos.GetValue(2).ToString());
                    tablaUsuarios.Rows.Add(fila);
                }
            }
            return tablaUsuarios;
        }

        /// <summary>
        /// devuelve un string con la contraseña del usuario
        /// </summary>
        /// <returns></returns>
        public String getContrasena() 
        {
            return contrasena;
        }

        /// <summary>
        /// devuelve la pregunta secreta del usuario
        /// </summary>
        /// <returns></returns>
        public String getPregunta()
        {
            return pregunta;
        }

        /// <summary>
        /// devuelve la respuesta secreta del usuario
        /// </summary>
        /// <returns></returns>
        public String getRespuesta()
        {
            return respuesta;
        }

        /// <summary>
        /// devuelve el nombre de usuario
        /// </summary>
        /// <returns></returns>
        public String getNombre()
        {
            return nombre;
        }

        /// <summary>
        /// crea un nuevo usuario en la base de datos con los parámetros enviados
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="contrasena"></param>
        /// <param name="pregunta"></param>
        /// <param name="respuesta"></param>
        /// <param name="IDPerfil"></param>
        public void crearNuevoUsuario(String nombre, String contrasena, String pregunta, String respuesta, int IDPerfil)
        {
            consultaBD.crearUsuario(nombre, contrasena,pregunta,respuesta,IDPerfil);
        }

        public override String ToString()
        {
            return this.nombre;
        }

        /// <summary>
        /// devuelve el correlativo del perfil al que pertenece el usuario
        /// </summary>
        /// <returns></returns>
        public int getCorrelativoPerfil()
        {
            return (miPerfil.getCorrelativo());
        }

        /// <summary>
        /// Devuelve el perfil del usuario
        /// </summary>
        /// <returns></returns>
        public Perfil getPerfil()
        {
            return this.miPerfil;
        }

        /// <summary>
        /// Edita un usuario existente, por IDUsuario
        /// </summary>
        /// <param name="IDUsuario"></param>
        /// <param name="nombre"></param>
        /// <param name="contrasena"></param>
        /// <param name="pregunta"></param>
        /// <param name="respuesta"></param>
        /// <param name="IDPerfil"></param>
        public void editarUsuario(int IDUsuario, String nombre, String contrasena, String pregunta, String respuesta, int IDPerfil)
        {
            consultaBD.editarUsuario(IDUsuario, nombre, contrasena, pregunta, respuesta, IDPerfil);
        }

        /// <summary>
        /// Devuelve el correlativo del usuario actual
        /// </summary>
        /// <returns></returns>
        public int getCorrelativo()
        {
            return correlativo;
        }

        /// <summary>
        /// borra un usuario
        /// </summary>
        /// <param name="IDUsuario"></param>
        public void borrarUsuario(int IDUsuario)
        {
            consultaBD.borrarUsuario(IDUsuario);
        }


        public bool actividadValida(int IDActividad, int IDExpediente)
        { 
            bool respuesta = false;
            if (this.getTipo() == 0){
                respuesta = true;
            }
            else{
                if(this.actividadManual(IDExpediente))
                {
                    DataRow[] columna = null;
                    columna = actividadesPropias.Select(@"IDExpediente = '" + IDActividad + "'");
                    if (columna != null){
                        respuesta = true;
                    }
                }
                else{
                    int i = 0;
                    bool existeExpediente = false;
                    while  (i<IDsExpedientes.Length && !existeExpediente){
                        if (IDsExpedientes[i] == IDExpediente){
                            existeExpediente = true;
                        }
                        ++i;
                    }
                    bool actividadValida = miPerfil.existeColeccionEnPerfil(IDExpediente, IDActividad);

                    if (actividadValida && existeExpediente)
                    {
                        respuesta = true;
                    }
                }
            }
            return respuesta;
        }


        /// <summary>
        /// Llena un datatable con las actividades que tiene asignado ese usuario en especifico
        /// </summary>
        private void llenarActividadesPropias()
        {
            actividadesPropias = this.consultaBD.getActividadesExpedientesPorUsuario(correlativo,this.getPerfil().getCorrelativo());
            
        }

        /// <summary>
        /// devuelve true si la actividad es manual, false si no
        /// </summary>
        /// <param name="IDActividad"></param>
        /// <returns></returns>
        private bool actividadManual(int IDExpediente)
        {
            return (this.consultaBD.actividadManual(IDExpediente));
        }

        /// <summary>
        /// Devuelve las actividades asignadas para un expediente en particular
        /// </summary>
        /// <param name="IDExpediente"></param>
        /// <returns></returns>
        public DataTable getDataTableActividadesAsignadasPorExpediente(int IDExpediente)
        {
            return (this.consultaBD.getActividadesAsignadasPorExpediente(correlativo, IDExpediente));
        }

        /// <summary>
        /// Devuelve las actividades NO asignadas para un expediente en particular
        /// </summary>
        /// <param name="IDExpediente"></param>
        /// <returns></returns>
        public DataTable getDataTableActividadesNoAsignadasPorExpediente(int IDExpediente)
        {
            Expediente e = new Expediente(IDExpediente);
            return (this.consultaBD.getActividadesNoAsignadasPorExpediente(miPerfil.getCorrelativo(), e.getIDColeccion()));
        }

        /// <summary>
        /// ASigna una actividad al usuario
        /// </summary>
        /// <param name="IDExpediente"></param>
        /// <param name="IDActividad"></param>
        public void asignarActividad(int IDExpediente, int IDActividad)
        {
            this.consultaBD.asignarActividad(this.correlativo, IDExpediente, IDActividad);
        }

        /// <summary>
        /// Le desaigna una actividad
        /// </summary>
        /// <param name="IDExpediente"></param>
        /// <param name="IDActividad"></param>
        public void desasignarActividad(int IDExpediente, int IDActividad)
        {
            this.consultaBD.desasignarActividad(this.correlativo, IDExpediente, IDActividad);
        }

    }
}
