using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProjectDone
{
    public partial class UserForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=;initial catalog=;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Students(name,city,age,salary)values()", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}