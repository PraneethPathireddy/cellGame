using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace TheCellGame.pages
{
    public partial class playScenario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String scenarioName = Request.QueryString["scenarioName"];
            
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();

                String query = "select scenarioDescription from Scenarios where scenarioName='" + scenarioName + "'" ;

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                scenarioDescGridView.DataSource = rdr;
                scenarioDescGridView.DataBind();

                query = "select option1 from Scenarios where scenarioName='" + scenarioName + "'";

                cmd = new SqlCommand(query, conn);
                rdr = cmd.ExecuteReader();
                option1GridView.DataSource = rdr;
                option1GridView.DataBind();

            query = "select option2 from Scenarios where scenarioName='" + scenarioName + "'";
             
               cmd = new SqlCommand(query, conn);
               rdr = cmd.ExecuteReader();
               option2GridView.DataSource = rdr;

               option2GridView.DataBind();
               conn.Close();
        
        }
        protected void selectedOption_Click(object sender, EventArgs e)
        {
            String scenarioName = Request.QueryString["scenarioName"];
            String option = (sender as Button).Text;

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query1 = "select count(*) from Scenarios where scenarioName='" + scenarioName + "' and option1='" + option + "' and rightOption=1" ;
            String query2 = "select count(*) from Scenarios where scenarioName='" + scenarioName + "' and option2='" + option + "' and rightOption=2";

            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlCommand cmd2 = new SqlCommand(query2, conn);

            if (((int)cmd1.ExecuteScalar() == 1) || ((int)cmd2.ExecuteScalar() == 1) )
            {
                Response.Redirect("playScenarioResult.aspx?Result=" + "correct");
            }
            else
            {
                Response.Redirect("playScenarioResult.aspx?Result=" + "incorrect");
            }

            conn.Close();

        }
    }
}