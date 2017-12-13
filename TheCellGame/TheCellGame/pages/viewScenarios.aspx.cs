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
    public partial class viewScenarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select *from Scenarios";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            scenarioGridView.DataSource = rdr;
            scenarioGridView.DataBind();
            conn.Close();

        }
        protected void AddScenario_Click(object sender, EventArgs e)
        {
            Response.Redirect("scenarios.aspx");
        }
    }
}