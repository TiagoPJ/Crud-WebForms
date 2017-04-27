<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Globo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-info" id="divError" runat="server" visible="false" clientidmode="Static">
        <button class="close" data-dismiss="alert">
            ×</button>
        <asp:Label ID="MsgAlert" runat="server" />
    </div>
    <div class="alert alert-sucess" id="divSucess" runat="server" visible="false" clientidmode="Static">
        <button class="close" data-dismiss="alert">
            ×</button>
        <asp:Label ID="MsgSucess" runat="server" />
    </div>
    <div>
        <div class="control-group">
            <div class="controls">
                <asp:Button ID="btnNewCharacter" class="btn" runat="server" Text="New Character" OnClientClick="OpenModal(); return false;" data-toggle="modal" />
                <a href="#myModal" style="display: none;" role="button" id="lnkModal" class="btn" data-toggle="modal">Cadastro</a>
                <asp:Button ID="btnLogs" class="btn" OnClick="btnLogs_Click" Text="View Logs" runat="server" />
                <asp:Button ID="btnLogoff" class="btn" OnClick="btnLogoff_Click" Text="Logoof" runat="server" />
            </div>
        </div>
    </div>
    <div>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Character</th>
                    <th>Type</th>
                    <th>Feature</th>
                </tr>
            </thead>
            <tbody>
                <asp:UpdatePanel ID="updPanel" OnLoad="Unnamed_Load" runat="server">
                    <ContentTemplate>
                        <asp:Repeater ID="rptListCharacters" runat="server" OnItemCommand="rptListCharacters_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.ItemIndex + 1 %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Type") %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Feature") %></td>
                                    <td>
                                        <asp:LinkButton ID="lnkEditCharacters" CommandName="EditCharacter" ToolTip="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' CssClass="icon-pencil" runat="server" />
                                        <asp:LinkButton ID="lnkExcluirCharacter" CommandName="ExcluirCharacter" ToolTip="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' CssClass="icon-remove" runat="server" /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </tbody>
        </table>
    </div>
    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3>
                <asp:Label ID="myModalLabel" ClientIDMode="Static" runat="server" Text="New Character"></asp:Label></h3>
        </div>
        <div class="modal-body">
            <iframe id="iframe" frameborder="0" width="100%" height="280px"></iframe>
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>
    <script type="text/javascript">
        function OpenModal(id) {
            if (id) {
                $("#myModalLabel").text("Update Character");
                $('#iframe').attr('src', 'RegisterCharacters.aspx?IsInsert=false&id=' + id);
            }
            else {
                $("#myModalLabel").text("New Character");
                $('#iframe').attr('src', 'RegisterCharacters.aspx?IsInsert=true');
            }

            $('#lnkModal').click();
        }

        function RefreshGrid() {
            __doPostBack('updPanel');
        }
    </script>
</asp:Content>
