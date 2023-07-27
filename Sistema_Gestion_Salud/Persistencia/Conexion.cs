using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Controlador
{

    public class Conexion
    {
        AppSettingsReader conf = new AppSettingsReader();
        OleDbConnection conn;
        private static readonly ILog logger = LogManager.GetLogger(typeof(Conexion));

        public OleDbConnection getConexion()
        {

            string StrConexion = ConfigurationManager.ConnectionStrings["Config.DB"].ConnectionString;
            conn = new OleDbConnection(StrConexion);
            conn.Open();
            return conn;
        }
        public string obtenerCon()
        {
            try
            {
                string StrConexion = "Provider=sqloledb;" + ConfigurationManager.ConnectionStrings["Config.DB"].ConnectionString;

                string[] conexion = StrConexion.Split(';');



                return conexion[1] + ";" + conexion[2] + ";" + conexion[3] + ";" + conexion[4];
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " LoginButton_Click - CONEXION.CS", ex);
                return "";
            }



        }
        public OleDbConnection cerrar()
        {
            conn.Close();
            return conn;

        }

    }
}

