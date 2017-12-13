using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;


namespace TheCellGame.user
{
    public partial class addScenario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("Yes"))
            {
                Response.Redirect("../login.aspx");
            }
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


            String query = "insert into Scenarios (scenarioName, IsRoot, parentId, scenarioDescription, option1, option2, rightOption, createdBy, approvalStatus) " +
                            "values( '" + scenarioNameStr + "', 1, 0, '" + scenarioDescriptionStr + "', '" + option1Str + "', '" + option2Str + "', '" + optionSelected + "', '" + Session["username"] + "', 0)";


            SqlCommand myCommand = new SqlCommand(query, conn);
            myCommand.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("addScenario.aspx");

        }
    }
}