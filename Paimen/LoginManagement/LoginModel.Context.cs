﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginManagement
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PaimenEntities : DbContext
    {
        public PaimenEntities()
            : base("name=PaimenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}