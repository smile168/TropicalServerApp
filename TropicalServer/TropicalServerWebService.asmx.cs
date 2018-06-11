using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace TropicalServer
{
    /// <summary>
    /// Summary description for TropicalServerWebService
    /// </summary>
    [WebService(Namespace = "http://TropicalServer.com/WebService")]
    // **Uniquely identify the web service we developed put online comparing with others' web service
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TropicalServerWebService : System.Web.Services.WebService
    {
        [WebMethod]
        //putting WebMethod attribute will enable the method under this attribute to be exposed to the users 
        public List<string> getCustName(string prefixText)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.CommandText = "GetCustName";

                cmd.Connection = con;

                cmd.Parameters.Add("@CustName", SqlDbType.VarChar).Value = prefixText;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                List<string> lst = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lst.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                return lst;
            }
        }


    }
}
