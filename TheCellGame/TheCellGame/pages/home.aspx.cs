using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace TheCellGame.pages
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString);
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                Response.Write("error " + ex.ToString());
            }

            String query = "insert into Scenarios (name) values (@hello278)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
            
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select *from Scenarios";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            conn.Close();
            */

        }
        protected void LoginButton2_Click(object sender, EventArgs e)
        {
            /*
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            String username = "updateFromButtonClick";

            conn.Open();

            String query = "insert into Scenarios (name) values( '" + username + "')";

            SqlCommand myCommand = new SqlCommand(query, conn);

            myCommand.ExecuteNonQuery();
            Response.Redirect("pages/home.aspx");

            conn.Close();
            */
        }

    }
}