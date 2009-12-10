using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos del componente Maestro detalle
    /// </summary>
    class ConsultaMaestroDetalle : Consulta
    {

        /// <summary>
        /// Obtiene el formulario detalle del maestro
        /// </summary>
        /// <param name="IDFormularioMaestro"></param>
        /// <returns></returns>
        public SqlDataReader getFormularioDetallesPorFormularioMaestro(int IDFormularioMaestro)//4 eeuu
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaConfigurador("select ID, IDFormularioMaestro, NombreFormularioMaestro, IDFormularioDetalle, NombreFormularioDetalle, IDCampoLLaveMaestro,IDCampoLlaveDetalle from MaestroDetalle where IDFormularioMaestro="+IDFormularioMaestro+";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene los campos del formulario maestro
        /// </summary>
        /// <param name="IDMaestroDetalle"></param>
        /// <returns></returns>
        public SqlDataReader getCamposMaestroSeleccionados(int IDMaestroDetalle)//4 eeuu
        {
            SqlDataReader dataReader = null;

         //   dataReader = this.controladoBD.hacerConsultaConfigurador("select ID, IDFormularioMaestro, NombreFormularioMaestro, IDFormularioDetalle, NombreFormularioDetalle, IDCampoLLaveMaestro,IDCampoLlaveDetalle from MaestroDetalle where IDFormularioMaestro=" + IDFormularioMaestro + ";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene los campos del formulario detalle
        /// </summary>
        /// <param name="IDMaestroDetalle"></param>
        /// <returns></returns>
        public SqlDataReader getCamposDetalleSeleccionados(int IDMaestroDetalle)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaConfigurador("select IDCampo, nombreCampo from CamposDetalle where IDMaestroDetalle=" + IDMaestroDetalle + ";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene todos los datos de la tabla dinámica
        /// </summary>
        /// <param name="nombreTabla"></param>
        /// <param name="idDatosMaestro"></param>
        /// <returns></returns>
        public SqlDataReader getTodoTablaDinamica(String nombreTabla, int idDatosMaestro)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("SELECT * FROM " + nombreTabla + " WHERE IDMaestro = " + idDatosMaestro + ";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene los datos de la relación a partir del formulario maestro
        /// </summary>
        /// <param name="IDFormularioMaestro"></param>
        /// <returns></returns>
        public SqlDataReader getMaestroDetallesPorFormularioMaestro(int IDFormularioMaestro)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaConfigurador("select ID as IDMaestroDetalle, nombreFormularioDetalle from MaestroDetalle where IDFormularioMaestro=" + IDFormularioMaestro + ";");
            return dataReader;
        }

    }
}
