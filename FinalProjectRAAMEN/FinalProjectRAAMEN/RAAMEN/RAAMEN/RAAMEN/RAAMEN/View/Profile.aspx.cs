using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Handler;
using RAAMEN.Model;
using RAAMEN.Controller;

namespace RAAMEN.View
{
    public partial class Profile : System.Web.UI.Page
    {
        User_Controller uc = new User_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            User CurrentUsser = (User)Session["User"];
            if (Session["User"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }


            if (IsPostBack == false)
            {
                UsernameTextBox.Text = CurrentUsser.Username;
                EmailTextBox.Text = CurrentUsser.Email;
                GenderList.SelectedValue = GenderList.Items.FindByText(CurrentUsser.Gender).ToString();
            }
        }



        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string gender = GenderList.SelectedItem.Text;
            string pass = PasswordTextBox.Text;

            List<bool> validation = uc.UpdatsUsser(userId, username, email, gender, pass);
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
                User CurrentUsser = (User)Session["User"];

                UsernameTextBox.Text = CurrentUsser.Username;
                EmailTextBox.Text = CurrentUsser.Email;
                GenderList.SelectedValue = GenderList.Items.FindByText(CurrentUsser.Gender).ToString();
            }
        }
    }
}