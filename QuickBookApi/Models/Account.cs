using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBook.BAL.Models
{
    public class Account
    {
        public string FullyQualifiedName { get; set; }
        public string domain { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string AccountSubType { get; set; }
        public CurrencyRef CurrencyRef { get; set; }
        public int CurrentBalanceWithSubAccounts { get; set; }
        public bool sparse { get; set; }
        public MetaData MetaData { get; set; }
        public string AccountType { get; set; }
        public int CurrentBalance { get; set; }
        public bool Active { get; set; }
        public string SyncToken { get; set; }
        public string Id { get; set; }
        public bool SubAccount { get; set; }
    }

    public class AccountObj
    {
        public Account Account { get; set; }
        public DateTime time { get; set; }
    }
}
