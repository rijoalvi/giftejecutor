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
            dataReader = this.controladoBD.hacerConsultaMySQL("select correlativo, nombre, descripcion, actividadRaiz, fechaActualizacion from FLUJO;");
            return dataReader;
        }
    }
}
