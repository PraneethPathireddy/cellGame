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
    public partial class evaluate : System.Web.UI.Page
    {
        int playId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("No"))
            {
                Response.Redirect("../login.aspx");
            }

            playId = Convert.ToInt32(Request.QueryString["playId"]);

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select *from Plays where playId=" + playId;
           
            SqlCommand myCmd = new SqlCommand(query, conn);

            SqlDataReader myRdr = myCmd.ExecuteReader();


            playGridView.DataSource = myRdr;
            playGridView.DataBind();

            conn.Close();

        }
        protected void AddMarksButton_Click(object sender, EventArgs e)
        {
            int lmarks = Convert.ToInt32(marks.Text.Trim());
            String commentStr =  comment.Value;
            String username = "";
            String decisionTreeName = "";

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select * from PlayIds where playId=" + playId;

            SqlCommand myCmd = new SqlCommand(query, conn);

            SqlDataReader myRdr = myCmd.ExecuteReader();

            if (myRdr.Read())
            {
                username = myRdr["username"].ToString();
                decisionTreeName = myRdr["decisionTreeName"].ToString();
            }


            query = "insert into Marks (playId, username, decisionTreeName, marks, comment) values(" + playId + ", '" + username + "', '" + decisionTreeName + "', " + lmarks + ", '" + commentStr + "')";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();

            query = "update PlayIds set graded=1 where playId=" + playId;

            SqlCommand cmd2 = new SqlCommand(query, conn);

            cmd2.ExecuteNonQuery();

            Response.Redirect("grades.aspx");
        }
    }
}