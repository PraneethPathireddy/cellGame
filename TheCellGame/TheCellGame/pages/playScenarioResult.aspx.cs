using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheCellGame.pages
{
    public partial class playScenarioResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String result = Request.QueryString["Result"];

            resultLabel.Text = result + " option selected";
        }
    }
}