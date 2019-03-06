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
    
    public partial class PmtApproveHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PmtApproveHdr()
        {
            this.PmtApproveAccDtl = new HashSet<PmtApproveAccDtl>();
            this.PmtApprovePurDtl = new HashSet<PmtApprovePurDtl>();
            this.PayablesHdr = new HashSet<PayablesHdr>();
        }
    
        public string PASNum { get; set; }
        public int BrnSerial { get; set; }
        public string BranchCode { get; set; }
        public System.DateTime PASDate { get; set; }
        public int Expenses { get; set; }
        public string RequestNum { get; set; }
        public string PersonCode { get; set; }
        public string Payee { get; set; }
        public int PayMethod { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public double ChangeRate { get; set; }
        public double AmountCurr { get; set; }
        public Nullable<int> BankNum { get; set; }
        public string Notes { get; set; }
        public int Canceled { get; set; }
        public int Verified { get; set; }
        public string VerifiedBy { get; set; }
        public Nullable<System.DateTime> VerifiedDate { get; set; }
        public int Approved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public int IsPosted { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
    
        public virtual PayMethods PayMethods { get; set; }
        public virtual Persons Persons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PmtApproveAccDtl> PmtApproveAccDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PmtApprovePurDtl> PmtApprovePurDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayablesHdr> PayablesHdr { get; set; }
    }
}