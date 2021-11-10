using BillPayment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BillPayment.Domain.Data
{
    public class BillerContext : DbContext
    {
        public BillerContext(DbContextOptions options) : base(options) { }

        public DbSet<UserTypes> UserTypes { get; set; }
        public DbSet<DiscountsType> DiscountsType {  get; set; }
        public DbSet<RulesApplies> RulesAppliesTo { get; set; }
        public DbSet<ItemsCategory> ItemsCategories { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Bill> Bills {  get; set; }
        public DbSet<DiscountRule> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>();
            modelBuilder.Entity<Purchase>();
            modelBuilder.Entity<Items>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<UserTypes>();
            modelBuilder.Entity<DiscountRule>();
            modelBuilder.Entity<ItemsCategory>();
            modelBuilder.Entity<DiscountsType>();
            modelBuilder.Entity<RulesApplies>();
        }

    }
}
