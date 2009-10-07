using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace GiftEjecutor
{
    class ConsultaJerarquia : Consulta
    {

        public bool isJerarquiaVacia( String nombreJerarquia) {
            String valor = "";
            SqlDataReader resultado = this.controladoBD.hacerConsultaConfigurador("select IDNodoRaiz from JERARQUIA where nombreJerarquia = '" + nombreJerarquia + "'");
            if (resultado.Read())
            {
                valor += resultado.GetValue(0).ToString(); //IDRaiz                                        
                if (valor.Equals("-1")) //Si esta vacia
                {
                    return true;
                }
                return false;
            }
            //Se dice q esta vacia, pero en realidad parece no existir
            return true;
        }

        public String buscarNombreNodo(int ID) {
            String nombre = "";
            SqlDataReader resultado = this.controladoBD.hacerConsultaConfigurador("select nombre from NODO where ID = '" + ID + "';");
                if (resultado.Read()) {
                    nombre += resultado.GetValue(0).ToString();                    
                }
            return nombre;
        }

        public String getIDsHijos(int IDnodo) {
            String valores = "";
            SqlDataReader resultado = this.controladoBD.hacerConsultaConfigurador("select ID from NODO where IDNodoPadre = '" + IDnodo + "';");
            while(resultado.Read()){
                valores += resultado.GetValue(0).ToString() + ";"; //ID nodo hijo
            }
            return valores;
        }

        public SqlDataReader getDatosJerarquia(int IDJerarquia)
        {
            SqlDataReader resultado = this.controladoBD.hacerConsultaConfigurador("select nombreJerarquia, IDNodoRaiz from JERARQUIA where correlativo = '" + IDJerarquia + "'");
            if (resultado.Read())
            {
                return resultado;
            }
            return null;
        }

    }
}
