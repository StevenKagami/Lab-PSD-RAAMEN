using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Factory
{
    public class TransactionDetailFactory
    {
        public static Detail CreateTransactionDetail(int headerId, int ramenId, int quantity)
        {
            Detail newDetail = new Detail()
            {
                Ramenid = ramenId,
                Headerid = headerId,
                Quantity = quantity

            };
            return newDetail;
        }
    }
}