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
    
    public partial class SalesReturnHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesReturnHdr()
        {
            this.SalesReturnDtl = new HashSet<SalesReturnDtl>();
        }
    
        public string RetNum { get; set; }
        public int BrnSerial { get; set; }
        public string BranchCode { get; set; }
        public System.DateTime RetDate { get; set; }
        public string CustCode { get; set; }
        public int IsCredit { get; set; }
        public string SalesMan { get; set; }
        public string SaleNum { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public double ChangeRate { get; set; }
        public string CenterCode { get; set; }
        public int SpecialCommission { get; set; }
        public double TotCommission { get; set; }
        public int IsPosted { get; set; }
        public string TransCode { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
    
        public virtual Persons Persons { get; set; }
        public virtual Persons Persons1 { get; set; }
        public virtual SalesHdr SalesHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturnDtl> SalesReturnDtl { get; set; }
    }
}
