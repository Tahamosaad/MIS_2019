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
    
    public partial class TmpRepPurOutStandingInvoices
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string PersonCode { get; set; }
        public string PersonName { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public double ChangeRate { get; set; }
        public string PurNum { get; set; }
        public System.DateTime PurDate { get; set; }
        public string InvNum { get; set; }
        public string BuyerCode { get; set; }
        public string OrderNum { get; set; }
        public string Terms { get; set; }
        public double Amount { get; set; }
        public Nullable<double> Paid { get; set; }
        public int Bal { get; set; }
        public int BalL { get; set; }
    }
}
