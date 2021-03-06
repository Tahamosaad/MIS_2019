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
    
    public partial class CostingHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CostingHdr()
        {
            this.CostingDtl = new HashSet<CostingDtl>();
            this.ItemsInOutH = new HashSet<ItemsInOutH>();
        }
    
        public string EntryNum { get; set; }
        public int BrnSerial { get; set; }
        public string BranchCode { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int Purchases { get; set; }
        public string VoucherNum { get; set; }
        public string ShipType { get; set; }
        public int IsPosted { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CostingDtl> CostingDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemsInOutH> ItemsInOutH { get; set; }
    }
}
