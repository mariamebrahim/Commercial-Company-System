﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Boss_Girls
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BossGirlsCompanyEntities : DbContext
    {
        public BossGirlsCompanyEntities()
            : base("name=BossGirlsCompanyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Buy_Perm_Product> Buy_Perm_Product { get; set; }
        public virtual DbSet<Buy_Permission> Buy_Permission { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product_Store> Product_Store { get; set; }
        public virtual DbSet<Product_Unit> Product_Unit { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply_Perm_Product> Supply_Perm_Product { get; set; }
        public virtual DbSet<Supply_Permission> Supply_Permission { get; set; }
        public virtual DbSet<Store_to_store> Store_to_stores { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
