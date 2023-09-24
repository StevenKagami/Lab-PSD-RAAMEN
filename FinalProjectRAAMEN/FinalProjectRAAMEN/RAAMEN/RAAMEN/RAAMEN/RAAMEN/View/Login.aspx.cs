using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Controller;

namespace RAAMEN.View
{
    public partial class Login : System.Web.UI.Page
    {
        User_Controller uc = new User_Controller();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            String username = UsernameTextBox.Text;
            String password = PasswordTextBox.Text;
            bool remember = RememberMe.Checked;

            List<bool> validation = uc.Loginn(username, password, remember);

            if (!validation[0])
            {
                UsernameEmpty.Visible = true;
            }
            else
            {
                UsernameEmpty.Visible = false;
            }

            if (!validation[1])
            {
                PasswordEmpty.Visible = true;
            }
            else
            {
                PasswordEmpty.Visible = false;
            }

            if (!validation[2])
            {
                NoUser.Visible = true;
            }
            else
            {
                NoUser.Visible = false;
            }
        }
    }
}