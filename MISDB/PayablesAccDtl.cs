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
    
    public partial class PayablesAccDtl
    {
        public string ID { get; set; }
        public string DocNum { get; set; }
        public string AccID { get; set; }
        public string PersonCode { get; set; }
        public double Value { get; set; }
        public string Memo { get; set; }
        public int IsCharges { get; set; }
    
        public virtual Accounts Accounts { get; set; }
        public virtual PayablesHdr PayablesHdr { get; set; }
    }
}