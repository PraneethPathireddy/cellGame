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
    public partial class playScenario : System.Web.UI.Page
    {
        String decisionTreeName = "";
        int questionId = 0;
        int decisionTreeId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            String prevOptCommet = "";
        
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("Yes"))
            {
                Response.Redirect("../login.aspx");
            }

            decisionTreeName = Request.QueryString["decisionTree"];
            questionId = Convert.ToInt32(Request.QueryString["question"]);
          


            if (Request.Cookies["optionComment"] != null)
            {
                prevOptCommet = Request.Cookies["optionComment"].Value;
                HttpCookie cookie = Request.Cookies["optionComment"];
                cookie.Value = "";
                Response.Cookies.Add(cookie);
            }

            prevOptionComment.Text = prevOptCommet; 

            
           // File.AppendAllText(@"C:\Users\pmpra\source\repos\TheCellGame\TheCellGame\user\myLogfile.txt", decisionTreeName + Environment.NewLine);

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            if (!Page.IsPostBack)
            {

                if (questionId == 1)
                {
                    String myQuery = "insert into PlayIds(username, decisionTreeName, graded)values('" + Session["username"] + "', '" + decisionTreeName + "', 0)";
                    SqlCommand cmd2 = new SqlCommand(myQuery, conn);
                    cmd2.ExecuteNonQuery();

                    myQuery = "select MAX(playId) from playIds";

                    SqlCommand cmd3 = new SqlCommand(myQuery, conn);
                    int playId = (int)cmd3.ExecuteScalar();
                    Session["playId"] = Convert.ToInt32(playId);

                }
            }

            String query = "select decisionTreeId from DecisionTrees where decisionTreeName='" +  decisionTreeName +"'";
            SqlCommand myCmd = new SqlCommand(query, conn);

            SqlDataReader myRdr = myCmd.ExecuteReader();
            if (myRdr.Read())
            {
                decisionTreeId = Convert.ToInt32(myRdr["decisionTreeId"]);
             //   File.AppendAllText(@"C:\Users\pmpra\source\repos\TheCellGame\TheCellGame\user\myLogfile.txt", "     " + decisionTreeId  + " " + questionId + Environment.NewLine);
                query = "select question from Linking where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId + "";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                scenarioDescGridView.DataSource = rdr;
                scenarioDescGridView.DataBind();

                query = "select option1 from Linking where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId + "";

                cmd = new SqlCommand(query, conn);
                myRdr = cmd.ExecuteReader();
                option1GridView.DataSource = myRdr;
                option1GridView.DataBind();

                query = "select option2 from Linking where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId + ""; ;

                cmd = new SqlCommand(query, conn);
                myRdr = cmd.ExecuteReader();
                option2GridView.DataSource = myRdr;

                option2GridView.DataBind();
            }
            conn.Close();
        }
        protected void selectedOption_Click(object sender, EventArgs e)
        {
            String scenarioName = Request.QueryString["scenarioName"];
            String option = (sender as Button).Text;
            String id = (sender as Button).ID;
            String comment = commentBox.Value.Trim();

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query1 = "select count(*) from Linking where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId + " and option1='" + option + "' and option1NextQuestionId>0";
            String query2 = "select count(*) from Linking where  decisionTreeId=" + decisionTreeId + " and questionId=" + questionId + " and option2='" + option + "' and option2NextQuestionId>0";

            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlCommand cmd2 = new SqlCommand(query2, conn);

            InsertIntoPlays(conn, option, comment);

            if (((int)cmd1.ExecuteScalar() == 1))
            {
                //File.AppendAllText(@"C:\Users\pmpra\source\repos\TheCellGame\TheCellGame\user\myLogfile.txt", "          " + decisionTreeId + "       " + questionId + Environment.NewLine);

                String query4 = "select  option1NextQuestionId, option1Comment from Linking where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId;
                SqlCommand cmd4 = new SqlCommand(query4, conn);

                SqlDataReader myRdr = cmd4.ExecuteReader();
                int nextQuestionId = 0;
                String opt1Comment = "";

                if (myRdr.Read())
                {
                    nextQuestionId = Convert.ToInt32(myRdr["option1NextQuestionId"]);
                    opt1Comment = myRdr["option1Comment"].ToString();
                }


                HttpCookie commCookie = Request.Cookies["optionComment"];
                if (commCookie == null)
                {
                    commCookie = new HttpCookie("optionComment");
                }
                commCookie.Value = opt1Comment;
                Response.Cookies.Add(commCookie);
               
                Response.Redirect("playScenario.aspx?decisionTree=" + decisionTreeName + "&question=" + nextQuestionId);

            }
            if (((int)cmd2.ExecuteScalar() == 1))
            {
                //  File.AppendAllText(@"C:\Users\pmpra\source\repos\TheCellGame\TheCellGame\user\myLogfile.txt", "          " + decisionTreeId + "       " + questionId + Environment.NewLine);
                String query4 = "select  option2NextQuestionId, option2Comment  from Linking where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId;
                SqlCommand cmd4 = new SqlCommand(query4, conn);

                SqlDataReader myRdr = cmd4.ExecuteReader();
                int nextQuestionId = 0;
                String opt2Comment = "";

                if (myRdr.Read())
                {
                    nextQuestionId = Convert.ToInt32(myRdr["option2NextQuestionId"]);
                    opt2Comment = myRdr["option2Comment"].ToString();

                    HttpCookie commCookie = Request.Cookies["optionComment"];
                    if (commCookie == null)
                    {
                        commCookie = new HttpCookie("optionComment");
                    }
                    commCookie.Value = opt2Comment;
                    Response.Cookies.Add(commCookie);
                }

                Response.Redirect("playScenario.aspx?decisionTree=" + decisionTreeName + "&question=" + nextQuestionId);
            }
            if (id == "option1Button")
            {
                String query4 = "select option1Comment from Linking where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId;
                SqlCommand cmd4 = new SqlCommand(query4, conn);

                SqlDataReader myRdr = cmd4.ExecuteReader();
              
                String opt1Comment = "";

                if (myRdr.Read())
                {
  
                    opt1Comment = myRdr["option1Comment"].ToString();
                }


                HttpCookie commCookie = Request.Cookies["optionComment"];
                if (commCookie == null)
                {
                    commCookie = new HttpCookie("optionComment");
                }
                commCookie.Value = opt1Comment;
                Response.Cookies.Add(commCookie);

                Response.Redirect("playScenarioResult.aspx?decisionTreeId=" + decisionTreeId + "&questionId=" + questionId + "&option=option1");
            }
            else
            {
                String query4 = "select option2Comment from Linking where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId;
                SqlCommand cmd4 = new SqlCommand(query4, conn);

                SqlDataReader myRdr = cmd4.ExecuteReader();

                String opt2Comment = "";

                if (myRdr.Read())
                {

                    opt2Comment = myRdr["option2Comment"].ToString();
                }


                HttpCookie commCookie = Request.Cookies["optionComment"];
                if (commCookie == null)
                {
                    commCookie = new HttpCookie("optionComment");
                }
                commCookie.Value = opt2Comment;
                Response.Cookies.Add(commCookie);

                Response.Redirect("playScenarioResult.aspx?decisionTreeId=" + decisionTreeId + "&questionId=" + questionId + "&option=option2");
            }

            conn.Close();
        }
        private void InsertIntoPlays(SqlConnection conn, String optionSelected, String comment)
        {
            String query3 = "select question from Linking where decisionTreeId=" + decisionTreeId + " and questionId=" + questionId;


            SqlCommand cmd3 = new SqlCommand(query3, conn);
            SqlDataReader rdr = cmd3.ExecuteReader();

            if (rdr.Read())
            {
                String question = rdr["question"].ToString();

                query3 = "insert into Plays (playId, decisionTreeName, question, optionSelected, comment) values (" + Session["playId"] +", '" + decisionTreeName + "', '" + question + "', '" + optionSelected + "', '" + comment + "')";
                SqlCommand cmd = new SqlCommand(query3, conn);
                cmd.ExecuteNonQuery();

            }
        }
    }
}