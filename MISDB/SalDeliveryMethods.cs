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
    
    public partial class SalDeliveryMethods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalDeliveryMethods()
        {
            this.SalesOrderHdr = new HashSet<SalesOrderHdr>();
        }
    
        public string DeliveryMethodCode { get; set; }
        public string DeliveryMethod { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string Issued_By { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderHdr> SalesOrderHdr { get; set; }
    }
}
