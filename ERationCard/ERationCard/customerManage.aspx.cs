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
    public partial class customerManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null)
            {
                Response.Redirect("adminLogin.aspx",true);
            }
            showCustomer();
        }

        protected void showCustomer()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;

            try
            {
                using (con)
                {
                    string command = "Select * from Customer";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //GridViewShopkeeper.DataSource = rdr;
                    GridViewCust.DataBind();
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
            string query = "INSERT INTO Customer (Name, Gender, DOB, Address, contactNo, City) VALUES (@Name, @Gender, @DOB, @Address, @contactNo, @City)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Name", tbCustomerName.Text);
                        cmd.Parameters.AddWithValue("@Address", tbCustomerAddress.Text);
                        cmd.Parameters.AddWithValue("@City", tbCustomerCity.Text);
                        cmd.Parameters.AddWithValue("@Gender", tbCustomerGender.Text);
                        cmd.Parameters.AddWithValue("@DOB", tbCustomerDOB.Text);
                        long mNo = long.Parse(tbCustomerNumber.Text);
                        if (mNo < 6300000000)
                        {
                            throw new Exception("Invalid Mobile Number");
                        }
                        cmd.Parameters.AddWithValue("@contactNo", long.Parse(tbCustomerNumber.Text));
                        
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
            showCustomer();
        }
        protected void btnAdminLogOut_Click(object sender, EventArgs e)
        {
            Session["user"]=null;
            Response.Redirect("adminLogin.aspx");
        }
    }
}