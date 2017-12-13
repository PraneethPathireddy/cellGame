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
    public partial class addFinalState : System.Web.UI.Page
    {
        int decisionTreeId = 0;
        int questionId = 0;
        String option = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("No"))
            {
                Response.Redirect("../login.aspx");
            }
            decisionTreeId = Convert.ToInt32(Request.QueryString["decisionTreeId"]);
            questionId = Convert.ToInt32(Request.QueryString["questionId"]);
            option = Request.QueryString["option"];
        }
        protected void AddFinalState_Click(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);
            
            conn.Open();

            String finalStateStr = finalState.Value.Trim();

            String query = "";

            query = "select count(*) from decisionTreeFinalState where decisionTreeId = " + decisionTreeId + " and questionId = " + questionId;

            SqlCommand cmd = new SqlCommand(query, conn);

            if ((int)cmd.ExecuteScalar() > 0)
            {
                if (option == "option1")
                {
                    query = "Update decisionTreeFinalState set option1FinalState='" + finalStateStr + "' where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId;
                }
                else
                {
                    query = "Update decisionTreeFinalState set option2FinalState='" + finalStateStr + "' where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId;
                }


            }
            else
            {
                if (option == "option1")
                {
                    query = "insert into decisionTreeFinalState (decisionTreeId, questionId, option1FinalState, option2FinalState) " +
                                 "values(" + decisionTreeId + ", " + questionId + ", '" + finalStateStr + "', 'no final state')";

                }
                else
                {
                    query = "insert into decisionTreeFinalState (decisionTreeId, questionId, option1FinalState, option2FinalState) " +
                                "values(" + decisionTreeId + ", " + questionId + ", 'no final state', '" + finalStateStr + "')";
                }
            }
            SqlCommand myCmd = new SqlCommand(query, conn);

            myCmd.ExecuteNonQuery();

            conn.Close();

            Response.Redirect("finalStates.aspx?decisionTreeId=" + decisionTreeId);

        }
    }
}