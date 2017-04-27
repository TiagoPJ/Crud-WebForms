using Globo.Business;
using Globo.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Globo
{
    public partial class Default : System.Web.UI.Page
    {
        #region properties
        private Authentication authentication = new Authentication();

        private CharactersBusiness _charactersBusiness;
        private CharactersBusiness CharactersBusiness
        {
            get
            {
                if (_charactersBusiness == null)
                    _charactersBusiness = new CharactersBusiness();

                return _charactersBusiness;
            }
            set
            {
                value = _charactersBusiness;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (!IsPostBack)
                    LoadRegisters();
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }

        protected void Unnamed_Load(object sender, EventArgs e)
        {
            LoadRegisters();
        }

        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void rptListCharacters_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EditCharacter")
            {
                string objectId = e.CommandArgument.ToString();
                Response.Cookies.Add(authentication.AddCharacterId(objectId));
                myModalLabel.Text = "Update Character";
                RegisterEventJs("OpenModal('" + objectId + "');");
            }
            else if (e.CommandName == "ExcluirCharacter")
            {
                CharactersBusiness.ExcludeCharacter(e.CommandArgument.ToString());
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnLogs_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogsPage.aspx");
        }

        #endregion

        #region Methods
        private void LoadRegisters()
        {
            rptListCharacters.DataSource = CharactersBusiness.ListCharacters();
            rptListCharacters.DataBind();
        }

        private void RegisterEventJs(string script)
        {
            string scriptRegister = "$(document).ready(function () { " + script + " }); ";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptHideMessage", scriptRegister, true);
        }

        #endregion
    }
}
