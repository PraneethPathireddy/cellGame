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
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String result = Request.QueryString["Registered"];
            if (result == "false")
                regResultLabel.Text = "user already exists with this username";

        }
        protected void RegButton_Click(object sender, EventArgs e)
        {
            String firstName = regFirstName.Text;
            String lastName = regLastName.Text;
            String username = regUsername.Text;
            String password = regPassword.Text;

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            String query = "select count(*) from Users where username='" + username + "'";

            SqlCommand cmd1 = new SqlCommand(query, conn);

            if ((int)cmd1.ExecuteScalar() == 1)
            {
                Response.Redirect("registration.aspx?Registered=" + "false");
            }

            query = "insert into  Users(username, firstName, secondName, password, isAdmin) " +
                            "values( '" + username + "', '" + firstName + "', '" + lastName + "', '" + password + "', 0)";

            SqlCommand cmd2 = new SqlCommand(query, conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
            Session["Logged"] = "Yes";
            Session["username"] = username;
            Session["isAdmin"] = "No";
            Response.Redirect("user/home.aspx");
        }
    }
}