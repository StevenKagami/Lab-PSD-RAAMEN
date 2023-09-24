using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;
using RAAMEN.Factory;

namespace RAAMEN.Repository
{
    public class TransactionHeaderRepository
    {
        Database1Entities1 db = new Database1Entities1();

        public Header PutHeader(int staffId, int custId, DateTime date)
        {
            Header newHeader = TransactionHeaderFactory.CreateTransactionHeader(staffId, custId, date);

            db.Headers.Add(newHeader);
            db.SaveChanges();

            return newHeader;
        }

        public Header GetsHeaders(int id)
        {
            Header header = db.Headers.Where(x => x.Id == id).FirstOrDefault();
            return header;
        }

        public void HandlesOrder(int staffId, int transactionId)
        {
            Header header = db.Headers.Where(x => x.Id == transactionId).FirstOrDefault();
            header.Staffid = staffId;
            db.SaveChanges();
        }

        public List<Header> GetsAllHeaders()
        {
            List<Header> headerlist = db.Headers.ToList();
            return headerlist;
        }

        public List<Header> GetsHandlerHeader()
        {
            List<Header> headers = db.Headers.Where(x => x.Staffid != 9).ToList();
            return headers;
        }

        public List<Header> GetsHeadersCustomer(int custId)
        {
            List<Header> headerlist = db.Headers.Where(x => x.Customerid == custId).ToList();
            return headerlist;
        }

    }
}