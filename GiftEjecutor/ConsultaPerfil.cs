using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaPerfil:Consulta
    {
        public SqlDataReader getTodosPerfiles()
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("select correlativo, nombre, tipo, fechaActualizacion, IDFlujo from Perfil;");
            return dataReader;
        }
        //no se agrega IDFlujo, porque no sé que es... luisk
        public void insertPerfil(String nombre, String tipo){
            this.controladoBD.hacerConsultaEjecutor("insert into Perfil(nombre, tipo) values('"+nombre+"','"+tipo+"');");
        }
        public void deletePerfil(int IDPerfil)
        {
            this.controladoBD.hacerConsultaEjecutor("delete from Perfil where correlativo="+IDPerfil+";");
        }
    }
}
