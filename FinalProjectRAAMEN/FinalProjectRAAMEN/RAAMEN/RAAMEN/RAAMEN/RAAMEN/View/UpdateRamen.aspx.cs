﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Handler;
using RAAMEN.Controller;

namespace RAAMEN.View
{
    public partial class UpdateRamen : System.Web.UI.Page
    {
        Ramen_Controller rc = new Ramen_Controller();
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

            if (!IsPostBack)
            {
                List<Meat> meats = rh.GetsMeats();
                MeatDropDown.DataSource = meats;
                MeatDropDown.DataTextField = "Name";
                MeatDropDown.DataValueField = "Id";
                MeatDropDown.DataBind();
                MeatDropDown.Items.Insert(0, new ListItem("--Select--", String.Empty));

                string RaamenId = Request["ID"];
                Ramen CurentRaamen = rh.GetsRamen(Convert.ToInt32(RaamenId));

                NameTextBox.Text = CurentRaamen.Name;
                MeatDropDown.SelectedValue = CurentRaamen.Meatid.ToString();
                BrothTextBox.Text = CurentRaamen.Broth;
                PriceTextBox.Text = CurentRaamen.Price;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int RaamenId = Convert.ToInt32(Request["ID"]);
            string name = NameTextBox.Text;
            string meat = MeatDropDown.SelectedValue;
            string broth = BrothTextBox.Text;
            String price = PriceTextBox.Text;

            List<bool> validation = rc.updatesRamen(RaamenId, meat, name, broth, price);
            bool valid = true;

            if (!validation[0])
            {
                NameEmpty.Visible = true;
                valid = false;
            }
            else
            {
                NameEmpty.Visible = false;
            }

            if (!validation[1])
            {
                MeatEmpty.Visible = true;
                valid = false;
            }
            else
            {
                MeatEmpty.Visible = false;
            }

            if (!validation[2])
            {
                BrothEmpty.Visible = true;
                valid = false;
            }
            else
            {
                BrothEmpty.Visible = false;
            }

            if (!validation[3])
            {
                PriceEmpty.Visible = true;
                valid = false;
            }
            else
            {
                PriceEmpty.Visible = false;
            }

            if (valid)
            {
                Response.Redirect("~/View/ManageRamen.aspx");
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageRamen.aspx");
        }


    }
}