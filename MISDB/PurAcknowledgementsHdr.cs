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
    
    public partial class PurAcknowledgementsHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurAcknowledgementsHdr()
        {
            this.PurAcknowledgementsDtl = new HashSet<PurAcknowledgementsDtl>();
        }
    
        public string AckNum { get; set; }
        public int BrnSerial { get; set; }
        public string BranchCode { get; set; }
        public System.DateTime AckDate { get; set; }
        public string VendCode { get; set; }
        public string VendRefNum { get; set; }
        public string PONum { get; set; }
        public string SONum { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public double ChangeRate { get; set; }
        public string ContactName { get; set; }
        public string OrderType { get; set; }
        public string ShipmentTerms { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public int IsPosted { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
    
        public virtual Currencies Currencies { get; set; }
        public virtual Persons Persons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurAcknowledgementsDtl> PurAcknowledgementsDtl { get; set; }
    }
}
