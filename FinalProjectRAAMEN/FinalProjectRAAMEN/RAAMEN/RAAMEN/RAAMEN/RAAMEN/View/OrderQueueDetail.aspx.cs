using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Handler;

namespace RAAMEN.View
{
    public partial class OrderQueueDetail : System.Web.UI.Page
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

            if (Session["Role"].ToString() == "Member")
            {
                Response.Redirect("~/View/OrderRamen.aspx");
            }

            int TransactionId = Convert.ToInt32(Request["ID"]);
            List<Detail> Details = th.GetsDetailHeader(TransactionId);

            Header Headers = th.GetsHeader(TransactionId);

            TrId.Text = Headers.Id.ToString();
            Staff.Text = uh.GetsUsser(Headers.Staffid).Username;
            Customer.Text = uh.GetsUsser(Headers.Customerid).Username;
            Date.Text = Headers.Date.ToString();

            TrDetailGridView.DataSource = Details.Select(x => new
            {
                Name = rh.GetsRamen(x.Ramenid).Name,
                Price = rh.GetsRamen(x.Ramenid).Price,
                Qty = x.Quantity,
                Total = x.Quantity * Convert.ToInt32(rh.GetsRamen(x.Ramenid).Price)
            });
            TrDetailGridView.DataBind();
        }
        protected void HandleButton_Click(object sender, EventArgs e)
        {
            int trId = Convert.ToInt32(Request["ID"]);
            int staffId = Convert.ToInt32(Session["UserID"]);
            th.HandlerOrder(trId, staffId);
            Response.Redirect("~/View/OrderQueue.aspx");
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/OrderQueue.aspx");
        }

    }
}