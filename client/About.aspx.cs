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
    
    public partial class About : Page
    {


        Cliente.ServiceReference1.WebServiceOracleSoapClient obj = new Cliente.ServiceReference1.WebServiceOracleSoapClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
                this.BindGrid();
            }
        }
        
        
        
        protected void btnList_Click(object sender, EventArgs e)
        {
            String final;
            final = obj.lista_productos();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(final,typeof(DataTable));
            DataTable ds = JObject.Parse(final)["Table"].ToObject<DataTable>();
            //GridView1.DataSource = ds;
            //GridView1.DataBind();
        
        }

        protected void BindGrid()
        {
            String final;
            final = obj.lista_productos();
            DataTable ds = JObject.Parse(final)["Table"].ToObject<DataTable>();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Insert(object sender, EventArgs e)
        {
            
            string name = TextName.Text;
            string cant = TextCantidad.Text;
            string prec = TextPrecio.Text;
            string prov = TextProveedor.Text;
            string cate = TextCategoria.Text;

            int num_cat = Int32.Parse(cant);
            int num_prec = Int32.Parse(prec);
            int num_prov = Int32.Parse(prov);
            int num_cate = Int32.Parse(cate);

            obj.Producto_Insert(name, num_cat, num_prec, num_prov, num_cate);
            
            this.BindGrid();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            string name = (row.FindControl("txtname") as TextBox).Text;
            string cant = (row.FindControl("txtCantidad") as TextBox).Text;
            string prec = (row.FindControl("txtPrecio") as TextBox).Text;
            string prov = (row.FindControl("txtIdProv") as TextBox).Text;
            string cate = (row.FindControl("txtIdCat") as TextBox).Text;

            int num_cant= Int32.Parse(cant);
            float num_prec = float.Parse(prec, CultureInfo.InvariantCulture.NumberFormat);
            
            int num_prov = Convert.ToInt32(prov);
            int num_cate = Convert.ToInt32(cate);

            obj.Producto_Update(customerId, name, num_cant, num_prec, num_prov, num_cate);

            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            obj.Producto_Delete(productId);
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