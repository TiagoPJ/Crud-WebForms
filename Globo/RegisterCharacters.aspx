<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCharacters.aspx.cs" Inherits="Globo.RegisterCharacters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%=Page.ResolveUrl("~/css/bootstrap.min.css")%>" rel="stylesheet" />
    <link href="<%=Page.ResolveUrl("~/css/datepicker.css")%>" rel="stylesheet" />
    <script src="<%=Page.ResolveUrl("~/scripts/jquery-1.9.1.js")%>"></script>
    <script src="<%=Page.ResolveUrl("~/scripts/bootstrap.min.js")%>"></script>
    <script src="<%=Page.ResolveUrl("~/scripts/bootstrap-datepicker.js")%>"></script>
    <script src="<%=Page.ResolveUrl("~/scripts/jquery-mask.js")%>"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            <label for="txtName">Name</label>
            <asp:TextBox ID="txtName" required placeholder="Character Name..." runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtType">Type</label>
            <asp:TextBox ID="txtType" required placeholder="Cartoon, Serie, Movie..." runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtFeature">Feature</label>
            <asp:TextBox ID="txtFeature" TextMode="MultiLine" Width="100%" Height="50px" required placeholder="Is funny, Is Crazy..." runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" class="btn" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
