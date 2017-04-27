using Globo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Globo
{
    public partial class Register : System.Web.UI.Page
    {
        private UsersBusiness _userBusiness;
        private UsersBusiness userBusiness
        {
            get
            {
                if (_userBusiness == null)
                    _userBusiness = new UsersBusiness();

                return _userBusiness;
            }
            set
            {
                value = _userBusiness;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool existUser = userBusiness.VerifyExistUserByEmail(txtEmail.Text);
            if (!existUser)
            {
                userBusiness.SaveUser(txtEmail.Text, txtPassaword.Text, txtName.Text);
                ShowMessage("User saved successfully.");
            }
            else
                ShowMessage("E-mail already registered.", true);
        }

        private void ShowMessage(string msg, bool isError = false)
        {
            string idDiv = string.Empty;
            if (isError)
            {
                idDiv = "#divError";
                MsgAlert.Text = msg;
                divError.Visible = true;
            }
            else
            {
                idDiv = "#divSucess";
                MsgSucess.Text = msg;
                divSucess.Visible = true;
            }

            string script = " $(document).ready(function () { setTimeout(function () { $('" + idDiv + "').fadeOut('slow'); }, 3000); setTimeout(function () { window.location.href = 'Login.aspx'; }, 4000) });";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptHideMessage", script, true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}