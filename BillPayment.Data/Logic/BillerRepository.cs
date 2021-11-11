using BillPayment.Domain.Data;
using BillPayment.Domain.Models;
using BillPayment.Interfaces.Repository;

namespace BillPayment.Data.Logic
{
    public class BillerRepository : IBillerRepository
    {
        private readonly BillerContext _db;

        public BillerRepository(BillerContext db)
        {
            _db = db;
        }

        private readonly List<Items> _items = new List<Items>();
        private readonly List<User> _users = new List<User>();

        public IQueryable<Bill> GetBill => _db.Bills;

        public IQueryable<User> GetUsers => _db.Users;

        public IQueryable<Items> GetItems => _db.Items;

        public IEnumerable<UserTypes> GetUserTypes => _db.UserTypes;

        public IQueryable<DiscountRule> GetDiscountRules => _db.Discounts;

        public IQueryable<DiscountsType> GetDiscountsTypes => _db.DiscountsType;

        public IQueryable<ItemsCategory> GetItemsCategories => _db.ItemsCategories;

        public IQueryable<RulesApplies> GetRulesApplication => _db.RulesAppliesTo;

        public EntityType Add<EntityType>(EntityType entity)
        {
            switch (entity)
            {
                case Bill bill:
                    _db.Bills.Add(bill);
                    break;
                case User user:
                    _db.Users.Add(user);
                    break;
                case Items item:
                    _db.Items.Add(item);
                    break;
            }

            return entity;
        }

        public EntityType Delete<EntityType>(EntityType entity)
        {
            _db.Remove(entity);

            return entity;
        }

        public int SaveChanges() => _db.SaveChanges();

        public EntityType Update<EntityType>(EntityType entity)
        {
            _db.Update(entity);

            return entity;
        }
    }
}
