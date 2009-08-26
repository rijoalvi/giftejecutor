using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    class ConsultaFlujoTrabajoMySQL: ConsultaFlujoTrabajo
    {
        public override Object getTodosLosFlujosTrabajo()
        {
            Object dataReader=null;
            dataReader = this.controladoBD.hacerConsultaMySQL("select * from FLUJO;");
            return dataReader;
        }
    }
}
