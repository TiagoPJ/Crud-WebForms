<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Globo.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-error" id="divError" runat="server" visible="false" clientidmode="Static">
        <button class="close" data-dismiss="alert">
            ×</button>
        <asp:Label ID="MsgAlert" runat="server" />
    </div>
    <div class="alert alert-info" id="divSucess" runat="server" visible="false" clientidmode="Static">
        <button class="close" data-dismiss="alert">
            ×</button>
        <asp:Label ID="MsgSucess" runat="server" />
    </div>
    <%--   <div class="jumbotron img-rounded">
        <label class="control-label" style="color:white;"><h2></h2></label>
    </div>--%>
    <div id="formLogin" class="Login">
        <div class="control-group">
            <label class="control-label" for="inputName">Full Name</label>
            <div class="controls">
                <asp:TextBox ID="txtName" required placeholder="Input your name..." runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="inputEmail">E-mail</label>
            <div class="controls">
                <asp:TextBox ID="txtEmail" type="email" required placeholder="Input your e-mail..." runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="inputPassword">Password</label>
            <div class="controls">
                <asp:TextBox ID="txtPassaword" type="password" required placeholder="Input your password..." name="password" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPassaword" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{5,8}$" runat="server" ErrorMessage="Minimum 5 and Maximum 8 characters required."></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="inputPasswordAgain">Confirm Password</label>
            <div class="controls">
                <asp:TextBox ID="txtPasswordAgain" type="password" required placeholder="Input your password again..." runat="server"></asp:TextBox>
                <asp:CompareValidator runat="server" Display="Dynamic" ControlToValidate="txtPasswordAgain" ControlToCompare="txtPassaword" ErrorMessage="please input equals passwords." CssClass="ValidationError"></asp:CompareValidator>
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPasswordAgain" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{5,8}$" runat="server" ErrorMessage="Minimum 5 and Maximum 8 characters required."></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="control-group">
            <div class="controls">
                <asp:Button ID="btnSave" class="btn" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnBack" class="btn" runat="server" formnovalidate Text="Back To Login" OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
</asp:Content>
