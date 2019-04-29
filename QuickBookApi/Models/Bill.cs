using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBookApi.Models
{
    public class APAccountRef
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class VendorRef
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class CurrencyRef
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class LinkedTxn
    {
        public string TxnId { get; set; }
        public string TxnType { get; set; }
    }

    public class SalesTermRef
    {
        public string value { get; set; }
    }

    public class TaxCodeRef
    {
        public string value { get; set; }
    }

    public class AccountRef
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class CustomerRef
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class AccountBasedExpenseLineDetail
    {
        public TaxCodeRef TaxCodeRef { get; set; }
        public AccountRef AccountRef { get; set; }
        public string BillableStatus { get; set; }
        public CustomerRef CustomerRef { get; set; }
    }

    public class Line
    {
        public string DetailType { get; set; }
        public double Amount { get; set; }
        public string Id { get; set; }
        public AccountBasedExpenseLineDetail AccountBasedExpenseLineDetail { get; set; }
        public string Description { get; set; }
    }

    public class MetaData
    {
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }

    public class Bill
    {
        public string SyncToken { get; set; }
        public string domain { get; set; }
        public APAccountRef APAccountRef { get; set; }
        public VendorRef VendorRef { get; set; }
        public string TxnDate { get; set; }
        public double TotalAmt { get; set; }
        public CurrencyRef CurrencyRef { get; set; }
        public List<LinkedTxn> LinkedTxn { get; set; }
        public SalesTermRef SalesTermRef { get; set; }
        public string DueDate { get; set; }
        public bool sparse { get; set; }
        public List<Line> Line { get; set; }
        public int Balance { get; set; }
        public string Id { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class BillObj
    {
        public Bill Bill { get; set; }
        public DateTime time { get; set; }
    }
}
