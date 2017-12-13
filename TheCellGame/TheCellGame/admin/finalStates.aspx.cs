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
    public partial class finalStates : System.Web.UI.Page
    {
        int decisionTreeId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("No"))
            {
                Response.Redirect("../login.aspx");
            }

            decisionTreeId = Convert.ToInt32(Request.QueryString["decisionTreeId"]);

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();


            String   query = "select * from Linking where decisionTreeId=" + decisionTreeId;
            SqlCommand myCmd = new SqlCommand(query, conn);

            SqlDataReader myRdr = myCmd.ExecuteReader();


            scenarioDescGridView.DataSource = myRdr;
            scenarioDescGridView.DataBind();

            conn.Close();


        }
       
        protected void SelectedOption_Click(object sender, CommandEventArgs e)
        {

            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

            int questionId = Convert.ToInt32(commandArgs[0]);
            String option = commandArgs[1];

            Response.Redirect("addFinalState.aspx?decisionTreeId=" + decisionTreeId + "&questionId=" + questionId + "&option=" + option);

        }
    }
}