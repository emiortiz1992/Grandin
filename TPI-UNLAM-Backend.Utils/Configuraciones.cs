using System;
using System.Data;

namespace TPI_UNLAM_Backend.Utils
{
    public class Configuraciones
    {
        /// <summary>
        /// Obtiene el valor de la configuracion que se le pasa por parametro del config.xml
        /// </summary>
        /// <param name="nombreParametro"></param>
        /// <param name="opcional"></param>
        /// <returns></returns>
        private static object GetParametroConfig(string nombreParametro, bool opcional = false)
        {
            var ds = new DataSet();
            var pathConfig = CurrentDir + "\\Config.xml";
            ds.ReadXml(pathConfig);
            if (opcional && !ds.Tables[0].Rows[0].Table.Columns.Contains(nombreParametro))
                return null;

            return ds.Tables[0].Rows[0][nombreParametro];
        }

        /// <summary>
        /// Directorio donde esta instalado el servicio
        /// </summary>
        public static string CurrentDir
        {
            get
            {
                string bas = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString();
                var result = System.IO.Path.GetDirectoryName(bas);
                return result;
            }
        }

        /// <summary>
        /// Variable que indica si se esta corriendo en modo debug
        /// </summary>
        public static bool Debug
        {
            get
            {
                object o = GetParametroConfig("Debug", true);
                if (o != null)
                {
                    var result = Convert.ToBoolean(o);
                    return result;
                }

                return false;
            }
        }

       

        public static int PasarDeNivel
        {
            get
            {
                object o = GetParametroConfig("CantidadAciertosParaPasarDeNivel");
                if (o != null)
                {
                    var result = Convert.ToInt32(o);
                    return result;
                }

                return 0;
            }
        }

        public static int AciertosParaFinalizar
        {
            get
            {
                object o = GetParametroConfig("CantidadAciertosParaFinalizar");
                if (o != null)
                {
                    var result = Convert.ToInt32(o);
                    return result;
                }

                return 0;
            }
        }  
        public static int CantidadDeNumerosAOrdenar
        {
            get
            {
                object o = GetParametroConfig("CantidadDeNumerosAOrdenar");
                if (o != null)
                {
                    var result = Convert.ToInt32(o);
                    return result;
                }

                return 0;
            }
        }
        public static string ConexionDB
        {
            get
            {
                object o = GetParametroConfig("ConexionDB", true);
                if (o != null)
                {

                    return Convert.ToString(o);
                }

                return ("No existe conexion a la base de datos");
            }
        }

        public static string RutaImagenes
        {
            get
            {
                object o = GetParametroConfig("RutaImagenes", true);
                if (o != null)
                {

                    return Convert.ToString(o);
                }

                return ("No existe ruta de imagen");
            }
        }


    }
}
