using Globo.Business;
using Globo.Objetos;
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
    public partial class RegisterCharacters : System.Web.UI.Page
    {
        #region Properties
        private Authentication authentication = new Authentication();

        private bool? IsInsert
        {
            get
            {
                return Request.QueryString["IsInsert"] != null ? bool.Parse(Request.QueryString["IsInsert"]) : (bool?)null;
            }
        }

        private string CharacterId
        {
            get
            {
                return Request.QueryString["Id"] != null ? Request.QueryString["Id"] : string.Empty;
            }
        }

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

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated && IsInsert.HasValue)
            {
                if (!IsPostBack)
                {
                    if (!IsInsert.Value)
                        LoadCharacter();
                }
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string Type = txtType.Text;
            string Feature = txtFeature.Text;

            if (!IsInsert.Value)
            {
                CharactersBusiness.UpdateCharacter(CharacterId, Name, Type, Feature);
                Response.Cookies.Remove("Characters");
            }
            else
                CharactersBusiness.SaveCharacter(Name, Type, Feature);

            string script = " $(document).ready(function () {  parent.$('#myModal').hide(); parent.RefreshGrid() });";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptHideMessage", script, true);
        }

        #endregion

        #region Methods
        private void LoadCharacter()
        {
            Characters ch = CharactersBusiness.GetCharacter(CharacterId);
            txtName.Text = ch.Name;
            txtType.Text = ch.Type;
            txtFeature.Text = ch.Feature;
        }

        #endregion
    }
}