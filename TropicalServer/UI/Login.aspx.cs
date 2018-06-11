using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //this namespace is for sqlclient server  
using System.Configuration; // this namespace is add I am adding connection name in web config file config connection name  


namespace TropicalServer.UI
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Master.FindControl("NavigationMenu").Visible = false;
            //errlbl.Visible = false;
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                useridtextbox.Text = cookie["UserId"];
                passwordtextbox.Text = cookie["Password"];
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=jie;Initial Catalog=TropicalServer;Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM tblTropicalUser WHERE LoginID = @username AND Password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", useridtextbox.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", passwordtextbox.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = useridtextbox.Text.Trim();
                    if (rmbcheck.Checked)
                    {
                        //create cookie, and specify user id and password to store
                        HttpCookie cookie = new HttpCookie("UserInfo");
                        cookie["UserId"] = useridtextbox.Text;
                        cookie["Password"] = passwordtextbox.Text;

                        //write the cookie into the user machine
                        Response.Cookies.Add(cookie);
                    }
                    Response.Redirect("Orders.aspx");
                }
                else { errlbl.Visible = true; }
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
