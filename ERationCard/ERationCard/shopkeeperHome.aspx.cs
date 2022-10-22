using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERationCard
{
    public partial class shopkeeperHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["shopkeeperId"] == null)
            {
                Response.Redirect("shopkeeperLogin.aspx", true);
            }
            showProducts();
        }

        protected void showProducts()
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
     
            try
            {
                using (con)
                {
                    string command = "Select * from Product";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //GridViewProduct.DataSource = rdr;
                    GridViewProduct.DataBind();
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
            string query = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Name", tbProductName.Text);
                        cmd.Parameters.AddWithValue("@Price", int.Parse(tbProductPrice.Text));
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
            showProducts();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["shopkeeperId"] = null ;
            Response.Redirect("shopkeeperLogin.aspx", true);
        }

        protected void btnGenerateBill_Click(object sender, EventArgs e)
        {
            Session["customerID"] = ddlCustomer.SelectedValue;
            Response.Redirect("GenerateBill.aspx",true);
        }

        protected void btnSelectCust_Click(object sender, EventArgs e)
        {
            lblCustId.Visible = true;
            ddlCustomer.Visible = true;
            btnGenerateBill.Visible = true;
        }

       
    }
}