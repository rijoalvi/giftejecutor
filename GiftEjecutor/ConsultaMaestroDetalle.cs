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
    }
}
