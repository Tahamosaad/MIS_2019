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
    
    public partial class ItemCategory4
    {
        public string Cat4Code { get; set; }
        public string Cat4Name { get; set; }
        public string Cat3Code { get; set; }
    
        public virtual ItemCategory3 ItemCategory3 { get; set; }
    }
}