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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
            string query = "Select * from Shopkeeper WHERE Id = '" + int.Parse(tbShKId.Text) + "'AND Password = '" + tbShKpswd.Text + " ' ";
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        Session["shopkeeperId"] = tbShKId.Text;
                        //ViewState["UserID"] = tbShKId.Text;
                        //Response.Write(rdr["HasResetPassword"].GetType().ToString());
                        if(rdr["HasResetPassword"].ToString() == "False")
                        {
                            Response.Redirect("resetPassword.aspx", true);
                        }
                        Response.Redirect("shopkeeperHome.aspx", true);
                    }
                    else
                    {
                        Response.Write("No such Shopkeeper found");
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnGotoIndex_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx", true);
        }
    }
}