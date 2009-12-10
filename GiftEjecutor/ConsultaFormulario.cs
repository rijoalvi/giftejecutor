using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos de los formularios
    /// </summary>
    class ConsultaFormulario : Consulta
    {
        /// <summary>
        /// Ejecuta una consulta simple en la BD configurador
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public SqlDataReader ejecutarConsultaConfigurador(String consulta)
        {
            return this.controladoBD.hacerConsultaConfigurador(consulta);
        }

        /// <summary>
        /// Ejecuta una consulta simple en la BD ejecutor
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public SqlDataReader ejecutarConsultaEjecutor(String consulta)
        {
            return this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Obtiene los datos del formulario
        /// </summary>
        /// <param name="IDForm"></param>
        /// <returns></returns>
        public object getDatosFormulario(int IDForm)
        {
            //Toma todos los IDs de los formularios q trabajan con ese flujo
            String strConsulta = "Select correlativo, nombre, valX, valY, ancho, alto, tipoLetra, color, tamanoLetra, IDTipoCampo, IDCampo, tabIndex, estiloLetra " +
                "From MIEMBROFORMULARIO Where IDFormulario = " + IDForm +
                "ORDER BY correlativo;";
            Object datos = this.controladoBD.hacerConsultaConfigurador(strConsulta);
            return datos;            
        }

        /// <summary>
        /// Obtiene la máscara del tipoCampo número
        /// </summary>
        /// <param name="IDCampo"></param>
        /// <returns></returns>
        public String getMascaraNumero(int IDCampo)
        {
            String consulta = "SELECT mascara FROM NUMERO WHERE correlativo = " + IDCampo;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }
                
        /// <summary>
        /// Obtiene el texto por defecto del tipoCampo Texto
        /// </summary>
        /// <param name="IDCampo"></param>
        /// <returns></returns>
        public String getTextoDefecto(int IDCampo)
        {
            String consulta = "SELECT textoDefecto FROM TEXTO WHERE correlativo = " + IDCampo;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }

        /// <summary>
        /// Obtiene el valor inicial del incremental
        /// </summary>
        /// <param name="IDCampo"></param>
        /// <returns></returns>
        public String getValInicialIncremental(int IDCampo)
        {
            String consulta = "SELECT valInicial FROM INCREMENTAL WHERE correlativo = " + IDCampo;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if(dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }

        /// <summary>
        /// Obtiene los miembros de la lista
        /// </summary>
        /// <param name="IDCampo"></param>
        /// <returns></returns>
        public Object getMiembrosLista(int IDCampo)
        {
            String consulta = "SELECT valor FROM MIEMBROLISTA WHERE IDLista = " + IDCampo;
            Object datos = this.controladoBD.hacerConsultaConfigurador(consulta);
            return datos;
        }

        /// <summary>
        /// Obtiene el tamaño máximo del texto
        /// </summary>
        /// <param name="IDCampo"></param>
        /// <returns></returns>
        public int getMaxLengthTexto(int IDCampo)
        {
            String consulta = "SELECT tamano FROM TEXTO WHERE correlativo = " + IDCampo;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return int.Parse(dato.GetValue(0).ToString());
            return -1;
        }

        /// <summary>
        /// Obtiene el nombre del formulario
        /// </summary>
        /// <param name="IDForm"></param>
        /// <returns></returns>
        public String getNombreFormulario(int IDForm)
        {
            String consulta = "SELECT nombre FROM FORMULARIO WHERE correlativo = " + IDForm;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }

        /// <summary>
        /// Indica si este formularo es un maestro
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public bool soyMaestro(String IDFormulario)
        {
            String consulta = "select IDFormularioDetalle from MAESTRODETALLE " +
                            "where IDFormularioMaestro = '" + IDFormulario + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (datos.Read())
                return true;
            return false;
        }

        /// <summary>//luisk-
        /// Actualiza un campo de un formulario con un nuevo valor segun su correlativo
        /// </summary>
        /// <param name="nombreFormulario"></param>
        /// <param name="CampoAActualizar"></param>
        /// <param name="nuevoValor"></param>
        /// <returns></returns>
        public bool actualizarUnCampoSegunID(int correlativo, String nombreFormulario, string CampoAActualizar, string nuevoValor, string tipoCampo)
        {
            String consulta= "";
            if (tipoCampo.Equals("int")) {
                consulta = "update " + nombreFormulario + " set " + CampoAActualizar + "=" + nuevoValor + "  where correlativo="+correlativo+";";
            }
            if (tipoCampo.Equals("varchar"))//porque hay que poner con comillas simples
            {
                consulta = "update " + nombreFormulario + " set " + CampoAActualizar + "='" + nuevoValor + "'  where correlativo="+correlativo+";";
            }


            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            if (datos.Read())
                return true;
            return false;
        }

        /// <summary>
        /// Actualiza los campos
        /// </summary>
        /// <param name="correlativo"></param>
        /// <param name="nombreFormulario"></param>
        /// <param name="CampoAActualizar"></param>
        /// <param name="nuevoValor"></param>
        /// <param name="tipoCampo"></param>
        /// <returns></returns>
        public bool actualizarTodosLosCampos(int correlativo, String nombreFormulario, string CampoAActualizar, string nuevoValor, string tipoCampo)
        {
            String consulta = "";
            if (tipoCampo.Equals("int"))
            {
                consulta = "update " + nombreFormulario + " set " + CampoAActualizar + "=" + nuevoValor + "  ;";
            }
            if (tipoCampo.Equals("varchar"))//porque hay que poner con comillas simples
            {
                consulta = "update " + nombreFormulario + " set " + CampoAActualizar + "='" + nuevoValor + "' ;";
            }


            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            if (datos.Read())
                return true;
            return false;
        }

        /// <summary>
        /// Realiza una nueva inserción en bitácora
        /// </summary>
        /// <param name="IDExp"></param>
        /// <param name="IDAct"></param>
        /// <param name="IDCom"></param>
        /// <param name="tipoCom"></param>
        /// <param name="IDInstForm"></param>
        /// <param name="IDFormConfig"></param>
        /// <param name="ejec"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public SqlDataReader insertarEnBitacora(int IDExp, int IDAct, int IDCom, int tipoCom, int IDInstForm, int IDFormConfig, bool ejec, String descripcion)
        {
            String consulta = "INSERT INTO BITACORA(IDExpediente, IDActividad, IDComando, tipoComando, IDInstaciaForm, IDFormConfigurador, ejecutada, descripcion)" +
                            "VALUES(" + IDExp + ", " + IDAct + ", " + IDCom + ", " + tipoCom + ", " + IDInstForm + ", " + IDFormConfig + ", '" + ejec + "', '" + descripcion + "');";
            Console.WriteLine(consulta);
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            return datos;
        }

        /// <summary>
        /// Crea una nueva entrada de un formulario
        /// </summary>
        /// <param name="consulta"></param>
        /// <param name="nombreTabla"></param>
        /// <returns></returns>
        public int insertarInstanciaFormulario(String consulta, String nombreTabla) {            
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            //esto se hace para poder obtener de regreso el correlativo de la instancia recien creada.
            String miConsulta = "select IDENT_CURRENT('" + nombreTabla + "');";
            datos = this.controladoBD.hacerConsultaEjecutor(miConsulta);
            if (datos.Read())
                return int.Parse(datos.GetValue(0).ToString());
            return -1;
        }

        /// <summary>
        /// Elimina un tupla
        /// </summary>
        /// <param name="IDTupla"></param>
        /// <param name="nombreFormulario"></param>
        /// <returns></returns>
        public SqlDataReader eliminarTupla(int IDTupla, String nombreFormulario)
        {
            String consulta = "delete from " + nombreFormulario + " where correlativo = " + IDTupla + ";";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            return datos;
        }

        /// <summary>
        /// Obtiene el ID del formulario
        /// </summary>
        /// <param name="nombreFormulario"></param>
        /// <returns></returns>
        public int getIDFormularioPorNombre(String nombreFormulario) {
            String consulta = "select correlativo, nombre from Formulario where nombre='" + nombreFormulario + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (datos.Read())
                return int.Parse(datos.GetValue(0).ToString());
            return -1;
        }

        /// <summary>
        /// Obtiene el ID que identifica a la tupla
        /// </summary>
        /// <param name="nombreForm"></param>
        /// <param name="IDExpediente"></param>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public int getIDTupla(String nombreForm, int IDExpediente, int IDFormulario)
        {
            int IDTupla = -1;
            String consulta = "select " + nombreForm + ".correlativo, BITACORA.fecha from " + nombreForm + ", BITACORA where " + nombreForm + ".correlativo = BITACORA.IDInstaciaForm AND BITACORA.tipoComando = 1 AND BITACORA.IDExpediente = " + IDExpediente + " AND Bitacora.IDFormConfigurador = " + IDFormulario + ";";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            if (datos!=null&&datos.Read())
                IDTupla = int.Parse(datos.GetValue(0).ToString());
            return IDTupla;
        }  
    }
}
