
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;
using RAAMEN.Repository;

namespace RAAMEN.Handler
{
    public class User_Handler
    {
        User_Repository ur = new User_Repository();
        Role_Repository rr = new Role_Repository();

        public void Registerr(string username, string email, string gender, string password)
        {
            ur.Registerr(username, email, gender, password);
        }

        public User Loginn(String username, String password)
        {
            User user = ur.Loginn(username, password);
            return user;
        }

        public void UpdateUsser(int userId, string username, string email, string gender)
        {
            ur.UpdateUsser(userId, username, email, gender);
        }

        public User GetsUserEmail(string email)
        {
            User user = ur.GetsUserEmail(email);
            return user;
        }

        public string GetsRoles(int id)
        {
            string role = rr.GetsRoles(id);
            return role;
        }

        public List<User> GetsCustomers()
        {
            List<User> cust = ur.GetsCustomer();
            return cust;
        }

        public List<User> GetsStaff()
        {
            List<User> staff = ur.GetsStaff();
            return staff;
        }

        public User GetsUsser(int id)
        {
            User repUsser = ur.GetsUsser(id);
            return repUsser;
        }
    }
}