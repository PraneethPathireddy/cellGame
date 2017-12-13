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
    public partial class addQuestionForm : System.Web.UI.Page
    {
        int decisionTreeId = 0;
        int prevQuestionId = 0;
        String option = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("No"))
            {
                Response.Redirect("../login.aspx");
            }
            decisionTreeId = Convert.ToInt32(Request.QueryString["decisionTreeId"]);
            prevQuestionId = Convert.ToInt32(Request.QueryString["questionId"]);
            option = Request.QueryString["option"];
        }
        protected void AddQuestion_Click(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);
            int questionId = 0;

            conn.Open();

            String questionStr = question.Value.Trim();
            String option1Str = option1.Value.Trim();
            String option2Str = option2.Value.Trim();
            String opt1Comm = option1Comment.Value.Trim();
            String opt2Comm = option2Comment.Value.Trim();

            int length = 0; 
            byte[] pic;


            if (FileUpload1.HasFile)
            {
               
                length = FileUpload1.PostedFile.ContentLength;
            }
            pic = new byte[length];
            if (length > 0)
            {
               
                FileUpload1.PostedFile.InputStream.Read(pic, 0, length);
            }

            String query = "select count(*) from Linking where decisionTreeId=" + decisionTreeId;
            SqlCommand cmd = new SqlCommand(query, conn);

            questionId = (int)cmd.ExecuteScalar() + 1;

            if (length > 0)
            {
                query = "insert into Linking (decisionTreeId, questionId, question, option1, option2, option1NextQuestionId, option2NextQuestionId, option1Comment, option2Comment, imagePath) " +
                                "values(" + decisionTreeId + ", " + questionId + ", '" + questionStr + "', '" + option1Str + "', '" + option2Str + "', 0, 0, '" + opt1Comm + "', '" + opt2Comm + "', @image)";

            }
            else
            {
                query = "insert into Linking (decisionTreeId, questionId, question, option1, option2, option1NextQuestionId, option2NextQuestionId, option1Comment, option2Comment) " +
                                "values(" + decisionTreeId + ", " + questionId + ", '" + questionStr + "', '" + option1Str + "', '" + option2Str + "', 0, 0, '" + opt1Comm + "', '" + opt2Comm + "')";

            }


            SqlCommand myCommand = new SqlCommand(query, conn);
            if (length > 0)
            {
                myCommand.Parameters.AddWithValue("@image", pic);
            }
            myCommand.ExecuteNonQuery();
            if (prevQuestionId != 0)
            {
                if (option == "option1")
                {

                    query = "update Linking set option1NextQuestionId=" + questionId + " where questionId=" + prevQuestionId + " and decisionTreeId =" + decisionTreeId;
                }
                else
                {
                    query = "update Linking set option2NextQuestionId=" + questionId + " where questionId=" + prevQuestionId + " and decisionTreeId =" + decisionTreeId;
                }

                SqlCommand myCommand2 = new SqlCommand(query, conn);
                myCommand2.ExecuteNonQuery();
            }
            conn.Close();

            Response.Redirect("addQuestion.aspx?decisionTreeId=" + decisionTreeId);

        }
    }
}