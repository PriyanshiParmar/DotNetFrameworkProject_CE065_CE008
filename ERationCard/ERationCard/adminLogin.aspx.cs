using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERationCard
{
    public partial class adminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(tbAdminName.Text == "admin" && tbAdminPswd.Text == "asd138")
            {
                Session["user"] = "Admin";
                Response.Redirect("adminHome.aspx", true);
            }
            Response.Write("Invalid username or password");
        }
    }
}