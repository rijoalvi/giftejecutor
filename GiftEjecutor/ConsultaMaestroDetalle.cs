using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaMaestroDetalle : Consulta
    {
        public SqlDataReader getFormularioDetallesPorFormularioMaestro(int IDFormularioMaestro)//4 eeuu
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaConfigurador("select ID, IDFormularioMaestro, NombreFormularioMaestro, IDFormularioDetalle, NombreFormularioDetalle, IDCampoLLaveMaestro,IDCampoLlaveDetalle from MaestroDetalle where IDFormularioMaestro="+IDFormularioMaestro+";");
            return dataReader;
        }

        public SqlDataReader getCamposMaestroSeleccionados(int IDMaestroDetalle)//4 eeuu
        {
            SqlDataReader dataReader = null;

         //   dataReader = this.controladoBD.hacerConsultaConfigurador("select ID, IDFormularioMaestro, NombreFormularioMaestro, IDFormularioDetalle, NombreFormularioDetalle, IDCampoLLaveMaestro,IDCampoLlaveDetalle from MaestroDetalle where IDFormularioMaestro=" + IDFormularioMaestro + ";");
            return dataReader;
        }

        public SqlDataReader getCamposDetalleSeleccionados(int IDMaestroDetalle)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaConfigurador("select IDCampo, nombreCampo from CamposDetalle where IDMaestroDetalle=" + IDMaestroDetalle + ";");
            return dataReader;
        }
        public SqlDataReader getTodoTablaDinamica(String nombreTabla)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("select * from " + nombreTabla + ";");
            return dataReader;
        }
        public SqlDataReader getMaestroDetallesPorFormularioMaestro(int IDFormularioMaestro)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaConfigurador("select ID as IDMaestroDetalle, nombreFormularioDetalle from MaestroDetalle where IDFormularioMaestro=" + IDFormularioMaestro + ";");
            return dataReader;
        }

    }
}
