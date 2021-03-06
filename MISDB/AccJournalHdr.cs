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
    
    public partial class AccJournalHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccJournalHdr()
        {
            this.AccJournalDtl = new HashSet<AccJournalDtl>();
        }
    
        public string Serial { get; set; }
        public int BrnSerial { get; set; }
        public string BranchCode { get; set; }
        public string TransNum { get; set; }
        public System.DateTime TransDate { get; set; }
        public string TransCode { get; set; }
        public string TransType { get; set; }
        public string GLPersonCode { get; set; }
        public string GLContactCode { get; set; }
        public string GLTerms { get; set; }
        public int GLIsCredit { get; set; }
        public Nullable<double> GLAmount { get; set; }
        public Nullable<double> GLAmountCurr { get; set; }
        public Nullable<double> GLTotCommission { get; set; }
        public string GLCurrencyCode { get; set; }
        public Nullable<double> GLChangeRate { get; set; }
        public int IsPosted { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccJournalDtl> AccJournalDtl { get; set; }
        public virtual AccTransTypes AccTransTypes { get; set; }
    }
}
