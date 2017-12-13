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
    public partial class userMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select *from Users where username='" + Session["username"] + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                nameDisplayLabel.Text = (String)rdr["firstName"] + " " + (String)rdr["secondName"];
            }

            conn.Close();
        }
    }
}