using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

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
            String[] respuesta = { "", "",""};
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

            /* CONSULTA QUE BUSCA SEGUN EL PERFIL Y NO LOS ASIGNADOS
             String consulta = "select Expediente.correlativo from USUARIO, EXPEDIENTE, COLECCIONASIGNADA " +
                                "where USUARIO.correlativo = '9' AND " +
                                "USUARIO.IDPerfil = COLECCIONASIGNADA.IDPerfil AND " +
                                "COLECCIONASIGNADA.IDColeccion = EXPEDIENTE.IDColeccion;";
              
             ESTA HACE LAS DOS JUNTAS:
             select Expediente.correlativo from USUARIO, EXPEDIENTE, COLECCIONASIGNADA 
            where USUARIO.correlativo = '9' AND
            USUARIO.IDPerfil = COLECCIONASIGNADA.IDPerfil AND
            COLECCIONASIGNADA.IDColeccion = EXPEDIENTE.IDColeccion
            UNION select PermisosUsuario.IDExpediente from PermisosUsuario
            WHERE PermisosUsuario.IDUsuario = '9';
            */
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
            if (datos!=null && datos.Read())
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

        /// <summary>
        /// Crea un nuevo usuario con los datos enviados como parámetro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="contrasena"></param>
        /// <param name="pregunta"></param>
        /// <param name="respuesta"></param>
        /// <param name="IDPerfil"></param>
        public void crearUsuario(String nombre, String contrasena, String pregunta, String respuesta, int IDPerfil)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("insert into Usuario (nombreUsuario, contrasena, preguntaSecreta, respuesta,IDPerfil) VALUES ('" + nombre + "','" + contrasena + "','" + pregunta + "','" + respuesta + "','" + IDPerfil + "');");
        }

        public void editarUsuario(int IDUsuario, String nombre, String contrasena, String pregunta, String respuesta, int IDPerfil)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("update  Usuario set nombreUsuario = '"+ nombre +"', contrasena = '"+ contrasena +"', preguntaSecreta = '"+ pregunta +"', respuesta = '"+ respuesta +"',IDPerfil = '"+ IDPerfil + "' where correlativo = "+ IDUsuario +";");
        }

        /// <summary>
        /// Borra un usuario 
        /// </summary>
        public void borrarUsuario(int IDUsuario)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("delete FROM Usuario where correlativo = '" + IDUsuario + "';");
        }

        public DataTable getActividadesExpedientesPorUsuario(int IDUsuario,int perfil)
        {
            DataTable tablaUsuarios = new DataTable();
            DataRow fila;

            DataColumn IDExpediente = new DataColumn();
            DataColumn IDActividad = new DataColumn();


            IDExpediente.ColumnName = "IDExpediente";
            IDActividad.ColumnName = "IDActividad";


            IDExpediente.DataType = Type.GetType("System.Int32");
            IDActividad.DataType = Type.GetType("System.Int32");

            tablaUsuarios.Columns.Add(IDExpediente);
            tablaUsuarios.Columns.Add(IDActividad);


            SqlDataReader datos = null;
            datos = this.controladoBD.hacerConsultaEjecutor("Select P.IDExpediente, A.IDActividad FROM PermisosUsuario P,ActividadesUsuario A "+
                "where P.IDUsuario = '" + IDUsuario + "' and A.IDPermiso = P.correlativo;");
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaUsuarios.NewRow();
                    fila["IDExpediente"] = Int32.Parse(datos.GetValue(0).ToString());
                    fila["IDActividad"] = Int32.Parse(datos.GetValue(1).ToString());
                    tablaUsuarios.Rows.Add(fila);
                }
            }
            //Agregar las actividades de los expedientes del perfil
            //SqlDataReader colecciones = this.controladoBD.hacerConsultaEjecutor("select IDColeccion from ColeccionAsignada where IDPerfil;");//modificar aca para el datatableActividadesUsuario 
            SqlDataReader colecciones = this.controladoBD.hacerConsultaEjecutor("select  E.correlativo  ,Ap.IdActividad " +
                                                                                "from ActividadPermitida Ap, Expediente E " +
                                                                                "where Ap.IDColeccionAsignada = E.IDColeccion AND Ap.correlativo in " +
                                                                                    "(" +
                                                                                    "select Ap1.correlativo " +
                                                                                    "from ActividadPermitida Ap1 " +
                                                                                    "where Ap1.IDColeccionAsignada in " +
                                                                                        "(" +
                                                                                        "select Ca.IDColeccion " +
                                                                                        "from ColeccionAsignada Ca " +
                                                                                        "where Ca.IDPerfil = " + perfil +
                                                                                        ")" +
                                                                                    ")");

            if (colecciones != null)
            {
                while (colecciones.Read())
                {
                    fila = tablaUsuarios.NewRow();
                    fila["IDExpediente"] = Int32.Parse(colecciones.GetValue(0).ToString());
                    fila["IDActividad"] = Int32.Parse(colecciones.GetValue(1).ToString());
                    tablaUsuarios.Rows.Add(fila);
                }
            }

            return tablaUsuarios;
        }

        public SqlDataReader getActividadesPorExpediente(int IDExpediente)
        {
            SqlDataReader datos = null;
            datos = this.controladoBD.hacerConsultaEjecutor("Select A.IDActividad FROM PermisosUsuario P, ActividadesUsuario A where P.IDExpediente = '" + IDExpediente + "' and A.IDPermiso = P.correlativo;");
            return datos;
        }

        public bool actividadManual(int IDExpediente)
        {
            SqlDataReader datos = null;
            datos = this.controladoBD.hacerConsultaEjecutor("Select manual from EXPEDIENTE where correlativo = " + IDExpediente + ";");
            bool respuesta = false;
            if (datos != null)
            {
                if (datos.Read())
                {
                    String resp = datos.GetValue(0).ToString();
                    if (resp == "true")
                    {
                        respuesta = true;
                    }
                }
            }
            return respuesta;
        }

        public DataTable getDataTableActividadesPorIDExpediente(int IDExpediente)
        {
            Expediente exp = new Expediente(IDExpediente);
            int IDFlujo = exp.getIDFlujo();
            Actividad actividad = new Actividad();
            DataTable actividades = actividad.getDataTableActividadesPorIDFlujo(IDFlujo);
            return actividades;
        }

        public DataTable getActividadesAsignadasPorExpediente(int IDUsuario, int IDExpediente)
        {
            DataTable tablaUsuarios = new DataTable();
            DataRow fila;
            DataColumn IDActividad = new DataColumn();
            DataColumn NombreActividad = new DataColumn();
            IDActividad.ColumnName = "IDActividad";
            NombreActividad.ColumnName = "Nombre de la actividad";
            IDActividad.DataType = Type.GetType("System.Int32");
            NombreActividad.DataType = Type.GetType("System.String");
            tablaUsuarios.Columns.Add(IDActividad);
            tablaUsuarios.Columns.Add(NombreActividad);


            SqlDataReader datos = null;
            SqlDataReader datos2 = null;
            datos = this.controladoBD.hacerConsultaEjecutor("Select A.IDActividad FROM PermisosUsuario P, ActividadesUsuario A where P.IDUsuario = '" + IDUsuario + "' and P.IDExpediente = '" + IDExpediente + "' and A.IDPermiso = P.correlativo;");
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaUsuarios.NewRow();
                    fila["IDActividad"] = Int32.Parse(datos.GetValue(0).ToString());
                    int IDAct = Int32.Parse(datos.GetValue(0).ToString());
                    datos2 = this.controladoBD.hacerConsultaConfigurador("Select nombre FROM ACTIVIDAD where correlativo = '" + IDAct + "';");
                    if (datos2 != null)
                    {
                        if(datos2.Read())
                        {
                                fila["Nombre de la actividad"] = datos2.GetValue(0).ToString();
                                //tablaUsuarios.Rows.Add(fila);
                        }
                    }
                    tablaUsuarios.Rows.Add(fila);
                }
            }
            return tablaUsuarios;
        }
        public DataTable getActividadesNoAsignadasPorExpediente(int Perfil, int IDColeccion)
        {
            DataTable tablaUsuarios = new DataTable();
            DataRow fila;
            DataColumn IDActividad = new DataColumn();
            DataColumn NombreActividad = new DataColumn();
            IDActividad.ColumnName = "IDActividad";
            NombreActividad.ColumnName = "Nombre de la actividad";
            IDActividad.DataType = Type.GetType("System.Int32");
            NombreActividad.DataType = Type.GetType("System.String");
            tablaUsuarios.Columns.Add(IDActividad);
            tablaUsuarios.Columns.Add(NombreActividad);


            SqlDataReader datos = null;
            SqlDataReader datos2 = null;
            datos = this.controladoBD.hacerConsultaEjecutor("Select A.IDActividad FROM ColeccionAsignada C, ActividadPermitida A where C.IDPerfil = '" + Perfil + "' and C.IDColeccion = '" + IDColeccion + "' and A.IDColeccionAsignada = C.correlativo;");
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaUsuarios.NewRow();
                    fila["IDActividad"] = Int32.Parse(datos.GetValue(0).ToString());
                    int IDAct = Int32.Parse(datos.GetValue(0).ToString());
                    datos2 = this.controladoBD.hacerConsultaConfigurador("Select nombre FROM ACTIVIDAD where correlativo = '" + IDAct + "';");
                    if (datos2 != null)
                    {
                        if (datos2.Read())
                        {
                            fila["Nombre de la actividad"] = datos2.GetValue(0).ToString();
                            //tablaUsuarios.Rows.Add(fila);
                        }
                    }
                    tablaUsuarios.Rows.Add(fila);
                }
            }
            return tablaUsuarios;
        }

        public void asignarActividad(int idUsuario, int idExpediente, int IDActividad)
        {
            string consulta1 = "Select correlativo from PermisosUsuario where IDUsuario = '"+idUsuario+"' and IDExpediente = '"+idExpediente+"'";
            SqlDataReader datos1 = this.controladoBD.hacerConsultaEjecutor(consulta1);
            int permiso;
            if (datos1 != null)
            {
                if (datos1.Read())
                {
                    permiso = Int32.Parse(datos1.GetValue(0).ToString());
                    String consulta = "INSERT INTO ActividadesUsuario (IDPermiso ,IDActividad) VALUES('" + permiso+ "', '" + IDActividad + "');";
                    SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
                }
            }
        }

    public void desasignarActividad(int idUsuario, int idExpediente, int IDActividad)
        {
            string consulta1 = "Select correlativo from PermisosUsuario where IDUsuario = '" + idUsuario + "' and IDExpediente = '" + idExpediente + "'";
            SqlDataReader datos1 = this.controladoBD.hacerConsultaEjecutor(consulta1);
            int permiso;
            if (datos1 != null)
            {
                if (datos1.Read())
                {
                    permiso = Int32.Parse(datos1.GetValue(0).ToString());
                    String consulta = "DELETE FROM ActividadesUsuario WHERE IDPermiso = '" + permiso + "' AND IDActividad = '" + IDActividad + "';";
                    SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
                }
            }
        }

    }
}
