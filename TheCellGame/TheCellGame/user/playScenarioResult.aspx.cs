using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.IO;

namespace TheCellGame.user
{
    public partial class playScenarioResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int decisionTreeId;
            int questionId;
            String option;

            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("Yes"))
            {
                Response.Redirect("../login.aspx");
            }

            resultLabel.Text = "You have reached following final stage of decision Game";

            decisionTreeId = Convert.ToInt32(Request.QueryString["decisionTreeId"]);
            questionId = Convert.ToInt32(Request.QueryString["questionId"]);
            option = Request.QueryString["option"];
            /*
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "";

          
           query = "select *from decisionTreeFinalState where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId;
            
            SqlCommand myCmd = new SqlCommand(query, conn);

            SqlDataReader myRdr = myCmd.ExecuteReader();
            if (myRdr.Read())
            {
                if (option == "option1")
                {
                    
                     FinalState.Text = myRdr["option1FinalState"].ToString();
                   
                }
                else
                {
                    
                     FinalState.Text = myRdr["option2FinalState"].ToString();
                    
                }

            }
            */
            if (Request.Cookies["optionComment"] != null)
            {
                FinalState.Text = Request.Cookies["optionComment"].Value;
                HttpCookie cookie = Request.Cookies["optionComment"];
                cookie.Value = "";
                Response.Cookies.Add(cookie);
            }
        }

        protected void PlayMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("play.aspx");

        }
    }
}