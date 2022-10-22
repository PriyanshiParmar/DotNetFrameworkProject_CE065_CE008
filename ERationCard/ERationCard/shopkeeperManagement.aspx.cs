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
    public partial class shopkeeperManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null)
            {
                Response.Redirect("adminLogin.aspx");
            }
            showShopkeeper();
        }

        protected void showShopkeeper()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;

            try
            {
                using (con)
                {
                    string command = "Select Id, Name, Address, mobileNo, City from Shopkeeper";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //GridViewShopkeeper.DataSource = rdr;
                    GridViewShopkeeper.DataBind();
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void btnAddShopkeeper_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
            string query = "INSERT INTO Shopkeeper (Name, Address, mobileNo, City, Password) VALUES (@Name, @Address, @mobileNo, @City, @Password)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Name", tbShopkeeperName.Text);
                        cmd.Parameters.AddWithValue("@Address", tbShopkeeperAddress.Text);
                        cmd.Parameters.AddWithValue("@City", tbShopkeeperCity.Text);
                        long mNo = long.Parse(tbShopkeeperNumber.Text);
                        if(mNo < 6300000000)
                        {
                            throw new Exception("Invalid Mobile Number");
                        }
                        cmd.Parameters.AddWithValue("@mobileNo", long.Parse(tbShopkeeperNumber.Text));
                        var random = new Random();
                        int randNum = random.Next(101, 999);
                        cmd.Parameters.AddWithValue("@Password", randNum);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            showShopkeeper();
        }

        protected void btnAdminLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("adminLogin.aspx");
        }
    }
    
}