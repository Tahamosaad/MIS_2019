//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MIS_2019.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Items
    {
        public string BrnItemCode { get; set; }
        public string ItemCode { get; set; }
        public string BranchCode { get; set; }
        public double ReorderLmt { get; set; }
        public double MaxQty { get; set; }
        public double MinQty { get; set; }
        public string SalAccID { get; set; }
        public string PurAccID { get; set; }
        public string CRAccID { get; set; }
        public string VRAccID { get; set; }
        public string COGSAccID { get; set; }
        public string IVAccID { get; set; }
        public string TrnAccID { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
        public string ServerCode { get; set; }
    
        public virtual ItemsDirectory ItemsDirectory { get; set; }
    }
}
