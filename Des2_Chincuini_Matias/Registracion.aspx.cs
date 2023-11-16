using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Des2_Chincuini_Matias
{
    public partial class Registracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie1 = new HttpCookie("email", TextBox1.Text);
            cookie1.Expires = DateTime.Now.AddSeconds(30);
            Response.Cookies.Add(cookie1);
            

            Session["username"]=TextBox2.Text;
            Response.Redirect(Request.RawUrl);
        }
    }
}