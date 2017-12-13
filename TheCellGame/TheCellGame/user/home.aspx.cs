using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheCellGame.user
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"].Equals("No") || Session["isAdmin"].Equals("Yes"))
            {
                Response.Redirect("../login.aspx");
            }

        }
    }
}