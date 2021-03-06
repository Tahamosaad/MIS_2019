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
    
    public partial class ItemsMPG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemsMPG()
        {
            this.ItemsDirectory = new HashSet<ItemsDirectory>();
        }
    
        public string MPGCode { get; set; }
        public string MPGName { get; set; }
        public string MPGLongName { get; set; }
        public string MPGCategoryCode { get; set; }
        public double StandardDiscount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string IssuedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemsDirectory> ItemsDirectory { get; set; }
        public virtual ItemsMPGCategory ItemsMPGCategory { get; set; }
    }
}
