using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globo.DAL
{
    public class UsersData
    {
        private MongoDB _mongoDB;
        private MongoDB MongoDB
        {
            get
            {
                if (_mongoDB == null)
                    _mongoDB = new MongoDB();

                return _mongoDB;
            }
            set
            {
                value = _mongoDB;
            }
        }
        public void SaveUser(Users user)
        {  
            MongoDB.Save(user);
            MongoDB.SaveLog("Insert", user.Name, "User", user.Email);
        }

        public Users GetUser(string Email, string Password)
        {
            return MongoDB.Get<Users>(x => x.Email.Equals(Email) && x.Password.Equals(Password));
        }

        public bool VerifyExistUser(string Email)
        {
            return MongoDB.GetAll<Users>().Where(x => x.Email.Equals(Email)).ToList().Count > 0;
        }
    }
}