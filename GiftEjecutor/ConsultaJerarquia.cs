using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos del componente Jerarquia
    /// </summary>
    class ConsultaJerarquia : Consulta
    {
        /// <summary>
        /// Indica si la jerarquia esta vacía
        /// </summary>
        /// <param name="nombreJerarquia"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtiene el nombre del nodo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public String buscarNombreNodo(int ID) {
            String nombre = "";
            SqlDataReader resultado = this.controladoBD.hacerConsultaConfigurador("select nombre from NODO where ID = '" + ID + "';");
                if (resultado.Read()) {
                    nombre += resultado.GetValue(0).ToString();                    
                }
            return nombre;
        }

        /// <summary>
        /// Obtiene los IDs de sus hijos
        /// </summary>
        /// <param name="IDnodo"></param>
        /// <returns></returns>
        public String getIDsHijos(int IDnodo) {
            String valores = "";
            SqlDataReader resultado = this.controladoBD.hacerConsultaConfigurador("select ID from NODO where IDNodoPadre = '" + IDnodo + "';");
            while(resultado.Read()){
                valores += resultado.GetValue(0).ToString() + ";"; //ID nodo hijo
            }
            return valores;
        }

        /// <summary>
        /// Obtiene los datos básicos de la jerarquía.
        /// </summary>
        /// <param name="IDJerarquia"></param>
        /// <returns></returns>
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
