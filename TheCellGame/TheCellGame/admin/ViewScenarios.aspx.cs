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
    public partial class ViewScenarios : System.Web.UI.Page
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

            String query = "select *from Scenarios where approvalStatus=1";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ScenarioGridView.DataSource = rdr;
            ScenarioGridView.DataBind();
            conn.Close();

        }
        protected void AddScenario_Click(object sender, EventArgs e)
        {
            Response.Redirect("addScenario.aspx");
        }

        protected void ScenarioGridView_Command(object sender, CommandEventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            String query = "";

            if (e.CommandName == "EditScenario")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int scenarioId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("editScenario.aspx?scenario=" + scenarioId);
            }
            if (e.CommandName == "DeleteScenario")
            {
                conn.Open();
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int scenarioId = Convert.ToInt32(e.CommandArgument);

                query = "delete from Scenarios where scenarioId=" + scenarioId;
                SqlCommand myCommand = new SqlCommand(query, conn);
                myCommand.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("viewScenarios.aspx");
            }
        }
    }
}