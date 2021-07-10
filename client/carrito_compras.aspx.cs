using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.Odbc;
using System.Configuration;
using System.Globalization;

namespace Cliente
{
    public partial class carrito_compras : System.Web.UI.Page
    {
        Cliente.ServiceReference1.WebServiceOracleSoapClient obj = new Cliente.ServiceReference1.WebServiceOracleSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
            String final;
            final = obj.lista_productos_ventas();
            DataTable ds = JObject.Parse(final)["Table"].ToObject<DataTable>();
            lista_compras.DataSource = ds;
            lista_compras.DataBind();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            lista_compras.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = lista_compras.Rows[e.RowIndex];
            string cant = (row.FindControl("txtCantidad") as TextBox).Text;
            string nam = (row.FindControl("lblName") as TextBox).Text;
            string prec = (row.FindControl("lblPrecio") as TextBox).Text;
            
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            lista_compras.EditIndex = -1;
            this.BindGrid();
        }
        


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            /*if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }*/
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }


    }
}