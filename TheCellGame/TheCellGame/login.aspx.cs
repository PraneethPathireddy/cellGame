using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace TheCellGame
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginUsername.Focus();
            if (Session["Logged"].Equals("Yes"))
            {
                if (Session["isAdmin"].Equals("Yes"))
                {
                    Response.Redirect("admin/home.aspx");
                }
                else
                {
                    Response.Redirect("user/home.aspx");
                }
                return;
            }
           
            String result = Request.QueryString["loginAttempt"];
            if (result == "failed")
                loginResultLabel.Text = "Incorrect username or Password";
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            String username = loginUsername.Text;
            String password = loginPassword.Text;
            int count = 0;

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select count(*) from Users where username='" + username + "' and password='" + password + "'" ;

            count = GetRowCount(query, conn);


            if (count == 0)
            {
                Response.Redirect("login.aspx?loginAttempt=" + "failed");

            }
            else
            {
                query = "select count(*) from Users where username='" + username + "' and isAdmin=1";

                count = GetRowCount(query, conn);
                Session["Logged"] = "Yes";
                Session["username"] = username;
                if (count == 0)
                {
                    Response.Redirect("user/home.aspx");
                }
                else
                {
                    Session["isAdmin"] = "Yes";
                    Response.Redirect("admin/home.aspx");
                }
            }

            conn.Close();
        }

        protected void RegButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("registration.aspx");
        }


        protected int GetRowCount(String query, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            return (int)cmd.ExecuteScalar();
  
        }

    }
}