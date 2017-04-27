<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogsPage.aspx.cs" Inherits="Globo.LogsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>#</th>
                    <th>User</th>
                    <th>Data</th>
                    <th>Name of the User or Character</th>
                    <th>Type</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptListLogs" runat="server" OnItemCommand="rptListLogs_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex + 1 %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Data") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "NameObject") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Type") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Action") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <div>
        <div class="control-group">
            <div class="controls">
                <asp:Button ID="btnBack" class="btn" OnClick="btnBack_Click" Text="Back To Start Page" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
