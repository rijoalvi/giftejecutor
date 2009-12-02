using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaActividad:Consulta
    {
        /// <summary>
        /// Devuelve todas las Actividades que están contenidos es una actividad simple
        /// </summary>
        /// <param name="IDActividad">ID de la actividad simple</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader getTodasActividadesPorIDFlujo(int IDFlujo)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("Select correlativoFlujo, correlativo, nombre, descripcion, esSimple, ordenEjecucion, repetible from Actividad where correlativoFlujo="+IDFlujo+" order by ordenEjecucion;");
            return dataReader;
        }
        /// <summary>
        /// Devuelve la actividad según su ID
        /// </summary>
        /// <param name="IDActividad">ID de la actividad</param>
        /// <returns>SqlDataReader</returns>

        public SqlDataReader getDatosPorID(int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select correlativo, nombre, Descripcion, esSimple, FechaActualizacion from Actividad where correlativo=" + IDActividad + ";");
            return dataReader;
        }
        public SqlDataReader getDatosExtendidosPorID(int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select correlativo, nombre, Descripcion, esSimple, repetible, paralelo,exclusivo, ordenEjecucion, FechaActualizacion from Actividad where correlativo=" + IDActividad + ";");
            return dataReader;
        }
        public SqlDataReader insertarEnBitacora(int IDExp, int IDAct, int IDCom, int tipoCom, int IDInstForm, int IDFormConfig, bool ejec, String descripcion)
        {
            String consulta = "INSERT INTO BITACORA(IDExpediente, IDActividad, IDComando, tipoComando, IDInstaciaForm, IDFormConfigurador, ejecutada, descripcion)" +
                            "VALUES(" + IDExp + ", " + IDAct + ", " + IDCom + ", " + tipoCom + ", " + IDInstForm + ", " + IDFormConfig + ", '" + ejec + "', '" + descripcion + "');";
            Console.WriteLine(consulta);
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            return datos;
        }

        public bool soyActividadInicial(int ID)
        {
            String consulta = "SELECT ordenEjecucion FROM ACTIVIDAD where correlativo = '" + ID + "'";
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (datos.Read())
            {
                if (datos.GetValue(0).ToString().Equals("0"))
                    return true;
            }
            return false;
        }

        public SqlDataReader getExclusiva(int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select exclusivo from Actividad where correlativo=" + IDActividad + ";");
            return dataReader;
        }
        public SqlDataReader getNombreAct(int IDActividad) 
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select nombre from Actividad where correlativo=" + IDActividad + ";");
            return dataReader;
        }
        //select IDActividad from ActividadPermitida ap where IDColeccionAsignada=77;
        public SqlDataReader getIDActividadesPermitidasSegunColeccionAsignada(int IDColeccionAsignada)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("select IDActividad from ActividadPermitida ap where IDColeccionAsignada=" + IDColeccionAsignada + ";");
            return dataReader;
        }

        //public int actividadSiguiente (int IDActividad, int 
    }

}
