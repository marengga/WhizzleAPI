﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhizzleAPI.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WhizzleEntities : DbContext
    {
        public WhizzleEntities()
            : base("name=WhizzleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<StringMap> StringMaps { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<PinBoard> PinBoards { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserActivity> UserActivities { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }
}