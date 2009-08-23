using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    using MySql.Data.MySqlClient;
    class Consulta
    {
        protected ControladorBD controladoBD;
        protected MySqlDataReader datos;
        public Consulta(){
            controladoBD = new ControladorBD();
            
        }
    }
}
