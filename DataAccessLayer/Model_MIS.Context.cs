﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using global::System;
    using global::System.Data.Entity;
    using global::System.Data.Entity.Infrastructure;
    
    public partial class JEDMISDBEntities : DbContext
    {
        public JEDMISDBEntities()
            : base("name=JEDMISDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dic> Dic { get; set; }
        public virtual DbSet<InvTransTypes> InvTransTypes { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<ItemSerials> ItemSerials { get; set; }
        public virtual DbSet<ItemsGroups> ItemsGroups { get; set; }
        public virtual DbSet<ItemsInOutH> ItemsInOutH { get; set; }
        public virtual DbSet<ItemsInOutL> ItemsInOutL { get; set; }
        public virtual DbSet<Objects> Objects { get; set; }
        public virtual DbSet<ObjectsDtl> ObjectsDtl { get; set; }
        public virtual DbSet<System> System { get; set; }
        public virtual DbSet<UserRights> UserRights { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<MIS_LOG> MIS_LOG { get; set; }
    }
}
