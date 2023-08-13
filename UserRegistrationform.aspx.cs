using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

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
                ShowCountry();
                ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlState.Enabled = false;
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
            SqlCommand cmd = new SqlCommand("Users_Edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Request.QueryString["pp"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            //con.Close();
            //POPULATING RECORD IN THE FIELD
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtemail.Text = dt.Rows[0]["Email"].ToString();
            txtpassword.Text = dt.Rows[0]["Password"].ToString();
            rblGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
            ddlDesignation.SelectedValue = dt.Rows[0]["Designation"].ToString();
            ddlCountry.SelectedValue = dt.Rows[0]["Country"].ToString();
            ShowState();
            ddlState.SelectedValue = dt.Rows[0]["State"].ToString();
            ViewState["img"] = dt.Rows[0]["image"].ToString();
            btnSubmit.Text = "Update";
        }

        public void BindGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Gender_Get", con);
            cmd.CommandType= CommandType.StoredProcedure;
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
            SqlCommand cmd = new SqlCommand("Designation_Get", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlDesignation.DataValueField = "did";
            ddlDesignation.DataTextField = "dname";
            ddlDesignation.DataSource = dt;
            ddlDesignation.DataBind();
        }

        public void ShowCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcountry1", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlCountry.DataValueField = "cid";
            ddlCountry.DataTextField = "cname";
            ddlCountry.DataSource = dt;
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void ShowState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblState where cid='"+ddlCountry.SelectedValue+"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlState.Enabled = true;
            ddlState.DataValueField = "sid";
            ddlState.DataTextField = "sname";
            ddlState.DataSource = dt;
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Submit")
            {
                string RP = Path.GetFileName(fimage.PostedFile.FileName);
                fimage.SaveAs(Server.MapPath("Pics" + "\\" + RP));
                con.Open();
                SqlCommand cmd = new SqlCommand("User_Ins", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Designation", ddlDesignation.SelectedValue);
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@State", ddlState.SelectedValue);
                cmd.Parameters.AddWithValue("@image",RP);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("showUser.aspx");
            }
            else if (btnSubmit.Text == "Update") 
            {
                string RP = Path.GetFileName(fimage.PostedFile.FileName);
                fimage.SaveAs(Server.MapPath("Pics" + "\\" + RP));
                File.Delete(Server.MapPath("Pics" + "\\" + ViewState["img"]));
                con.Open();
                SqlCommand cmd = new SqlCommand("User_Updated", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Request.QueryString["pp"]);  
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Designation", ddlDesignation.SelectedValue);
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@State", ddlState.SelectedValue);
                cmd.Parameters.AddWithValue("@image", RP);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("showUser.aspx");
                btnSubmit.Text = "Submit";
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowState();
        }
    }
}