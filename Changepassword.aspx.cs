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
    public partial class Changepassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-0A90E9P5\\SQLEXPRESS;initial catalog=db80_30723;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtnewpassword.Text == txtcurrentpassword.Text)
            { 
            con.Open();
            SqlCommand cmd = new SqlCommand("update students set password='"+txtnewpassword.Text+"'where id='"+ Session["id"] + "' where id='"+ Session["id"] + "' and password='"+txtcurrentpassword.Text+"'",con);
            int i =  cmd.ExecuteNonQuery();
            con.Close();
            if (i == 0)
                {
                    lblmsg.Text = "Your current password is not correct !!!";
                }
            lblmsg.Text = "Your Password Has Been Changed Succesfully !!";
            }
            else
            {
                lblmsg.Text = "Password do not change !!";
            }

        }
    }
}