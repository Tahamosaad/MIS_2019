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
    
    public partial class SalesOrderHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesOrderHdr()
        {
            this.SalesOrderDtl = new HashSet<SalesOrderDtl>();
        }
    
        public string OrderNum { get; set; }
        public int BrnSerial { get; set; }
        public string BranchCode { get; set; }
        public string ServerCode { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string CustCode { get; set; }
        public string SalesMan { get; set; }
        public string PurOrder { get; set; }
        public string Terms { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public double ChangeRate { get; set; }
        public int DeliveryOrder { get; set; }
        public string DeliveryMethodCode { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public int Canceled { get; set; }
        public int Approved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public string Address { get; set; }
        public string ShipAddress { get; set; }
        public string PoBox { get; set; }
        public string ShipPoBox { get; set; }
        public string Fax { get; set; }
        public string ShipFax { get; set; }
        public string AltrFax { get; set; }
        public string ShipAltrFax { get; set; }
        public string Phone { get; set; }
        public string ShipPhone { get; set; }
        public string AltrPhone { get; set; }
        public string ShipAltrPhone { get; set; }
        public string Telx { get; set; }
        public string ShipTelx { get; set; }
        public string AltrTelx { get; set; }
        public string ShipAltrTelx { get; set; }
        public string Contact { get; set; }
        public string ContactTitle { get; set; }
        public string OthContact { get; set; }
        public string OthContactTitle { get; set; }
        public string E_Mail { get; set; }
        public int IsPosted { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
    
        public virtual Currencies Currencies { get; set; }
        public virtual Persons Persons { get; set; }
        public virtual Persons Persons1 { get; set; }
        public virtual SalDeliveryMethods SalDeliveryMethods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderDtl> SalesOrderDtl { get; set; }
        public virtual Terms Terms1 { get; set; }
    }
}
