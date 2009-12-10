using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos de los expedientes
    /// </summary>
    class ConsultaExpediente : Consulta
    {
        /// <summary>
        /// Crea un expediente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="correlativoColeccion"></param>
        /// <param name="IDFlujo"></param>
        /// <returns>Si se retorna un -1 indica que no se pudo crear debido a que ya existia una coleccion con ese nombre en esa Coleccion</returns>
        public int crearExpediente(String nombre, int correlativoColeccion,int IDFlujo){
            int correlativo = -1;
            String consulta = "Select correlativo From EXPEDIENTE where nombre = '" + nombre +
                               "' AND IDColeccion = " + correlativoColeccion + ";";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);

            if (!resultado.Read())
            {
                consulta = "INSERT INTO EXPEDIENTE ( nombre, IDColeccion, IDFlujo, eliminado) VALUES ('" +
                            nombre + "'," + correlativoColeccion + ","+IDFlujo+",'False'); SELECT correlativo FROM EXPEDIENTE WHERE nombre = '" + nombre + "' AND IDColeccion = " + correlativoColeccion + ";";
                resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
                resultado.Read();
                correlativo = int.Parse(resultado.GetValue(0).ToString());
                consulta = "INSERT INTO BITACORA(IDExpediente,IDActividad,IDComando,tipoComando,IDInstaciaForm,IDFormConfigurador," +
                           "ejecutada, descripcion) VALUES ("+correlativo+",-1,-1,-1,-1,-1,-1,'Se creó el expediente "+nombre +"') ";
                this.controladoBD.hacerConsultaEjecutor(consulta);
            }
            return correlativo;
        }

        /// <summary>
        /// Asigna si al expediente se le asignan las actividades manuales o automáticas
        /// </summary>
        /// <param name="manual"></param>
        /// <param name="correlativo"></param>
        public void setManual(Boolean manual,int correlativo) {
            String man;
            if (manual == true)
            {
                man = "true";
            }
            else
            {
                man = "false";
            }
            String consulta = "UPDATE EXPEDIENTE SET manual = '" + man + "' WHERE correlativo = " + correlativo + ";";
            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Lista los expedientes
        /// </summary>
        /// <returns></returns>
        public List<String[]> listarExpedientes()
        {
            /****************************************************Probar con la base de datos***********************************************/
            String consulta = "SELECT correlativo, IDFlujo, IDColeccion, nombre From EXPEDIENTE WHERE eliminado = 'False';";
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

        /// <summary>
        /// Obtiene todos los expedientes
        /// </summary>
        /// <returns></returns>
        public SqlDataReader obtenerTodosLosExpedientes()
        {
            String consulta = "SELECT correlativo, IDFlujo, IDColeccion, nombre From EXPEDIENTE WHERE eliminado = 'False';";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            return resultado;
        }

        /// <summary>
        /// Obtiene todos los expedientes del usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public SqlDataReader obtenerTodosLosExpedientes(int idUsuario)
        {
            String consulta = "SELECT DISTINCT Expediente.correlativo, Expediente.IDFlujo, Expediente.IDColeccion, Expediente.nombre "+
                                "FROM Expediente, ColeccionAsignada, Perfil, Usuario "+
                                "WHERE Usuario.correlativo = " + idUsuario +
                                " AND Usuario.IDPerfil = Perfil.correlativo " +
                                "AND Perfil.correlativo = ColeccionAsignada.IDPerfil " +
                                "AND ColeccionAsignada.IDColeccion = Expediente.IDColeccion " +
                                "ORDER BY Expediente.correlativo;";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            return resultado;
        }

        /// <summary>
        /// Obtiene los datos del expediente
        /// </summary>
        /// <param name="correlativo"></param>
        /// <returns></returns>
        public SqlDataReader obtenerDatosExpediente(int correlativo)
        {
            String consulta = "SELECT IDFlujo, IDColeccion, nombre From EXPEDIENTE WHERE correlativo = '" + correlativo + "';";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            return resultado;
        }

        /// <summary>
        /// Obtiene el nombre del expediente
        /// </summary>
        /// <param name="IDExpediente"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtiene el correlativo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="correlativoColeccion"></param>
        /// <returns></returns>
        public int buscarCorrelativo(String nombre, int correlativoColeccion) {
            String consulta = "SELECT correlativo From EXPEDIENTE where nombre = '" + nombre + "' AND IDColeccion = "+correlativoColeccion+";";
            Console.Write("consulta : " + consulta);
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            int correlativo = -1;
            if (resultado!=null && resultado.Read())//REVISAR XFA!!!!! TOTAN!!!!
            {
                correlativo = int.Parse(resultado.GetValue(0).ToString());
            }
            return correlativo;
        }

        /// <summary>
        /// Agrega una asignación
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idExpediente"></param>
        public void agregarAsignacion(int idUsuario, int idExpediente)
        {
            String consulta = "INSERT INTO PermisosUsuario (IDUsuario, IDExpediente) VALUES('" + idUsuario + "', '" + idExpediente + "');";
            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Modifica el nombre
        /// </summary>
        /// <param name="correlativoExpediente"></param>
        /// <param name="nombre"></param>
        public void modificarNombre(int correlativoExpediente, String nombre)
        {
            String consulta = "UPDATE EXPEDIENTE SET nombre = '" + nombre + "' WHERE correlativo = " + correlativoExpediente + ";";
            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Elimina un expediente
        /// </summary>
        /// <param name="correlativo"></param>
        /// <param name="nombre"></param>
        public void eliminarExpediente(int correlativo, String nombre) {
            String consulta = "UPDATE EXPEDIENTE SET eliminado = 'True' WHERE correlativo = " + correlativo +
                              "; INSERT INTO BITACORA(IDExpediente,IDActividad,IDComando,tipoComando,IDInstaciaForm,IDFormConfigurador," +
                              "ejecutada, descripcion) VALUES ("+correlativo+",-1,-1,-1,-1,-1,-1,'Se eliminó el expediente "+nombre +"') ";

            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Obtiene el nombre del flujo
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <returns></returns>
        public String getNombreFlujo(int IDFlujo)
        {
            String consulta = "SELECT nombre From FLUJO where correlativo = '" + IDFlujo + "';";
            SqlDataReader resultado = this.controladoBD.hacerConsultaConfigurador(consulta);
            String nombre = "";
            if (resultado.Read())
            {
                nombre = resultado.GetValue(0).ToString();
            }
            return nombre;
        }

    }
}
