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
    
    public partial class ReservationHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReservationHdr()
        {
            this.ReservationDtl = new HashSet<ReservationDtl>();
        }
    
        public string RsvNum { get; set; }
        public string BranchCode { get; set; }
        public int BrnSerial { get; set; }
        public System.DateTime TransDate { get; set; }
        public string SalesMan { get; set; }
        public int IsExpired { get; set; }
        public int Approved { get; set; }
        public string ApprovedBy { get; set; }
        public int IsPosted { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationDtl> ReservationDtl { get; set; }
    }
}
