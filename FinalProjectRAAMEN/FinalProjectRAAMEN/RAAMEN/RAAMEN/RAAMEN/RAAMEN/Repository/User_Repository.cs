using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;
using RAAMEN.Factory;

namespace RAAMEN.Repository
{
    public class User_Repository
    {
        Database1Entities1 db = new Database1Entities1();
        Role_Repository rp = new Role_Repository();

        public void Registerr(string username, string email, string gender, string password)
        {
            User newUser = User_Factory.CreateUsser(username, email, gender, password, 2);
            db.Users.Add(newUser);
            db.SaveChanges();
        }

        public User Loginn(String username, String password)
        {
            User user = db.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            return user;
        }

        public void UpdateUsser(int userId, string username, string email, string gender)
        {
            User updUser = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            updUser.Username = username;
            updUser.Email = email;
            updUser.Gender = gender;

            db.SaveChanges();
        }

        public User GetsUserEmail(string email)
        {
            User user = db.Users.Where(x => x.Email == email).FirstOrDefault();
            return user;
        }

        public string GetsRoles(int id)
        {
            string role = rp.GetsRoles(id);
            return role;
        }

        public List<User> GetsCustomer()
        {
            List<User> custs = db.Users.Where(x => x.Roleid == 2).ToList();
            return custs;
        }

        public List<User> GetsStaff()
        {
            List<User> staffs = db.Users.Where(x => x.Roleid == 1).ToList();
            return staffs;
        }

        public User GetsUsser(int id)
        {
            User retUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
            return retUser;
        }
    }
}