using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace TheCellGame.user
{
    public partial class changePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("Yes"))
            {
                Response.Redirect("../login.aspx");
            }
            String result = Request.QueryString["PasswordChanged"];
            if (result == "true")
                passwdChangeResultLabel.Text = "Password has been changed successfully";

        }
        protected void ChangePasswd_Click(object sender, EventArgs e)
        {
            String oldPasswd = oldPassword.Text;
            String newPasswd = newPassword.Text;


            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            String query = "select count(*) from Users where username='" + Session["username"] + "' and password='" + oldPasswd + "'";

            SqlCommand cmd1 = new SqlCommand(query, conn);

            if ((int)cmd1.ExecuteScalar() == 0)
            {
                Response.Redirect("changePassword.aspx?PasswordChanged=" + "incorrectPassword");
            }
     
            query = "update Users SET password='" + newPasswd + "' where username='" + Session["username"] + "'";
            SqlCommand cmd2 = new SqlCommand(query, conn);
            cmd2.ExecuteNonQuery();

            Response.Redirect("changePassword.aspx?PasswordChanged=" + "true");
            conn.Close();
        }
    }
}