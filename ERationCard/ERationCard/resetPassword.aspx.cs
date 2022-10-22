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
    public partial class resetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
            int id = int.Parse(Session["shopkeeperId"].ToString());
            string oldPswd = tbOldPswd.Text;
            bool isCorrect = checkOldPassword(oldPswd , id);
            if (isCorrect)
            {
                string query = "UPDATE Shopkeeper set [Password] = @Password , [HasResetPassword] = @HasResetPassword WHERE Id = " + id;
                try
                {
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@Password", tbNewPswd.Text);
                            cmd.Parameters.AddWithValue("@HasResetPassword", "True");
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("shopkeeperHome.aspx", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                Response.Write("Incorrect old Password");
            }
        }
    
        bool checkOldPassword(string oldPassword, int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
            string query = "Select Password from Shopkeeper WHERE Id = '" + id + "'AND Password = '" + oldPassword + " ' ";
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
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return false;
            }
        }

    }
}