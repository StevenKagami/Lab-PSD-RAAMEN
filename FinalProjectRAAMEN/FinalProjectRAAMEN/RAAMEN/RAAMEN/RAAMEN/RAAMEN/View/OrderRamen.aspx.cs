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
    public partial class OrderRamen : System.Web.UI.Page
    {
        Ramen_Handler rh = new Ramen_Handler();
        Transaction_Handler th = new Transaction_Handler();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }

            if (Session["Role"].ToString() != "Member")
            {
                Response.Redirect("~/View/Home.aspx");
            }


            List<Ramen> Raamens = rh.GetRamens();
            RamenGridView.DataSource = Raamens;
            RamenGridView.DataBind();

            if (Session["Cart"] == null)
            {
                CartIsEmpty.Visible = true;
            }
            else
            {
                CartIsEmpty.Visible = false;
                List<Tuple<Ramen, int>> RaamenCart = (List<Tuple<Ramen, int>>)Session["Cart"];
                BindCartItem(RaamenCart);
            }
        }

        protected void RamenGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                CartIsEmpty.Visible = false;

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow RowSelect = RamenGridView.Rows[index];
                string RaamenName = RowSelect.Cells[0].Text;

                List<Tuple<Ramen, int>> RaamenCart = (List<Tuple<Ramen, int>>)Session["Cart"];
                Ramen RaamenOrder = rh.GetsRamenName(RaamenName);

                if (Session["Cart"] != null)
                {
                    int RaamenIndex = RaamenCart.FindIndex(x => x.Item1.Id == RaamenOrder.Id);
                    if (RaamenIndex == -1)
                    {
                        Tuple<Ramen, int> newCartItem = new Tuple<Ramen, int>(RaamenOrder, 1);
                        RaamenCart.Add(newCartItem);
                    }
                    else
                    {
                        int incrementQty = RaamenCart[RaamenIndex].Item2 + 1;

                        RaamenCart[RaamenIndex] = new Tuple<Ramen, int>(RaamenOrder, incrementQty);
                    }
                }
                else
                {


                    Tuple<Ramen, int> newCartItem = new Tuple<Ramen, int>(RaamenOrder, 1);
                    RaamenCart = new List<Tuple<Ramen, int>>();
                    RaamenCart.Add(newCartItem);
                }

                BindCartItem(RaamenCart);
                Session["Cart"] = RaamenCart;
            }
        }


        protected void CartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveOrder")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow RowSelect = CartGridView.Rows[index];
                string RaamenName = RowSelect.Cells[0].Text;
                Ramen DeletesRamen = rh.GetsRamenName(RaamenName);

                List<Tuple<Ramen, int>> RaamenCart = (List<Tuple<Ramen, int>>)Session["Cart"];
                int RaamenIndex = RaamenCart.FindIndex(x => x.Item1.Id == DeletesRamen.Id);
                int Quantity = RaamenCart[RaamenIndex].Item2;

                if (Quantity > 1)
                {
                    RaamenCart[RaamenIndex] = new Tuple<Ramen, int>(DeletesRamen, Quantity - 1);
                }
                else
                {
                    RaamenCart.RemoveAt(RaamenIndex);
                }

                if (RaamenCart.Count == 0)
                {
                    CartIsEmpty.Visible = true;
                }

                BindCartItem(RaamenCart);
                Session["Cart"] = RaamenCart;
            }
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            List<Tuple<Ramen, int>> RaamenCart = (List<Tuple<Ramen, int>>)Session["Cart"];

            ClearCart(RaamenCart);

            Session["Cart"] = RaamenCart;
        }

        protected void BuyCartBtn_Click(object sender, EventArgs e)
        {
            List<Tuple<Ramen, int>> RaamenCart = (List<Tuple<Ramen, int>>)Session["Cart"];

            User cust = (User)Session["User"];
            int custId = cust.Id;


            Header newHeader = th.PutHeader(custId, 9, DateTime.Now);
            foreach (Tuple<Ramen, int> ramen in RaamenCart)
            {
                th.PutDetail(newHeader.Id, ramen.Item1.Id, ramen.Item2);
            }

            ClearCart(RaamenCart);
            Session["Cart"] = RaamenCart;
        }

        private void ClearCart(List<Tuple<Ramen, int>> RaamenCart)
        {
            RaamenCart.Clear();
            BindCartItem(RaamenCart);
            CartIsEmpty.Visible = true;
        }

        private void BindCartItem(List<Tuple<Ramen, int>> RaamenCart)
        {
            CartGridView.DataSource = RaamenCart.Select(x => new
            {
                Name = x.Item1.Name,
                Qty = x.Item2
            });
            CartGridView.DataBind();
        }

    }
}