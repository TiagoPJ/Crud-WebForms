using Globo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Globo
{
    public partial class LogsPage : System.Web.UI.Page
    {
        private LogsBusiness _logsBusiness;
        private LogsBusiness LogsBusiness
        {
            get
            {
                if (_logsBusiness == null)
                    _logsBusiness = new LogsBusiness();

                return _logsBusiness;
            }
            set
            {
                value = _logsBusiness;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (!IsPostBack)
                    LoadLogs();
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }

        private void LoadLogs()
        {
            rptListLogs.DataSource = LogsBusiness.ListLogs();
            rptListLogs.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void rptListLogs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LoadLogs();
        }
    }
}