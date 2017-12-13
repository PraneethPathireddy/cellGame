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
    public partial class viewDecisionTrees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("No"))
            {
                Response.Redirect("../login.aspx");
            }

            if (Request.QueryString["deleted"] == "true")
            {
                deleteLabel.Text = "Scenario has been deleted";
            }


            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select *from DecisionTrees where isApproved=1";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DecisionTreeGridView.DataSource = rdr;
            DecisionTreeGridView.DataBind();
            conn.Close();

        }
        protected void AddDecsionTree_Click(object sender, EventArgs e)
        {
            Response.Redirect("addDecisionTree.aspx");
        }
        protected void DecisionTreeGridView_Command(object sender, CommandEventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            String query = "";

            if (e.CommandName == "EditDecsionTree")
            {
                /*
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int scenarioId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("editScenario.aspx?scenario=" + scenarioId);
                */
            }
            if (e.CommandName == "DeleteDecisionTree")
            {
                
                conn.Open();
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int decisionTreeId = Convert.ToInt32(e.CommandArgument);

                query = "delete from Linking where decisionTreeId=" + decisionTreeId;
                SqlCommand myCommand = new SqlCommand(query, conn);
                myCommand.ExecuteNonQuery();

                query = "delete from decisionTreeFinalState where decisionTreeId=" + decisionTreeId;
                SqlCommand myCommand3 = new SqlCommand(query, conn);
                myCommand3.ExecuteNonQuery();


                query = "delete from DecisionTrees where decisionTreeId=" + decisionTreeId;
                SqlCommand myCommand2 = new SqlCommand(query, conn);
                myCommand2.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("viewDecisionTrees.aspx?deleted=" + "true");

            }
        }
    }
}