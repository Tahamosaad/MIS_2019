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
    
    public partial class PurchaseDtl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseDtl()
        {
            this.PurchaseReturnDtl = new HashSet<PurchaseReturnDtl>();
            this.PurShipmentsBrnDist = new HashSet<PurShipmentsBrnDist>();
            this.PurShipmentsItems = new HashSet<PurShipmentsItems>();
        }
    
        public string ID { get; set; }
        public string Ord_ID { get; set; }
        public string PurNum { get; set; }
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public string Memo { get; set; }
    
        public virtual PurchaseHdr PurchaseHdr { get; set; }
        public virtual PurchaseOrderDtl PurchaseOrderDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseReturnDtl> PurchaseReturnDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurShipmentsBrnDist> PurShipmentsBrnDist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurShipmentsItems> PurShipmentsItems { get; set; }
    }
}
