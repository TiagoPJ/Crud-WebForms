using Globo.Business;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Globo.Security;

namespace Globo
{
    public partial class Login : System.Web.UI.Page
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
            if (Request.IsAuthenticated)
            {
                ReirectToDefaultPage();
            }
        }

        private void ReirectToDefaultPage()
        {
            MsgSucess.Text = "Olá, você já esteve por aqui, não é preciso logar, você será redirecionado!";
            divSucess.Visible = true;
            string script = " $(document).ready(function () { setTimeout(function () { $('#divSucess').fadeOut('slow'); }, 5000); setTimeout(function () { window.location='Default.aspx'; }, 5000);  }); ";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptHideMessage", script, true);
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

            string script = " $(document).ready(function () { setTimeout(function () { $('" + idDiv + "').fadeOut('slow'); }, 5000) }); ";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptHideMessage", script, true);
        }

        protected void btnAcess_Click(object sender, EventArgs e)
        {
            Users user = userBusiness.GetUser(txtEmail.Text, txtPassword.Text);

            if (user != null)
            {
                HttpCookie cookie = new Authentication().AddUserAuthentication(txtEmail.Text, txtPassword.Text);
                Response.Cookies.Add(cookie);
                Response.Redirect("Default.aspx");
            }
            else
                ShowMessage("User not found.", true);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}