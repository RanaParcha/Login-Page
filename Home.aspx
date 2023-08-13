<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjectDone.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome Home</h1>
    <table>
        <tr>
            <td>
                <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                                <%#Eval("Country") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="State">
                            <ItemTemplate>
                                <%#Eval("State") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <%#Eval("Image") %>
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
