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
    
    public partial class ServiceOrderHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceOrderHdr()
        {
            this.ServiceOrderDtl = new HashSet<ServiceOrderDtl>();
        }
    
        public string OrderNum { get; set; }
        public int BrnSerial { get; set; }
        public string BranchCode { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string SerialNum { get; set; }
        public string ItemCode { get; set; }
        public string SaleNum { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string InvCustCode { get; set; }
        public Nullable<System.DateTime> PromiseDate { get; set; }
        public string ServiceMan { get; set; }
        public Nullable<System.DateTime> DateOut { get; set; }
        public string Problem { get; set; }
        public string TechAction { get; set; }
        public string Comments { get; set; }
        public string ServiceTypeCode { get; set; }
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
        public int Canceled { get; set; }
        public int IsPosted { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
    
        public virtual ItemsDirectory ItemsDirectory { get; set; }
        public virtual Persons Persons { get; set; }
        public virtual Persons Persons1 { get; set; }
        public virtual SalesHdr SalesHdr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOrderDtl> ServiceOrderDtl { get; set; }
        public virtual ServiceTypes ServiceTypes { get; set; }
    }
}
