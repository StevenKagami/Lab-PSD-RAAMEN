using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Repository
{
    public class Role_Repository
    {
        Database1Entities1 db = new Database1Entities1();

        public string GetsRoles(int id)
        {
            Role role = db.Roles.Where(x => x.Id== id).FirstOrDefault();
            return role.name;
        }
    }
    
}