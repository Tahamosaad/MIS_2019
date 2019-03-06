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
    
    public partial class AccJournalDtl
    {
        public string Serial { get; set; }
        public string AccCode { get; set; }
        public string PersonCode { get; set; }
        public string CurrencyCode { get; set; }
        public double ChangeRate { get; set; }
        public double DebitCurr { get; set; }
        public double CreditCurr { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string Memo { get; set; }
        public string ItemCode { get; set; }
        public Nullable<double> Qty { get; set; }
        public Nullable<double> GLCommission { get; set; }
        public string ID { get; set; }
        public string Trn_ID { get; set; }
    
        public virtual AccJournalHdr AccJournalHdr { get; set; }
        public virtual Accounts Accounts { get; set; }
        public virtual Currencies Currencies { get; set; }
        public virtual Persons Persons { get; set; }
    }
}
