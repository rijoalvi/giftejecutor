using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos de los flujos de trabajo
    /// </summary>
    class ConsultaFlujoTrabajo : Consulta
    {

        /// <summary>
        /// Retorna los datos de un flujo de trabajo
        /// en el retorno [0] se obtiene el nombre
        /// en el retorno [1] se obtiene la descripción
        /// </summary>
        /// <param name="correlativo"></param>
        /// <returns></returns>
        public String[] getDatosFlujo(int correlativo){
            this.controladoBD = new ControladorBD();
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador("SELECT nombre,descripcion FROM FLUJO WHERE correlativo = " + correlativo+";");
            String[] dato = new String[2];
            if (datos.Read())
            {
                //Console.Write("valor: " + datos.GetValue(0).ToString());
                //Console.Write("correlativo: " + correlativo);
                dato[0] = datos.GetValue(0).ToString();
                dato[1] = datos.GetValue(1).ToString();
            }
            return dato;
        }

        /// <summary>
        /// obtiene todos los flujos de trabajo
        /// </summary>
        /// <returns></returns>
        public SqlDataReader getTodosLosFlujosTrabajo()
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("SELECT * FROM FLUJO");
           /* dataReader.Read();
            dataReader.GetValue(1);*/
            return dataReader;
        }

        /// <summary>
        /// Obtiene los datos del flujo
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <returns></returns>
        public SqlDataReader selectFlujoTrabajoPorID(int IDFlujo)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("SELECT correlativo, nombre, descripcion, fechaActualizacion FROM FLUJO where correlativo=" + IDFlujo + ";");

            return dataReader;
        }

        /// <summary>
        /// Obtiene los flujos ya construidos
        /// </summary>
        /// <returns></returns>
        public SqlDataReader getFlujosConstruidos()
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("SELECT idFlujo FROM FLUJOSACTIVOS");
            SqlDataReader tamano= this.controladoBD.hacerConsultaEjecutor("select count(*) from FLUJOSACTIVOS");
            
            String taman;
            if (tamano.Read())
                taman = tamano.GetValue(0).ToString();

                        return dataReader;
        }


    }
}
