using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.IO;
using System.Data;

namespace TheCellGame.admin
{
    public partial class ImageRetrieve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (Request.QueryString["decisionTreeId"] != null && Request.QueryString["questionId"] != null)
            //{
                int decisionTreeId = Convert.ToInt32(Request.QueryString["decisionTreeId"]);
                int questionId = Convert.ToInt32(Request.QueryString["questionId"]);

            decisionTreeId = 1027;
            questionId = 1;

                string strQuery = "select imagePath from Linking where decisionTreeId=" + decisionTreeId + " and questionIdId=" + questionId;
                SqlCommand cmd = new SqlCommand(strQuery);
               
                SqlDataAdapter sda = new SqlDataAdapter();

                
                String connectionString = WebConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);



                DataTable dt = new DataTable();
                
                    conn.Open();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                

                if (dt != null)
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["imagePath"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["ContentType"].ToString();
                    Response.AddHeader("content-disposition", "attachment;filename=Imgfile");
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
            //}
        }
    }
}
 