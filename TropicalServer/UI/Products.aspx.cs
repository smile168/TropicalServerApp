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
    public partial class Products : System.Web.UI.Page
    {
        string btnProCat = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = GetData();
                rpProCat.DataSource = ds;
                rpProCat.DataBind();
            }
        }

        protected void Page_LoadComplete(Object sender, EventArgs e)
        {
            DataTable dsGridView = GetGridViewData();
            gvProductItem.DataSource = dsGridView;
            gvProductItem.DataBind();
        }

        private DataSet GetData()
        {
            String CS = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ItemTypeDescription from tblItemType", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        private DataTable GetGridViewData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string cmdStr = "select ItemNumber,ItemDescription,PrePrice, tblItemType.ItemTypeDescription " +
                            "from tblItem " +
                            "Left Join tblItemType on tblItem.ItemType = tblItemType.ItemTypeID " +
                            "Where tblItemType.ItemTypeDescription = @itemDescription";
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                cmd.Parameters.AddWithValue("@itemDescription", btnProCat);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
        }


        protected void btnProCat_Click(Object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            btnProCat = btn.CommandArgument;

        }

        protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }


    }
}