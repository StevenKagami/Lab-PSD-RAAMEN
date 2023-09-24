using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Factory
{
    public class TransactionHeaderFactory
    {
        public static Header CreateTransactionHeader(int custId, int staffId, DateTime date)
        {
            Header newHeader = new Header()
            {
                Customerid = custId,
                Staffid = staffId,
                Date = date
            };

            return newHeader;
        }
    }
}