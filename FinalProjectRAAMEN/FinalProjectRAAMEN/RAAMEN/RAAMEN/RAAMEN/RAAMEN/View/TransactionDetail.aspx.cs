using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Handler;
using RAAMEN.Controller;
using RAAMEN.Model;

namespace RAAMEN.View
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        Transaction_Handler th = new Transaction_Handler();
        User_Handler uh = new User_Handler();
        Ramen_Handler rh = new Ramen_Handler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }

            string Roles = Session["Role"].ToString();
            if (Roles == "Staff")
            {
                Response.Redirect("~/View/Home.aspx");
            }

            int TransactionId = Convert.ToInt32(Request["ID"]);
            List<Detail> Details = th.GetsDetailHeader(TransactionId);

            Header Headers = th.GetsHeader(TransactionId);

            TrId.Text = Headers.Id.ToString();
            Staff.Text = uh.GetsUsser(Headers.Staffid).Username;
            Date.Text = Headers.Date.ToString();

            if (Roles == "Admin")
            {
                if (Headers.Staffid == 9)
                {
                    Response.Redirect("~/View/Home.aspx");
                }

                Customer.Text = uh.GetsUsser(Headers.Customerid).Username;
                Customer.Visible = true;
                CustomerLabel.Visible = true;
            }

            TrDetailGridView.DataSource = Details.Select(x => new
            {
                Name = rh.GetsRamen(x.Ramenid).Name,
                Price = rh.GetsRamen(x.Ramenid).Price,
                Qty = x.Quantity,
                Total = x.Quantity * Convert.ToInt32(rh.GetsRamen(x.Ramenid).Price)
            });
            TrDetailGridView.DataBind();
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/History.aspx");
        }
    }
}