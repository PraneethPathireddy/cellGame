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
    public partial class addDecisionTree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("No"))
            {
                Response.Redirect("../login.aspx");
            }
        }
        protected void AddDecisionTreeButton_Click(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);


            conn.Open();

            String decisionTreeNameStr = decisionTreeName.Text.Trim();

            String query = "select count(*) from DecisionTrees where decisionTreeName='" + decisionTreeNameStr + "'";

            SqlCommand cmd = new SqlCommand(query, conn);

            if ((int)cmd.ExecuteScalar() == 1)
            {
                conn.Close();

                Response.Redirect("addDecisionTree.aspx?failed=" + "duplicate name");
            }


            query = "insert into DecisionTrees (decisionTreeName, isApproved) " + "values( '" + decisionTreeNameStr + "', 1)";


            SqlCommand myCommand = new SqlCommand(query, conn);

            if (myCommand.ExecuteNonQuery() > 0)
            {
                query = "select decisionTreeId from DecisionTrees where decisionTreeName='" + decisionTreeNameStr + "'";
                SqlCommand myCmd = new SqlCommand(query, conn);
                SqlDataReader rdr = myCmd.ExecuteReader();

                if (rdr.Read())
                {
                    int decisionTreeId = Convert.ToInt32(rdr["decisionTreeId"]);

                    conn.Close();

                    Response.Redirect("addQuestion.aspx?decisionTreeId=" + decisionTreeId);
                }
            }
            else
            {
                conn.Close();

                Response.Redirect("addDecisionTree.aspx?failed=" + "yes");
            }

        }
    }
}