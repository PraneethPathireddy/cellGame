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
    public partial class addQuestion : System.Web.UI.Page
    {
        int decisionTreeId = 0;
        String decisionTreeName = "";
        int questionId = 0;


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

            String query = "select count(*) from Linking where decisionTreeId=" + decisionTreeId;
            SqlCommand myCmd2 = new SqlCommand(query, conn);

            if ((int)myCmd2.ExecuteScalar() > 0)
            {
                addFirstQuestion.Visible = false;
            }
            else
            {
                AddFinalStates.Visible = false;
            }
           

            query = "select * from Linking where decisionTreeId=" + decisionTreeId; 
            SqlCommand myCmd = new SqlCommand(query, conn);

            SqlDataReader myRdr = myCmd.ExecuteReader();
       
              
            scenarioDescGridView.DataSource = myRdr;
            scenarioDescGridView.DataBind();
            
            conn.Close();

        }
        protected void AddQuestionButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("addQuestionForm.aspx?decisionTreeId=" + decisionTreeId);
        }
        protected void AddFinalStates_Click(object sender, EventArgs e)
        {
            Response.Redirect("finalStates.aspx?decisionTreeId=" + decisionTreeId);
        }
        protected void SelectedOption_Click(object sender, CommandEventArgs e)
        {

            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

            int questionId = Convert.ToInt32(commandArgs[0]);
            String option = commandArgs[1];

            Response.Redirect("addQuestionForm.aspx?decisionTreeId=" + decisionTreeId + "&questionId=" + questionId + "&option=" + option);

        }
        public String IsButtonEnabled(object val)
        {
            int id = Convert.ToInt32(val);

            return (id == 0) ? "true" : "false";
        }
    }
}