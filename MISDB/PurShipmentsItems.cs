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
    
    public partial class PurShipmentsItems
    {
        public string Pur_ID { get; set; }
        public string ShipNum { get; set; }
        public string PurNum { get; set; }
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public string Origin { get; set; }
        public string Memo { get; set; }
    
        public virtual PurchaseDtl PurchaseDtl { get; set; }
    }
}
