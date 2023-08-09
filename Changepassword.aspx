<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Changepassword.aspx.cs" Inherits="ProjectDone.Changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Current Password</td>
            <td><asp:TextBox ID="txtcurrentpassword" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>New Password</td>
            <td>
                <asp:TextBox ID="txtnewpassword" runat="server"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td>Confirm Password</td>
            <td>
                <asp:TextBox ID="txtConfirmpassword" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="btnLogin" runat="server" Text="Change Password" BackColor="red" ForeColor="White" Width="122px" Height="25px" OnClick="btnLogin_Click" /> </td>
        </tr>

         <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server"></asp:Label> </td>
        </tr>

    </table>
</asp:Content>
