using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERationCard
{
    public partial class GenerateBill : System.Web.UI.Page
    {
        static List<KeyValuePair<string, int>> selectedProducts = new List<KeyValuePair<string, int>>();
        static int totalAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["shopkeeperId"] == null){
                Response.Redirect("shopkeeperLogin.aspx",true);
            }
            if(Session["customerId"] == null)
            {
                Response.Redirect("shopkeeperHome.aspx", true);
            }
            if (Session["BillId"] == null)
            {
                var random = new Random();
                int randNum = random.Next(101111, 999999);
                Session["BillId"] = randNum;
            }
            //tbPrdPrice.Text = ddlProduct.Text;
            //chooseDataSource();
        }

       /* protected void chooseDataSource()
        {
            //Select * from product where Name not in List selectedProducts
            //Datasource of ddlProduct = rdr["Name"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
            try
            {
                using (con)
                {
                    List<string> allKeys = (from prd in selectedProducts select prd.Key).ToList();
                    string keys = String.Join("', '", allKeys.Select(x => x.ToString()));
                    string command = String.Format("Select Name from Product  where Name NOT IN (SELECT Name from Product where Name IN ('" + keys + " ')) ");
                    SqlCommand cmd = new SqlCommand(command, con);
                    Response.Write(command);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    Response.Write(rdr.HasRows);
                    ddlProduct.DataSource = rdr;
                    ddlProduct.DataBind();
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select * from product with selected Product ID/Name
            //From that give value of price in tbPrdAmt
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "Select * from Product where Name = '" + ddlProduct.SelectedValue + " ' ";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read()){
                        tbPrdPrice.Text = rdr["Price"].ToString();
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            selectedProducts.Clear();
            Session["BillId"] = null;
            Response.Redirect("shopkeeperHome.aspx",true);
        }

        protected void btnAddPrd_Click(object sender, EventArgs e)
        {
            try
            {
                selectedProducts.Add(new KeyValuePair<string, int>(ddlProduct.SelectedValue, int.Parse(tbPrdAmt.Text)));
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
                string query = "INSERT INTO Bills (BillId, CustomerId, ProductName, ProductWeight, ProductRate, ProductTotalPrice) VALUES (@BillId, @CustomerId, @ProductName, @ProductWeight, @ProductRate, @ProductTotalPrice)";
                try
                {
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@BillId", Session["BillId"]);
                            cmd.Parameters.AddWithValue("@CustomerId", Session["customerId"]);
                            cmd.Parameters.AddWithValue("@ProductName", ddlProduct.SelectedValue);
                            cmd.Parameters.AddWithValue("@ProductWeight", int.Parse(tbPrdAmt.Text));
                            cmd.Parameters.AddWithValue("@ProductRate", int.Parse(tbPrdPrice.Text));
                            int totalPrice = int.Parse(tbPrdAmt.Text) * int.Parse(tbPrdPrice.Text);
                            cmd.Parameters.AddWithValue("@ProductTotalPrice", totalPrice);
                            totalAmount += totalPrice;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Write("Added the Product");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                //chooseDataSource();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }    
            /*foreach (var val in selectedProducts)
            {
                Response.Write(val);
            }*/
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (selectedProducts.Count == 0)
            {
                Response.Write("Add a product!!");
            }
            else
            {
                //View bill that displays data
                tbCustID.Visible = true;
                lblCustId.Visible = true;
                btnBack.Visible = true;
                if (Session["customerId"] != null)
                {
                    tbCustID.Text = Session["customerId"].ToString();
                }
                //GridView 
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
                try
                {
                    using (con)
                    {
                        /*List<string> allKeys = (from prd in selectedProducts select prd.Key).ToList();
                        string keys = String.Join("', '", allKeys.Select(x => x.ToString()));
                        string command = String.Format("Select Name, Price from Product  where Name IN ('" + keys + " ') ");
                        SqlCommand cmd = new SqlCommand(command, con);
                        con.Open();
                        //Response.Write(command);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        GridView1.Visible = true;
                        GridView1.DataSource = rdr;
                        
                        List<int> allValues = (from prd in selectedProducts select prd.Value).ToList();
                        GridView1.DataBind();
                        
                        rdr.Close();*/
                        lblBillId.Visible = true;
                        tbBillId.Visible = true;
                        tbBillId.Text = Session["BillId"].ToString();
                        string command = "Select ProductName, ProductRate, ProductWeight, ProductTotalPrice from Bills where BillId =   " + int.Parse(Session["BillId"].ToString()) ;
                        //Response.Write(command);
                        SqlCommand cmd = new SqlCommand(command, con);
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        //Response.Write(rdr.HasRows);
                        GridView1.DataSource = rdr;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        btnCancelBill.Visible = true;
                        rdr.Close();
                        tbTotalAmt.Text = totalAmount.ToString();
                        tbTotalAmt.Visible = true;
                        lblTotalAmt.Visible = true;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void btnCancelBill_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["eRationCard"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "DELETE from Bills where CustomerId = " + int.Parse(Session["CustomerId"].ToString()) + " and BillId =   " + int.Parse(Session["BillId"].ToString());
                    //Response.Write(command);
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //Response.Write(rdr.HasRows);
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    rdr.Close();
                    lblCustId.Visible = false;
                    tbCustID.Visible = false;
                    lblTotalAmt.Visible = false;
                    tbTotalAmt.Visible = false;
                    btnCancelBill.Visible = false;
                    btnBack.Visible = false;
                    lblBillId.Visible = false;
                    tbBillId.Visible = false;
                    Session["BillId"] = null;
                    totalAmount = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("shopkeeperHome.aspx", true);
        }
    }
}