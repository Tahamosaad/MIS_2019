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
    
    public partial class PORequestDtl
    {
        public string ID { get; set; }
        public string RequestNum { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string PartNumber { get; set; }
        public double Qty { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> OrderedQty { get; set; }
        public Nullable<double> OnHndQty { get; set; }
        public Nullable<double> InTransit { get; set; }
        public Nullable<double> BO { get; set; }
        public string Memo { get; set; }
        public string Ord_ID { get; set; }
    
        public virtual SalesOrderDtl SalesOrderDtl { get; set; }
        public virtual PORequestHdr PORequestHdr { get; set; }
    }
}
