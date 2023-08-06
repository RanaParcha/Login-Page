using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ProjectDone
{
    public partial class Studentsform : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-0A90E9P5\\SQLEXPRESS;initial catalog=db80_30723;integrated Security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
            RPGender();
            RPDesignation();
            }
            RP();
        }

        public void RP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Students join stGender on Gender=gid join stDesignation on Designation=did", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvStudents.DataSource = dt;
            gvStudents.DataBind();
        }

        public void RPGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from stGender", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            rblgender.DataValueField = "gid";
            rblgender.DataTextField = "gname";
            rblgender.DataSource = dt;
            rblgender.DataBind();
        }


        public void RPDesignation()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from stDesignation", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddldesignation.DataValueField = "did";
            ddldesignation.DataTextField = "dname";
            ddldesignation.DataSource = dt;
            ddldesignation.DataBind();
            ddldesignation.Items.Insert(0, new ListItem("--Select--","0"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(btnSubmit.Text == "Submit")
            { 
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Students(Name,Address,Gender,Designation)values('"+txtname.Text+"','"+txtaddress.Text+"','"+rblgender.SelectedValue+"','"+ddldesignation.SelectedValue+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            RP();
            }
            else if(btnSubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Students set name='"+txtname.Text+"',Address='"+txtaddress.Text+"',Gender='"+rblgender.SelectedValue+"',Designation='"+ddldesignation.SelectedValue+"'where id='"+ ViewState["RR"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                RP(); //showing the list of users
                btnSubmit.Text = "Submit";
                ClearFrom();
            }
        }


        //TO CLEAR FORM AFTER PERFORM THE OPERATIONS
        public void ClearFrom() 
        {
            txtname.Text = string.Empty;
            ddldesignation.SelectedIndex = 0; //To clear the selection of dropdown
            rblgender.ClearSelection(); // to unselect the radio button
            txtaddress.Text = string.Empty;
        }

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from Students where id='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                RP();
            }
            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Students join stGender on Gender=gid join stDesignation on Designation=did where id='" + e.CommandArgument + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["Name"].ToString();
                txtaddress.Text = dt.Rows[0]["Address"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                ddldesignation.SelectedValue = dt.Rows[0]["Designation"].ToString();
                btnSubmit.Text = "Update";
                ViewState["RR"] = e.CommandArgument;
            }
        }
    }
}