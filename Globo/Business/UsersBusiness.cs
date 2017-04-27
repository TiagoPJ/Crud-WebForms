using Globo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globo.Business
{
    public class UsersBusiness
    {
        private UsersData _usersData;
        private UsersData UsersData
        {
            get
            {
                if (_usersData == null)
                    _usersData = new UsersData();

                return _usersData;
            }
            set
            {
                value = _usersData;
            }
        }

        public void SaveUser(string email, string pass, string name)
        {
            Users user = new Users();
            user.Email = email;
            user.Password = pass;
            user.Name = name;

            UsersData.SaveUser(user);
        }

        public Users GetUser(string Email, string Password)
        {
            return UsersData.GetUser(Email, Password);
        }

        public bool VerifyExistUserByEmail(string Email)
        {
            return UsersData.VerifyExistUser(Email);
        }
    }
}