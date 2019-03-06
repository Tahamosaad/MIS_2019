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
    
    public partial class PurchaseHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseHdr()
        {
            this.PayablesPurDtl = new HashSet<PayablesPurDtl>();
            this.PmtApprovePurDtl = new HashSet<PmtApprovePurDtl>();
            this.PmtApprovePurDtl1 = new HashSet<PmtApprovePurDtl>();
            this.PurchaseAccDtl = new HashSet<PurchaseAccDtl>();
            this.PurchaseDtl = new HashSet<PurchaseDtl>();
            this.PurShipmentsInv = new HashSet<PurShipmentsInv>();
        }
    
        public string PurNum { get; set; }
        public int BrnSerial { get; set; }
        public string BranchCode { get; set; }
        public System.DateTime PurDate { get; set; }
        public byte Bill { get; set; }
        public string VendCode { get; set; }
        public string BuyerCode { get; set; }
        public string InvNum { get; set; }
        public int IsCredit { get; set; }
        public string OrderNum { get; set; }
        public string Terms { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public double ChangeRate { get; set; }
        public string ShipperCode { get; set; }
        public string DispatchNum { get; set; }
        public Nullable<System.DateTime> DispatchDate { get; set; }
        public Nullable<System.DateTime> FWDCollectionDate { get; set; }
        public Nullable<System.DateTime> InvReceivingDate { get; set; }
        public string CenterCode { get; set; }
        public string Address { get; set; }
        public string PoBox { get; set; }
        public string Fax { get; set; }
        public string AltrFax { get; set; }
        public string Phone { get; set; }
        public string AltrPhone { get; set; }
        public string Telx { get; set; }
        public string AltrTelx { get; set; }
        public string Contact { get; set; }
        public string ContactTitle { get; set; }
        public string OthContact { get; set; }
        public string OthContactTitle { get; set; }
        public string E_Mail { get; set; }
        public int IsPosted { get; set; }
        public int C__Shipped { get; set; }
        public int Closed { get; set; }
        public string TransCode { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
        public System.DateTime CloseDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayablesPurDtl> PayablesPurDtl { get; set; }
        public virtual Persons Persons { get; set; }
        public virtual Persons Persons1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PmtApprovePurDtl> PmtApprovePurDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PmtApprovePurDtl> PmtApprovePurDtl1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseAccDtl> PurchaseAccDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDtl> PurchaseDtl { get; set; }
        public virtual PurShippers PurShippers { get; set; }
        public virtual Terms Terms1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurShipmentsInv> PurShipmentsInv { get; set; }
    }
}
