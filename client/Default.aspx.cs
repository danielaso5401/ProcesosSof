using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.Odbc;
using System.Configuration;

namespace Cliente
{
    public partial class _Default : Page
    {
        Cliente.ServiceReference1.WebServiceOracleSoapClient obj = new Cliente.ServiceReference1.WebServiceOracleSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void validar_Click(object sender, EventArgs e)
        {
            string usu = v_usuario.Text;
            string contra = v_contra.Text;

            int num=obj.Login(usu,contra);
            if (num == 1)
            {
                Response.Redirect("About.aspx");
            }
            else
            {
                Response.Write("<script>alert('Contraseña Incorrecta')</script>");
            }
        }
    }
}