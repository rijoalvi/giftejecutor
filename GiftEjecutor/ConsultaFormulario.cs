using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    abstract class ConsultaFormulario : Consulta
    {

        public abstract object getDatosFormulario(int IDForm);

        public abstract String getMascaraNumero(int IDCampo);

        public abstract String getTextoDefecto(int IDCampo);

        public abstract String getValInicialIncremental(int IDCampo);

        public static ConsultaFormulario getInstancia()
        {
            ConsultaFormulario consultaTablasFormularioSeleccionado = null;
            if (ControladorBD.conexionSelecciona == ControladorBD.SQLSERVER)
            {
                //consultaTablasFormularioSeleccionado = new ConsultaFormularioSQLServer();
            }
            if (ControladorBD.conexionSelecciona == ControladorBD.MYSQL)
            {
                consultaTablasFormularioSeleccionado = new ConsultaFormularioMySQL();
            }
            return consultaTablasFormularioSeleccionado;
        }
    }
}
