using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos del controlador
    /// </summary>
    class ConsultaControlador: Consulta
    {

        /// <summary>
        /// Constructor por omisión
        /// </summary>
        public ConsultaControlador()
        {
        }

        /// <summary>
        /// Obtiene los datos del comando
        /// </summary>
        /// <param name="IDComando"></param>
        /// <param name="IDExpediente"></param>
        /// <param name="IDActividad"></param>
        /// <returns></returns>
        public SqlDataReader getDatosUnSoloComando(int IDComando, int IDExpediente, int IDActividad)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("Select IDExpediente, IDComando from Bitacora where IDExpediente=" + IDExpediente + " and IDComando=" + IDComando + " AND IDActividad = " + IDActividad + ";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene los datos de la actividad
        /// </summary>
        /// <param name="IDActividad"></param>
        /// <param name="IDExpediente"></param>
        /// <returns></returns>
        public SqlDataReader getDatosUnaActividad(int IDActividad, int IDExpediente)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("Select IDExpediente, IDActividad, ejecutada, correlativo FROM Bitacora where IDExpediente = " + IDExpediente + " and IDActividad = " + IDActividad+ " AND IDComando = -1 order by correlativo;");
            return dataReader;
        }

        /// <summary>
        /// Obtiene los datos de la bitácora
        /// </summary>
        /// <param name="IDExpediente"></param>
        /// <returns></returns>
        public SqlDataReader getDatosBitacora(int IDExpediente)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("Select descripcion, fecha from Bitacora where IDExpediente=" + IDExpediente + ";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene los datos de la bitácora con orden descendiente
        /// </summary>
        /// <param name="IDExpediente"></param>
        /// <returns></returns>
        public SqlDataReader getDatosBitacoraOrdenDescendiente(int IDExpediente)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("Select IDComando from Bitacora where IDExpediente=" + IDExpediente + " order by correlativo desc;");
            return dataReader;
        }

        /// <summary>
        /// Obtiene el ultimo comando de la actividad
        /// </summary>
        /// <param name="IDActividad"></param>
        /// <returns></returns>
        public SqlDataReader getUltimoComandoPorActividad(int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("Select estadoFinal from Actividad where correlativo =" + IDActividad+ ";");
            return dataReader;
        }

        /// <summary>
        /// Finaliza la actividad en bitácora
        /// </summary>
        /// <param name="IDExpediente"></param>
        /// <param name="IDActividad"></param>
        /// <param name="user"></param>
        public void finalizarActividadBitacora(int IDExpediente, int IDActividad, Usuario user)
        {
            bool valor = true;
            Actividad act = new Actividad();
            String descripcion = "El usuario " + user + " termino de ejecutar la actividad " + act.getNombreActividadPorID(IDActividad);
            String consulta1 = "INSERT INTO BITACORA(IDExpediente, IDActividad, IDComando, tipoComando, IDInstaciaForm, IDFormConfigurador, ejecutada, descripcion)" +
                            "VALUES(" + IDExpediente + ", " + IDActividad + ", " + -1 + ", " + -1 + ", " + -1 + ", " + -1 + ", '" + valor + "', '" + descripcion + "');";
            Console.WriteLine(consulta1);
            SqlDataReader datos1 = this.controladoBD.hacerConsultaEjecutor(consulta1);
        }

        /// <summary>
        /// Indica si es repetible
        /// </summary>
        /// <param name="IDActividad"></param>
        /// <returns></returns>
        public bool getRepetible(int IDActividad)
        {
            bool respuesta = false;
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("Select repetible from Actividad where correlativo =" + IDActividad + ";");
            if (dataReader.Read())
            {
                if (dataReader.GetValue(0).ToString().Equals("true"))
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }
    }
}
