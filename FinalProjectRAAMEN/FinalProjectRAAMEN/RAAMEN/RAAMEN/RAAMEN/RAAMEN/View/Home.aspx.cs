using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Repository;
using RAAMEN.Model;
using RAAMEN.Controller;
using RAAMEN.Handler;

namespace RAAMEN.View
{ 
 public partial class Home : System.Web.UI.Page
{
    User_Handler uh = new User_Handler();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        string role = Session["Role"].ToString();
        if (role == "Member")
        {
            Response.Redirect("~/View/OrderRamen.aspx");
        }

        RoleLabel.Text = "Hello " + role + " " + Session["Username"].ToString();

        if (role == "Staff")
        {
            ListNameLbl.Text = "Customers List";

            List<User> custList = uh.GetsCustomers();
            UserGridView.DataSource = custList;
            UserGridView.DataBind();
        }
        else if (role == "Admin")
        {
            ListNameLbl.Text = "Staffs List";

            List<User> staffList = uh.GetsStaff();
            UserGridView.DataSource = staffList;
            UserGridView.DataBind();
        }

    }
  }

}