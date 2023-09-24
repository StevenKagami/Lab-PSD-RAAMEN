using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Handler;
using RAAMEN.Model;
using System.Text.RegularExpressions;



namespace RAAMEN.Controller
{
    public class User_Controller
    {
        User_Handler uh = new User_Handler();

        public List<bool> Registerr(string username, string email, string gender, string password, string confPass)
        {
            List<bool> validation = new List<bool>();
            bool valid = true;
            for (int i = 0; i < 5; i++)
            {
                validation.Add(true);
            }

            if (!Valid_Username(username))
            {
                validation[0] = false;
                valid = false;
            }

            if (!Valid_Email(email))
            {
                validation[1] = false;
                valid = false;
            }

            if (!Valid_Gender(gender))
            {
                validation[2] = false;
                valid = false;
            }

            if (!Valid_Password(password, confPass))
            {
                validation[3] = false;
                valid = false;
            }

            if (ValidSameEmail(email))
            {
                validation[4] = false;
                valid = false;
            }

            if (valid)
            {
                uh.Registerr(username, email, gender, password);
            }

            return validation;
        }

        public List<bool> Loginn(String username, String password, bool remember)
        {
            List<bool> validation = new List<bool>();
            bool valid = true;
            for (int i = 0; i < 3; i++)
            {
                validation.Add(true);
            }

            if (username.Length == 0)
            {
                validation[0] = false;
                valid = false;
            }

            if (password.Length == 0)
            {
                validation[1] = false;
                valid = false;
            }

            if (valid)
            {
                User user = uh.Loginn(username, password);

                if (user == null)
                {
                    validation[2] = false;
                }
                else
                {
                    if (remember)
                    {
                        HttpCookie cookie = new HttpCookie("user_cookie");
                        cookie.Value = user.Id.ToString();
                        cookie.Expires = DateTime.Now.AddHours(1);
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }

                    string role = uh.GetsRoles(user.Roleid);
                    HttpContext.Current.Session["User"] = user;
                    HttpContext.Current.Session["Role"] = role;
                    HttpContext.Current.Session["Username"] = user.Username;
                    HttpContext.Current.Session["UserID"] = user.Id;

                    if (role.Equals("Member"))
                    {
                        HttpContext.Current.Response.Redirect("~/View/OrderRamen.aspx");
                    }
                    else
                    {
                        HttpContext.Current.Response.Redirect("~/View/Home.aspx");
                    }
                }
            }

            return validation;
        }

        public List<bool> UpdatsUsser(int userId, string username, string email, string gender, string password)
        {
            List<bool> validation = new List<bool>();
            bool valid = true;
            for (int i = 0; i < 5; i++)
            {
                validation.Add(true);
            }

            if (!Valid_Username(username))
            {
                validation[0] = false;
                valid = false;
            }

            if (!Valid_Email(email))
            {
                validation[1] = false;
                valid = false;
            }

            if (!Valid_Gender(gender))
            {
                validation[2] = false;
                valid = false;
            }

            User curUser = uh.GetsUsser(userId);
            if (curUser.Password != password)
            {
                validation[3] = false;
                valid = false;
            }

            if (valid)
            {
                User sameUser = uh.GetsUserEmail(email);
                if (sameUser != null && userId != sameUser.Id)
                {
                    validation[4] = false;
                }
                else
                {
                    uh.UpdateUsser(userId, username, email, gender);
                    HttpContext.Current.Session["User"] = curUser;
                }
            }

            return validation;
        }

        private bool Valid_Username(string username)
        {
            if (username.Length >= 5 && username.Length <= 15)
            {
                string trimUname = Regex.Replace(username, @"\s", "");

                if (trimUname.All(Char.IsLetter))
                {
                    return true;

                }
            }

            return false;

        }

        private bool Valid_Email(string email)
        {
            if (email.EndsWith(".com") && email.Length != 0)
            {
                return true;
            }

            return false;
        }

        private bool Valid_Gender(string gender)
        {
            if (gender.Equals("Male") || gender.Equals("Female"))
            {
                return true;
            }

            return false;
        }

        private bool Valid_Password(string password, string confPass)
        {
            if (password == confPass && password.Length != 0)
            {
                return true;
            }

            return false;
        }

        private bool ValidSameEmail(string email)
        {
            User sameUser = uh.GetsUserEmail(email);
            if (sameUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}