//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class TmpRepAccPersonState
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string PersonCode { get; set; }
        public string PersonName { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public double CreditLimit { get; set; }
        public string Serial { get; set; }
        public int BrnSerial { get; set; }
        public string TransNum { get; set; }
        public System.DateTime TransDate { get; set; }
        public string TransCode { get; set; }
        public string TransName { get; set; }
        public string Notes { get; set; }
        public double DebitCurr { get; set; }
        public double CreditCurr { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string Memo { get; set; }
        public Nullable<int> PayMethod { get; set; }
        public Nullable<int> PmtPayMethod { get; set; }
        public string Method { get; set; }
        public string PmtMethod { get; set; }
        public string ChqNum { get; set; }
        public Nullable<System.DateTime> ChqDate { get; set; }
        public string BankName { get; set; }
        public Nullable<int> Collected { get; set; }
        public Nullable<System.DateTime> ChqCollectedDate { get; set; }
        public string PmtChqNum { get; set; }
        public Nullable<System.DateTime> PmtChqDate { get; set; }
        public Nullable<int> BankNum { get; set; }
        public string PmtBankName { get; set; }
        public Nullable<int> PmtCollected { get; set; }
        public Nullable<System.DateTime> PmtChqCollectedDate { get; set; }
        public int PersonType { get; set; }
    }
}
