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
    
    public partial class PurAcknowledgementsDtl
    {
        public string ID { get; set; }
        public string Ord_ID { get; set; }
        public string AckNum { get; set; }
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string Memo { get; set; }
    
        public virtual PurAcknowledgementsHdr PurAcknowledgementsHdr { get; set; }
        public virtual PurchaseOrderDtl PurchaseOrderDtl { get; set; }
    }
}
