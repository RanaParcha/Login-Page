﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace ProjectDone
{
    public partial class showUser : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-0A90E9P5\\SQLEXPRESS;initial catalog=db80_30723;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindgrid();
            }
        }

        public void Bindgrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Students join tGender on Gender= gid join stDesignation on Designation = did", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvUser.DataSource = dt;
            gvUser.DataBind();
        }

        //ON ROW COMMANDS
        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //DELETING RECORD
            if(e.CommandName == "D")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from students where id= '" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Bindgrid();
            }
            //EDITING RECORD
            else if (e.CommandName == "E")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from students join tGender on Gender= gid join stDesignation on Designation = did where id = '" + e.CommandArgument + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                Response.Redirect("UserRegistrationform.aspx?pp=" + e.CommandArgument);
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from students join tGender on Gender= gid join stDesignation on Designation = did where name like '"+txtSearch.Text+ "%'or dname like '"+txtSearch.Text+ "%'or tname like '"+txtSearch.Text+"%'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if(dt.Rows.Count > 0)
            {
                gvUser.DataSource = null;
                gvUser.DataBind();
                lblmsg.Text = "Results!!";
            }
            else
            {
                lblmsg.Text = "No Record Found !!";
            }
            
        }
    }
}