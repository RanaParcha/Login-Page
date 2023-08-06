<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="ProjectDone.UserForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox> </td>
        </tr>

        <tr>
            <td>City</td>
            <td><asp:TextBox ID="txtcity" runat="server"></asp:TextBox> </td>
        </tr>

        <tr>
            <td>age</td>
            <td><asp:TextBox ID="txtage" runat="server"></asp:TextBox> </td>
        </tr>

        <tr>
            <td>Salary</td>
            <td><asp:TextBox ID="txtSalary" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btninsert" runat="server" Text="Submit" OnClick="btninsert_Click" /> </td>
        </tr>

    </table>
</asp:Content>
