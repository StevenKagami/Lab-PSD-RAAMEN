using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;

namespace RAAMEN.View
{
    public partial class NavigationBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }

            string role = Session["Role"].ToString();
            if (role.Equals("Staff"))
            {
                Home.Visible = true;
                ManageRamen.Visible = true;
                OrderQueue.Visible = true;
            }
            else if (role.Equals("Member"))
            {
                OrderRamen.Visible = true;
                History.Visible = true;
            }
            else if (role.Equals("Admin"))
            {
                ManageRamen.Visible = true;
                OrderQueue.Visible = true;
                History.Visible = true;
                Report.Visible = true;
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            string[] cookies = Response.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Abandon();
            Response.Redirect("~/View/Login.aspx");
        }

        protected void OrderRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/OrderRamen.aspx");
        }

        protected void History_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/History.aspx");
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void ManageRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageRamen.aspx");
        }

        protected void OrderQueue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/OrderQueue.aspx");
        }

        protected void Report_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Report.aspx");
        }

        protected void ProfilePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Profile.aspx");
        }
    }
}