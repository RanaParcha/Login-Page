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
    public partial class UserRegistrationform : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-0A90E9P5\\SQLEXPRESS;initial catalog=db80_30723;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
                BindGender();
                BindDesignation();
            }
            if(Request.QueryString["pp"] != null && Request.QueryString["pp"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    EditRecord();
                }
            }
        }

        //EDIT RECORD
        public void EditRecord()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from students join tGender on Gender= gid join stDesignation on Designation = did where id = '"+ Request.QueryString["pp"] + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            con.Close();
            //POPULATING RECORD IN THE FIELD
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            rblGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
            ddlDesignation.SelectedValue = dt.Rows[0]["Designation"].ToString();
            btnSubmit.Text = "Update";
        }

        public void BindGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tGender", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            rblGender.DataValueField = "gid";
            rblGender.DataTextField = "tname";
            rblGender.DataSource = dt;
            rblGender.DataBind();
        }

        public void BindDesignation()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from stDesignation", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlDesignation.DataValueField = "did";
            ddlDesignation.DataTextField = "dname";
            ddlDesignation.DataSource = dt;
            ddlDesignation.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Students(Name,Address,Email,Password, Gender , Designation)values('" + txtName.Text + "','" + txtAddress.Text + "','" + rblGender.SelectedValue + "','" + ddlDesignation.SelectedValue + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("showUser.aspx");
            }
            else if (btnSubmit.Text == "Update") 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE students SET Name = @Name, Address = @Address, Gender = @Gender, Designation = @Designation WHERE id = @Id", con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Designation", ddlDesignation.SelectedValue);
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["pp"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("showUser.aspx");
                btnSubmit.Text = "Submit";
            }
            
        }
    }
}