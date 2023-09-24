using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Repository;
using RAAMEN.Model;

namespace RAAMEN.Handler
{
    public class Transaction_Handler
    {
        TransactionHeaderRepository thr = new TransactionHeaderRepository();
        TransactionDetailRepository tdr = new TransactionDetailRepository();


        public Header PutHeader(int custId, int staffId, DateTime date)
        {
            Header newHeader = thr.PutHeader(custId, staffId, date);
            return newHeader;
        }

        public void HandlerOrder(int trId, int staffId)
        {
            thr.HandlesOrder(trId, staffId);
        }

        public Header GetsHeader(int id)
        {
            Header header = thr.GetsHeaders(id);
            return header;
        }

        public List<Header> GetsHandlerHeader()
        {
            List<Header> headers = thr.GetsHandlerHeader();
            return headers;
        }

        public List<Header> GetsHeaderCustomer(int custId)
        {
            List<Header> headerList = thr.GetsHeadersCustomer(custId);
            return headerList;
        }

        public List<Header> GetsAllHeaders()
        {
            List<Header> headerList = thr.GetsAllHeaders();
            return headerList;
        }

        public void PutDetail(int headerId, int ramenId, int qty)
        {
            tdr.PutDetail(headerId, ramenId, qty);
        }

        public List<Detail> GetsDetailHeader(int headerId)
        {
            List<Detail> details = tdr.GetsDetailHeaders(headerId);
            return details;
        }
    }
}