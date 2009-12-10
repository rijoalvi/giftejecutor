using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que contiene al controlador de la Base de Datos
    /// </summary>
    class Consulta
    {
        protected ControladorBD controladoBD;

        /// <summary>
        /// Constructor por omisión
        /// </summary>
        public Consulta(){
            controladoBD = new ControladorBD();
            
        }
    }
}
