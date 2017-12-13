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
    public partial class scenarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddScenaroButton_Click(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String scenarioNameStr = scenarioName.Text;
            String scenarioDescriptionStr = scenarioDescription.Value;
            String option1Str = option1.Value;
            String option2Str = option2.Value;

            int optionSelected = Convert.ToInt32(optionsRadioList.SelectedValue);


            String query = "insert into Scenarios (scenarioName, isRoot, parentId, scenarioDescription, option1, option2, rightOption) " + 
                            "values( '" + scenarioNameStr + "', 1, 0, '" + scenarioDescriptionStr + "', '" + option1Str + "', '" + option2Str + "', '" + optionSelected + "')";

            SqlCommand myCommand = new SqlCommand(query, conn);
            myCommand.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("viewScenarios.aspx");

        }

    }
}