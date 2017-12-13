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
    public partial class editScenario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("No"))
                {
                    Response.Redirect("../login.aspx");
                }
                String result = Request.QueryString["scenario"];
                if (result != null)
                {
                    int scenarioId = Convert.ToInt32(result);

                    String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

                    SqlConnection conn = new SqlConnection(connectionString);

                    conn.Open();

                    String query = "select *from Scenarios where scenarioId=" + scenarioId;

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        scenarioName.Text = (String)rdr["scenarioName"];
                        scenarioDescription.Value = (String)rdr["scenarioDescription"];
                        option1.Value = (String)rdr["option1"];
                        option2.Value = (String)rdr["option2"];

                        optionsRadioList.SelectedIndex = (int)rdr["rightOption"] - 1;

                    }


                    conn.Close();
                }
            }
        }
        protected void EditScenaroButton_Click(object sender, EventArgs e)
        {
            String scenarioNameStr = scenarioName.Text.Trim();
            String scenarioDescriptionStr = scenarioDescription.Value;
            String option1Str = option1.Value;
            String option2Str = option2.Value;
            int optionSelected = Convert.ToInt32(optionsRadioList.SelectedValue);

            String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            String query = "update Scenarios SET scenarioName='" + scenarioNameStr + "', scenarioDescription='" + scenarioDescriptionStr + "', option1='" + option1Str + "', option2='" + option2Str + "', rightOption=" + optionSelected + " where scenarioName='" + scenarioNameStr + "'";
            
            SqlCommand myCommand = new SqlCommand(query, conn);
            myCommand.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("viewScenarios.aspx?");

        }
    }
}