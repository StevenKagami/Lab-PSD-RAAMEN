using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;
using RAAMEN.Factory;

namespace RAAMEN.Repository
{
    public class TransactionDetailRepository
    {
        Database1Entities1 db = new Database1Entities1();

        public void PutDetail(int ramenId, int headerId, int quantity)
        {
            Detail newDetail = TransactionDetailFactory.CreateTransactionDetail(ramenId, headerId, quantity);
            db.Details.Add(newDetail);
            db.SaveChanges();
        }

        public List<Detail> GetsDetailHeaders(int headerId)
        {
            List<Detail> details = db.Details.Where(x => x.Headerid == headerId).ToList();
            return details;
        }
    }
}