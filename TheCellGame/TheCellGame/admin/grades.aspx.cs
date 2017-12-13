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
    public partial class grades : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("No"))
            {
                Response.Redirect("../login.aspx");
            }

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "select count(*) from PlayIds where NOT username='admin' and graded=0";
            SqlCommand mycmd = new SqlCommand(query, conn);
            if ((int)mycmd.ExecuteScalar() == 0)
            {
                gradeLabel.Text = "Nothing to be graded";
            }
            else
            {
                gradeLabel.Text = "";
            }

            query = "select *from PlayIds where NOT username='admin' and graded=0";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            playGridView.DataSource = rdr;
            playGridView.DataBind();
            conn.Close();
        }
        protected void PlayGridView_Command(object sender, CommandEventArgs e)
        {
        
           
            if (e.CommandName == "evaluate")
            {

              
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int playId = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("evaluate.aspx?playId=" + playId);

            }
        }
    }
}