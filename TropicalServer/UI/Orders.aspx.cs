using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace TropicalServer.UI
{

    public partial class Orders : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<String> ddlOrderdatelList = getOrderDateList();
                ddlOrderDate.DataSource = ddlOrderdatelList;
                ddlOrderDate.DataBind();
                GetGridViewData();
            }
            else
            {
                //GetGridViewData();
            }
        }

        //protected void Page_LoadComplete(Object sender, EventArgs e)
        //{
        //    DataTable dtgvOrders = GetGridViewData();
        //    gvOrders.DataSource = dtgvOrders;
        //    gvOrders.DataBind();
        //}

        protected List<string> getOrderDateList()
        {
            List<String> ddlOrderDateList = new List<string>();
            ddlOrderDateList.Add("");
            ddlOrderDateList.Add("Today");
            ddlOrderDateList.Add("Last 7 Days");
            ddlOrderDateList.Add("Last 1 Month");
            ddlOrderDateList.Add("Last 6 Months");
            return ddlOrderDateList;
        }

        private void GetGridViewData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                //string cmdStr = "EXEC TropicalOrderGridData @CustomerID=300000, @CustomerName='Supremo SUpermarket #3', @SalesManager='Benjamin Parra'";
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TropicalOrderGridData";
                cmd.Connection = con;

                //cmd.Parameters.AddWithValue("@OrderDate", ddlOrderDate.SelectedItem.Text);
                if (ddlOrderDate.Text != "")
                {
                    cmd.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = ddlOrderDate.Text;
                }
                if (ddlSalesManager.Text != "")
                {
                    cmd.Parameters.Add("@SalesManager", SqlDbType.VarChar).Value = ddlSalesManager.Text;
                }
                if (CustName.Text != "")
                {
                    cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = CustName.Text;
                }
                
                
                
                lblTest.Text = CustName.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                gvOrders.DataSource = ds;
                gvOrders.DataBind();
                //
                //for (int i = 0; i < gvOrders.Rows.Count; i++)
                //{
                //    System.Web.UI.WebControls.TableCell cell = new System.Web.UI.WebControls.TableCell();
                //    System.Web.UI.WebControls.LinkButton btn = new System.Web.UI.WebControls.LinkButton();
                //    btn.Text = "View";
                //    cell.Controls.Add(btn);
                //    gvOrders.Rows[i].Cells.Add(cell);
                //}
            }
        }

        protected void CustName_TextChanged(object sender, EventArgs e)
        {
            GetGridViewData();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int orderID = Convert.ToInt32(gvOrders.DataKeys[e.RowIndex].Values[0]);
 
            String CS = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tblOrder where OrderID =@OrderID "))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }               
            }
            this.GetGridViewData();
        }

        protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOrders.EditIndex = e.NewEditIndex;
            this.GetGridViewData();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            gvOrders.EditIndex = -1;
            GetGridViewData();
            
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //GridViewRow row = gvOrders.Rows[e.RowIndex];
            string orderID = (gvOrders.DataKeys[e.RowIndex].Values[0]).ToString();
            TextBox tracknumber = (TextBox)gvOrders.Rows[e.RowIndex].FindControl("txtTrackNum");
            TextBox orderdate = (TextBox)gvOrders.Rows[e.RowIndex].FindControl("txtOrderDate");
            Label custId = (Label)gvOrders.Rows[e.RowIndex].FindControl("lblCustId");
            TextBox custname = (TextBox)gvOrders.Rows[e.RowIndex].FindControl("txtCustName");
            TextBox address = (TextBox)gvOrders.Rows[e.RowIndex].FindControl("txtAddr");
            TextBox route = (TextBox)gvOrders.Rows[e.RowIndex].FindControl("txtRoute");            
            String CS = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;       
            using (SqlConnection con = new SqlConnection(CS))
            {
                string cmdStrOrder = "UPDATE tblOrder SET OrderTrackingNumber ='" + tracknumber.Text + "', OrderDate ='" + orderdate.Text + "' WHERE OrderID=" + orderID + " UPDATE tblCustomer SET CustName ='" + custname.Text + "', CustOfficeAddress1 ='" + address.Text + "', CustRouteNumber =" + route.Text + "WHERE CustNumber =" + custId.Text;
                SqlCommand cmd = new SqlCommand(cmdStrOrder, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                gvOrders.EditIndex = -1;
                GetGridViewData();

            }

        }

        protected void ddlSalesManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGridViewData();
        }

        protected void ddlOrderDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGridViewData();
        }

        



    }
}