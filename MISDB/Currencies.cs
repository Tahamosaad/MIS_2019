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
    
    public partial class Currencies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Currencies()
        {
            this.AccJournalDtl = new HashSet<AccJournalDtl>();
            this.ItemsDirectory = new HashSet<ItemsDirectory>();
            this.PurAcknowledgementsHdr = new HashSet<PurAcknowledgementsHdr>();
            this.PurchaseOrderHdr = new HashSet<PurchaseOrderHdr>();
            this.PORequestHdr = new HashSet<PORequestHdr>();
            this.SalesOrderHdr = new HashSet<SalesOrderHdr>();
            this.SalQuotationsHdr = new HashSet<SalQuotationsHdr>();
        }
    
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public double ChangeRate { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccJournalDtl> AccJournalDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemsDirectory> ItemsDirectory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurAcknowledgementsHdr> PurAcknowledgementsHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderHdr> PurchaseOrderHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORequestHdr> PORequestHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderHdr> SalesOrderHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalQuotationsHdr> SalQuotationsHdr { get; set; }
    }
}
