using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ProjectDone
{
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-0A90E9P5\\SQLEXPRESS;initial catalog=db80_30723;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from students where email='"+txtemail.Text+"' and password='"+txtpassword.Text+"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if(dt.Rows.Count > 0)
            {
                Session["id"] = dt.Rows[0]["id"].ToString();
                Response.Redirect("Home.aspx");
            }
            else if(dt.Rows.Count > 0)
            {

            }
        }
    }
}