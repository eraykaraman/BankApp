﻿using BankApp.Web.Data.Configurations;
using BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using BankApp.Web.Models;

namespace BankApp.Web.Data.Context
{
    public class BankContext: DbContext
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<Account> Accounts { get; set; }
        public BankContext(DbContextOptions<BankContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new  AccountConfiguration());
            
        }

        public DbSet<BankApp.Web.Models.UserCreateModel>? UserCreateModel { get; set; }
    }
}
