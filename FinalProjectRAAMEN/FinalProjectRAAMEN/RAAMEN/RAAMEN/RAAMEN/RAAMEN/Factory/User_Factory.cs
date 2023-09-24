using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Factory
{
    public class User_Factory
    {
        public static User CreateUsser(String name, String email, String gender, String password, int roleid)
        {
            User newUser = new User()
            {
                Username = name,
                Email = email,
                Gender = gender,
                Password = password,
                Roleid = roleid
            };
            return newUser;
        }
    }
}