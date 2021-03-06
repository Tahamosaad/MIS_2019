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
    
    public partial class SalesOrderDtl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesOrderDtl()
        {
            this.ItemRequestDtl = new HashSet<ItemRequestDtl>();
            this.PORequestDtl = new HashSet<PORequestDtl>();
            this.SalesDtl = new HashSet<SalesDtl>();
        }
    
        public string ID { get; set; }
        public string OrderNum { get; set; }
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public Nullable<double> OrderedQty { get; set; }
        public string Quot_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemRequestDtl> ItemRequestDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORequestDtl> PORequestDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesDtl> SalesDtl { get; set; }
        public virtual SalesOrderHdr SalesOrderHdr { get; set; }
        public virtual SalQuotationsDtl SalQuotationsDtl { get; set; }
    }
}
