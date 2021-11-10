using BillPayment.Domain.Models;

namespace BillPayment.Interfaces.Repository
{
    public interface IBillerRepository
    {
        public IQueryable<UserTypes> GetUserTypes { get; }
        public IQueryable<DiscountRule> GetDiscountRules { get; }
        public IQueryable<Bill> GetBill { get; }
        public IQueryable<User> GetUsers { get; }
        public IQueryable<Items> GetItems { get; }
        public IQueryable<DiscountsType> GetDiscountsTypes { get; }
        public IQueryable<ItemsCategory> GetItemsCategories { get; }
        public IQueryable<RulesApplies> GetRulesApplication { get; }

        EntityType Add<EntityType>(EntityType entity);
        EntityType Update<EntityType>(EntityType entity);
        EntityType Delete<EntityType>(EntityType entity);
        int SaveChanges();
    }
}
