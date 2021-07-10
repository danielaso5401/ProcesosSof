using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OracleClient;
using System.Data;
using Newtonsoft.Json;

namespace Webservice
{
    /// <summary>
    /// Descripción breve de WebServiceOracle
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceOracle : System.Web.Services.WebService
    {
 

        [WebMethod(BufferResponse = true)]
        public object Prueba(int id, string name)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();
            
            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.VarChar;
            param_name.Value = name;

            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = id;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "AGREGAR_CATEOGIRA";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("n_idcat", OracleType.Number).Value = param_id.Value;
            cmd.Parameters.Add("n_categoriag", OracleType.VarChar).Value = param_name.Value;
            cmd.ExecuteNonQuery();
            
            return "se logro";
        }

        [WebMethod(BufferResponse = true)]
        public string Cliente_Select_Full()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();

            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.Cursor;
            cmd.CommandText = "most_client";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod(BufferResponse = true)]
        public string lista_productos()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();

            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.Cursor;
            cmd.CommandText = "most_productos";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod(BufferResponse = true)]
        public string lista_productos_ventas()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();

            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.Cursor;
            cmd.CommandText = "most_prod_vent";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod(BufferResponse = true)]
        public string Reporte_ventas(String page)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();

            OracleParameter tpago = new OracleParameter();
            tpago.OracleType = OracleType.VarChar;
            tpago.Value = page;

            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.Cursor;
            cmd.CommandText = "rep_ventas";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_pago", OracleType.VarChar).Value = page;
            cmd.Parameters.Add("c_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod(BufferResponse = true)]
        public void Cliente_Delete(int ide)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();
            

            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = ide;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "delete_client";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("n_id", OracleType.Number).Value = param_id.Value;
            cmd.ExecuteNonQuery();

        }

        [WebMethod(BufferResponse = true)]
        public void Producto_Delete(int ide)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();


            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = ide;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "delete_prod";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("n_id", OracleType.Number).Value = param_id.Value;
            cmd.ExecuteNonQuery();
        }

        [WebMethod(BufferResponse = true)]
        public void Cliente_Update(int ide, string name, string direc, int cel, string email)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();


            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = ide;

            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.VarChar;
            param_name.Value = name;

            OracleParameter param_dire = new OracleParameter();
            param_dire.OracleType = OracleType.VarChar;
            param_dire.Value = direc;

            OracleParameter param_cel = new OracleParameter();
            param_cel.OracleType = OracleType.Number;
            param_cel.Value = cel;

            OracleParameter param_email = new OracleParameter();
            param_email.OracleType = OracleType.VarChar;
            param_email.Value = email;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "update_cliente";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("n_id", OracleType.Number).Value = param_id.Value;
            cmd.Parameters.Add("c_name", OracleType.VarChar).Value = param_name.Value;
            cmd.Parameters.Add("c_direc", OracleType.VarChar).Value = param_dire.Value;
            cmd.Parameters.Add("n_celular", OracleType.Number).Value = param_cel.Value;
            cmd.Parameters.Add("c_emal", OracleType.VarChar).Value = param_email.Value;
            cmd.ExecuteNonQuery();

        }

        [WebMethod(BufferResponse = true)]
        public void Producto_Update(int ide, string name_prod, int cant, float prec, int prov, int cat)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();


            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = ide;

            OracleParameter nameprod = new OracleParameter();
            nameprod.OracleType = OracleType.VarChar;
            nameprod.Value = name_prod;

            OracleParameter cantidad = new OracleParameter();
            cantidad.OracleType = OracleType.Number;
            cantidad.Value = cant;

            OracleParameter precio = new OracleParameter();
            precio.OracleType = OracleType.Float;
            precio.Value = prec;

            OracleParameter prove = new OracleParameter();
            prove.OracleType = OracleType.Number;
            prove.Value = prov;

            OracleParameter cate = new OracleParameter();
            cate.OracleType = OracleType.Number;
            cate.Value = cat;



            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "update_produc";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("n_id", OracleType.Number).Value = param_id.Value;
            cmd.Parameters.Add("c_name", OracleType.VarChar).Value = nameprod.Value;
            cmd.Parameters.Add("n_cant", OracleType.VarChar).Value = cantidad.Value;
            cmd.Parameters.Add("f_pri", OracleType.VarChar).Value = precio.Value;
            cmd.Parameters.Add("n_prov", OracleType.VarChar).Value = prove.Value;
            cmd.Parameters.Add("n_cat", OracleType.VarChar).Value = cate.Value;
            cmd.ExecuteNonQuery();

        }

        [WebMethod(BufferResponse = true)]
        public void Cliente_Insert(int ide, string name, string direc, int cel, string email)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();


            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = ide;

            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.VarChar;
            param_name.Value = name;

            OracleParameter param_dire = new OracleParameter();
            param_dire.OracleType = OracleType.VarChar;
            param_dire.Value = direc;

            OracleParameter param_cel = new OracleParameter();
            param_cel.OracleType = OracleType.Number;
            param_cel.Value = cel;

            OracleParameter param_email = new OracleParameter();
            param_email.OracleType = OracleType.VarChar;
            param_email.Value = email;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "insert_cliente";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("n_id", OracleType.Number).Value = param_id.Value;
            cmd.Parameters.Add("c_name", OracleType.VarChar).Value = param_name.Value;
            cmd.Parameters.Add("c_direc", OracleType.VarChar).Value = param_dire.Value;
            cmd.Parameters.Add("n_celular", OracleType.Number).Value = param_cel.Value;
            cmd.Parameters.Add("c_emal", OracleType.VarChar).Value = param_email.Value;
            cmd.ExecuteNonQuery();

        }

        [WebMethod(BufferResponse = true)]
        public void Producto_Insert(string name_prod, int cant, float prec, int prov, int cat)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            OracleParameter nameprod = new OracleParameter();
            nameprod.OracleType = OracleType.VarChar;
            nameprod.Value = name_prod;

            OracleParameter cantidad = new OracleParameter();
            cantidad.OracleType = OracleType.Number;
            cantidad.Value = cant;

            OracleParameter precio = new OracleParameter();
            precio.OracleType = OracleType.Float;
            precio.Value = prec;

            OracleParameter prove = new OracleParameter();
            prove.OracleType = OracleType.Number;
            prove.Value = prov;

            OracleParameter cate = new OracleParameter();
            cate.OracleType = OracleType.Number;
            cate.Value = cat;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "insert_produc";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_name", OracleType.VarChar).Value = nameprod.Value;
            cmd.Parameters.Add("n_cant", OracleType.VarChar).Value = cantidad.Value;
            cmd.Parameters.Add("f_pri", OracleType.VarChar).Value = precio.Value;
            cmd.Parameters.Add("n_prov", OracleType.VarChar).Value = prove.Value;
            cmd.Parameters.Add("n_cat", OracleType.VarChar).Value = cate.Value;
            cmd.ExecuteNonQuery();

        }

        [WebMethod(BufferResponse = true)]
        public int Login(String usuario, String contra)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            OracleParameter param_usu = new OracleParameter();
            param_usu.OracleType = OracleType.VarChar;
            param_usu.Value = usuario;

            OracleParameter param_contra = new OracleParameter();
            param_contra.OracleType = OracleType.VarChar;
            param_contra.Value = contra;

            //OracleParameter param_val = new OracleParameter();
            //param_val.OracleType = OracleType.Number;
            //param_val.Value = 0;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "login_usu";

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_usuario", OracleType.VarChar).Value = param_usu.Value;
            cmd.Parameters.Add("c_contra", OracleType.VarChar).Value = param_contra.Value;
            cmd.Parameters.Add("n_resp", OracleType.Number).Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            /*string res;
            res = cmd.Parameters["n_resp"].Value.ToString();*/
            int res = int.Parse(cmd.Parameters["n_resp"].Value.ToString());

            return res;
             
        }


    }
}
