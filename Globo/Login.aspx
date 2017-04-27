<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Globo.Login" %>

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
    <div class="Login">
        <div class="control-group">
            <label class="control-label" for="inputEmail">E-mail</label>
            <div class="controls">
                <asp:TextBox ID="txtEmail" type="email" required placeholder="Input your e-mail..." runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="inputPassword">Senha</label>
            <div class="controls">
                <asp:TextBox ID="txtPassword" type="password" required placeholder="Input your password..." runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <div class="controls">
                <asp:Button ID="btnAcess" CssClass="btn" runat="server" Text="Login" OnClick="btnAcess_Click" />
                <asp:Button ID="btnRegister" CssClass="btn" runat="server" Text="Register User" formnovalidate OnClick="btnRegister_Click" />
            </div>
        </div>
    </div>
</asp:Content>
