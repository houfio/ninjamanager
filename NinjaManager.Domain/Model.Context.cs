﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NinjaManager.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NinjaManagerEntities : DbContext
    {
        public NinjaManagerEntities()
            : base("name=NinjaManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Ninja> Ninjas { get; set; }
    }
}
