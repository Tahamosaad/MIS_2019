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
    
    public partial class ServiceOrderDtl
    {
        public string OrderNum { get; set; }
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public Nullable<double> Price { get; set; }
        public string ID { get; set; }
    
        public virtual ItemsDirectory ItemsDirectory { get; set; }
        public virtual ServiceOrderHdr ServiceOrderHdr { get; set; }
    }
}