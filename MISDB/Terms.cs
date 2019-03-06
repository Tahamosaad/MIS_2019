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
    
    public partial class Terms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Terms()
        {
            this.ExpensesRequestsHdr = new HashSet<ExpensesRequestsHdr>();
            this.PORequestHdr = new HashSet<PORequestHdr>();
            this.PurchaseHdr = new HashSet<PurchaseHdr>();
            this.PurchaseOrderHdr = new HashSet<PurchaseOrderHdr>();
            this.SalesHdr = new HashSet<SalesHdr>();
            this.SalesOrderHdr = new HashSet<SalesOrderHdr>();
            this.SalQuotationsHdr = new HashSet<SalQuotationsHdr>();
        }
    
        public string Terms1 { get; set; }
        public int CreditFor { get; set; }
        public double Prepayment { get; set; }
        public double CashOnDelivery { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpensesRequestsHdr> ExpensesRequestsHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORequestHdr> PORequestHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseHdr> PurchaseHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderHdr> PurchaseOrderHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesHdr> SalesHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderHdr> SalesOrderHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalQuotationsHdr> SalQuotationsHdr { get; set; }
    }
}