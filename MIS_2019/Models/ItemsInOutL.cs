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
    
    public partial class ItemsInOutL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemsInOutL()
        {
            this.ItemSerials = new HashSet<ItemSerials>();
        }
    
        public string Serial { get; set; }
        public string Trn_ID { get; set; }
        public string StoreCode { get; set; }
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public string ID { get; set; }
        public int CalCost { get; set; }
        public string EntryNum { get; set; }
    
        public virtual ItemsDirectory ItemsDirectory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSerials> ItemSerials { get; set; }
        public virtual ItemsInOutH ItemsInOutH { get; set; }
    }
}
