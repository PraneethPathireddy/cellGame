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
    public partial class LinkQuestions : System.Web.UI.Page
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

            String query = "select *from Linking where decisionTreeId=" + decisionTreeId;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            questionGridView.DataSource = rdr;
            questionGridView.DataBind();

            option1GridView.DataSource = rdr;
            option1GridView.DataBind();

            option2GridView.DataSource = rdr;
            option2GridView.DataBind();




            conn.Close();
        }
    }
}