using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;


namespace TheCellGame.user
{
    public partial class play : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("Yes"))
            {
                Response.Redirect("../login.aspx");
            }

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select *from DecisionTrees where isApproved=1";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            scenarioDisplayGridView.DataSource = rdr;
            scenarioDisplayGridView.DataBind();
            conn.Close();
        }
        protected void playButton_Click(object sender, EventArgs e)
        {
            String decisionTree = (sender as Button).Text;

            Response.Redirect("playScenario.aspx?decisionTree=" + decisionTree + "&question=1");
        }
    }

}