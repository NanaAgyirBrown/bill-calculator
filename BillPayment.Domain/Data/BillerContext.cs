using BillPayment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BillPayment.Domain.Data
{
    public class BillerContext : DbContext
    {
        public BillerContext(DbContextOptions<BillerContext> options) : base(options) {
            
        }

        public DbSet<UserTypes> UserTypes { get; set; }
        public DbSet<DiscountsType> DiscountsType {  get; set; }
        public DbSet<RulesApplies> RulesAppliesTo { get; set; }
        public DbSet<ItemsCategory> ItemsCategories { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Bill> Bills {  get; set; }
        public virtual DbSet<DiscountRule> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>().ToTable("Bill");
            modelBuilder.Entity<Items>().ToTable("Items");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserTypes>().ToTable("UserTypes");
            modelBuilder.Entity<DiscountRule>().ToTable("DiscountRule");
            modelBuilder.Entity<ItemsCategory>().ToTable("ItemsCategory");
            modelBuilder.Entity<DiscountsType>().ToTable("DiscountsType");
            modelBuilder.Entity<RulesApplies>().ToTable("RulesApplies");
        }

    }
}
