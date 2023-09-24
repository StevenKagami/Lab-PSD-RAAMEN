using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Controller;
using RAAMEN.Handler;
using RAAMEN.Report;

namespace RAAMEN.View
{
    public partial class Report : System.Web.UI.Page
    {
        Transaction_Handler th = new Transaction_Handler();
        Ramen_Handler rh = new Ramen_Handler();
        User_Handler uh = new User_Handler();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }

            if (Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/View/OrderRamen.aspx");
            }

            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;

            DataSet1 data = loadData(th.GetsHandlerHeader());

            report.SetDataSource(data);
        }

        public DataSet1 loadData(List<Header> Transactions)
        {
            DataSet1 DataNews = new DataSet1();
            var TableHeaders = DataNews.Header;
            var TableDetails = DataNews.Detail;
            var GrandTotal = DataNews.Total;
            int GrandTotalCount = 0;

            foreach (Header Headers in Transactions)
            {
                var NewRowHeaders = TableHeaders.NewRow();
                int subtotal = 0;
                NewRowHeaders["Id"] = Headers.Id;
                NewRowHeaders["CustomerName"] = uh.GetsUsser(Headers.Customerid).Username;
                NewRowHeaders["StaffName"] = uh.GetsUsser(Headers.Staffid).Username;
                NewRowHeaders["Date"] = Headers.Date;
                TableHeaders.Rows.Add(NewRowHeaders);

                foreach (Detail detail in Headers.Details)
                {
                    var NewRowDetails = TableDetails.NewRow();
                    Ramen ramen = rh.GetsRamen(detail.Ramenid);
                    NewRowDetails["Headerid"] = detail.Headerid;
                    NewRowDetails["RamenName"] = ramen.Name;
                    NewRowDetails["Price"] = ramen.Price;
                    NewRowDetails["Quantity"] = detail.Quantity;
                    NewRowDetails["Total"] = Convert.ToInt32(ramen.Price) * detail.Quantity;
                    subtotal += (Convert.ToInt32(ramen.Price) * detail.Quantity);

                    TableDetails.Rows.Add(NewRowDetails);
                }

                NewRowHeaders["SubTotal"] = subtotal;

                GrandTotalCount += subtotal;
            }

            var NewGrandTotalCount = GrandTotal.NewRow();
            NewGrandTotalCount["GrandTotal"] = GrandTotalCount;
            GrandTotal.Rows.Add(NewGrandTotalCount);
            return DataNews;
        }
    }
}