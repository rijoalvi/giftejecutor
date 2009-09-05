using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    class Actividad
    {
        Comando comandoPrueba;
        public Actividad() { 
            this.comandoPrueba = new Comando();        
        }

        public Comando getComandoPrueba() {
            return comandoPrueba;
        }
    }
}
