using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace TheCellGame.admin
{
    public partial class viewApprovalRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("No"))
            {
                Response.Redirect("../login.aspx");
            }

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select *from Scenarios where approvalStatus=0";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ScenarioGridView.DataSource = rdr;
            ScenarioGridView.DataBind();
            conn.Close();
        }
        protected void ScenarioGridView_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ViewScenario")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int scenarioId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("approveScenario.aspx?scenario=" + scenarioId);
            }
        }
    }
}