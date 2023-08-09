<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="UserRegistrationform.aspx.cs" Inherits="ProjectDone.UserRegistrationform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox> </td>
        </tr>

         <tr>
            <td>Address: </td>
            <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox> </td>
        </tr>

        <tr>
            <td>Email</td>
            <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox> </td>
        </tr>

        <tr>
            <td>Password</td>
            <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox> </td>
        </tr>

         <tr>
            <td>Gender</td>
            <td><asp:RadioButtonList ID="rblGender" runat="server" RepeatColumns="3"></asp:RadioButtonList> </td>
        </tr>


         <tr>
            <td>Designation: </td>
            <td><asp:DropDownList ID="ddlDesignation" runat="server">

                </asp:DropDownList> </td>
        </tr>

          <tr>
            <td>Country</td>
            <td><asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList> </td>
        </tr>

         <tr>
            <td>State</td>
            <td><asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList> </td>
        </tr>

         <tr>
            <td></td>
            <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" BackColor="red" ForeColor="White" Width="70px" Height="25px"/> </td>
        </tr>

    </table>
</asp:Content>
