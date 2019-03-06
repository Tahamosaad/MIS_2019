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
    
    public partial class ReceivablesHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReceivablesHdr()
        {
            this.ReceivablesAccDtl = new HashSet<ReceivablesAccDtl>();
            this.ReceivablesInvDtl = new HashSet<ReceivablesInvDtl>();
        }
    
        public string DocNum { get; set; }
        public string Serial { get; set; }
        public string BranchCode { get; set; }
        public string ExtLetter { get; set; }
        public System.DateTime DocDate { get; set; }
        public int Income { get; set; }
        public string PersonCode { get; set; }
        public string Payee { get; set; }
        public string AccCode { get; set; }
        public int PayMethod { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public double ChangeRate { get; set; }
        public double AmountCurr { get; set; }
        public string ChqNum { get; set; }
        public Nullable<System.DateTime> ChqDate { get; set; }
        public string BankName { get; set; }
        public int Collected { get; set; }
        public Nullable<System.DateTime> ChqCollectedDate { get; set; }
        public string CenterCode { get; set; }
        public int IsPosted { get; set; }
        public string TransCode { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
    
        public virtual PayMethods PayMethods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceivablesAccDtl> ReceivablesAccDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceivablesInvDtl> ReceivablesInvDtl { get; set; }
    }
}
