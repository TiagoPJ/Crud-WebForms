using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace Globo.Security
{
    public class Authentication
    {
        public HttpCookie AddUserAuthentication(string email, string password)
        {
            string userDataString = string.Concat(email, "|", password);

            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(email, false);
            return GenerateCookey(userDataString, authCookie);
        }

        public HttpCookie AddCharacterId(string Id)
        {
            try
            {
                HttpCookie myCookie = new HttpCookie("Character");
                myCookie.Expires = DateTime.Now.AddHours(1);
                myCookie.Value = Id;
                return myCookie;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteCookie(HttpCookie httpCookie)
        {
            try
            {
                HttpContext.Current.Request.Cookies.Remove(httpCookie.Name);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public HttpCookie GetCookie(string cookeyName)
        {
            return new HttpCookie(cookeyName);
        }
        private static HttpCookie GenerateCookey(string userDataString, HttpCookie authCookie)
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);

            authCookie.Value = FormsAuthentication.Encrypt(newTicket);

            return authCookie;
        }
    }
}