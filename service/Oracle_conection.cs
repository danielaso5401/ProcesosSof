using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//using Oracle.DataAccess;
using System.Data;
using System.Data.OracleClient;
using Newtonsoft.Json;

namespace Webservice
{
    public class Oracle_conection
    {
        OracleConnection oc;
        string oradb = "DATA SOURCE=xe; USER ID=SYSTEM; PASSWORD=12345678"; // establece conexion con el servidor
        //string oradb = "DATA SOURCE=xe; USER ID=OFFICEMARKET; PASSWORD=officemarket"; // establece conexion con el servidor

        public Oracle_conection()
        {
        }

        public void EstablecerConnection()
        {
            oc = new OracleConnection(oradb);
            oc.Open();


        }

        public OracleConnection GetConexion()
        {
            return oc;
        }
    }
}