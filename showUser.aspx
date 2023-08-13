<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="showUser.aspx.cs" Inherits="ProjectDone.showUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>

        <tr>
            <td>
                <a href="UserRegistrationform.aspx">Add New User</a>
            </td>
        </tr>

        <tr>
            <td>
               <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" BackColor="red" ForeColor="White" Width="70px" Height="25px" />
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" OnRowCommand="gvUser_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="user Id">
                            <ItemTemplate>
                                <%#Eval("id") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <%#Eval("Address") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <%#Eval("Email") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Password">
                            <ItemTemplate>
                                <%#Eval("Password") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <%#Eval("tname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Designation">
                            <ItemTemplate>
                                <%#Eval("dname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Country">
                            <ItemTemplate>
                                <%#Eval("cname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="State">
                            <ItemTemplate>
                                <%#Eval("sname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="img1" runat="server" Width="50px" Height="40px" ImageUrl='<%#Eval("image","~/Pics/{0}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Delete_btn" runat="server" ImageUrl="~/delete.png" CommandName="D" CommandArgument='<%#Eval("id") %>' style="height:20px; width:20px" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Edit_btn" runat="server" ImageUrl="~/Edit.png" CommandName="E" CommandArgument='<%#Eval("id") %>' style="height:20px; width:20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
