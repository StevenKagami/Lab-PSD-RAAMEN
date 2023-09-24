using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Controller;
using RAAMEN.Handler;

namespace RAAMEN.View
{
    public partial class Register : System.Web.UI.Page
    {
        User_Controller uc = new User_Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }



        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            String username = UsernameTextBox.Text;
            String email = EmailTextBox.Text;
            String gender = GenderList.SelectedItem.Text;
            String password = PasswordTextBox.Text;
            String confPass = ConfPasswordTextBox.Text;

            List<bool> validation = uc.Registerr(username, email, gender, password, confPass);
            bool valid = true;

            if (!validation[0])
            {
                UsernameValid.Visible = true;
                valid = false;
            }
            else
            {
                UsernameValid.Visible = false;
            }

            if (!validation[1])
            {
                EmailValid.Visible = true;
                valid = false;
            }
            else
            {
                EmailValid.Visible = false;
            }

            if (!validation[2])
            {
                GenderValid.Visible = true;
                valid = false;
            }
            else
            {
                GenderValid.Visible = false;
            }


          
            if (!validation[3])
            {
                PasswordValid.Visible = true;
                valid = false;
            }
            else
            {
                PasswordValid.Visible = false;
            }

            if (!validation[4])
            {
                ErrorLabel.Visible = true;
                valid = false;
            }
            else
            {
                ErrorLabel.Visible = false;
            }

            if (valid)
            {
                Response.Redirect("~/View/Login.aspx");
            }
        }
    }
}