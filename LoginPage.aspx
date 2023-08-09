<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ProjectDone.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" BackColor="red" ForeColor="White" Width="70px" Height="25px"/> </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server"></asp:Label> </td>
        </tr>

    </table>
</asp:Content>
