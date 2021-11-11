using BillPayment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillPaymentApi.Test
{
    public class FakeData
    { 
        public IQueryable<User> GetFakeUsers()
        {
            var user = new List<User>();
            user.Add(new User
            {
                Id = 3,
                Name = "Musa Ishameal",
                UserTypeID = 2,
                MembershipDate = DateTime.Now,
            });
            user.Add(new User
            {
                Id = 2,
                Name = "Yaa Mansa",
                UserTypeID = 3,
                MembershipDate = DateTime.Parse("10/10/2020"),
            });
            user.Add(new User
            {
                Id = 1,
                Name = "Kofi Mensah",
                UserTypeID = 1,
                MembershipDate = DateTime.Parse("4/21/2017"),
            });
            user.Add(new User
            {
                Id = 4,
                Name = "Lettu Shangrila",
                UserTypeID = 1,
                MembershipDate = DateTime.Parse("1/21/2010"),
            });
            IQueryable<User> users = user.AsQueryable();

            return users;
        }

        public IQueryable<DiscountRule> GetFakeDiscountRule()
        {
            var rules = new List<DiscountRule>();

            rules.Add(new DiscountRule
            {
                Id = Guid.NewGuid(),
                UserTypeId = 1,
                DiscountTypeId = 2,
                DiscountValue = 30.00m,
                RuleAppliesToId = 2,
            });
            rules.Add(new DiscountRule
            {
                Id = Guid.NewGuid(),
                UserTypeId = 2,
                DiscountTypeId = 2,
                DiscountValue = 10.00m,
                RuleAppliesToId = 2,
            });
            rules.Add(new DiscountRule
            {
                Id = Guid.NewGuid(),
                UserTypeId = 3,
                DiscountTypeId = 2,
                DiscountValue = 5.00m,
                RuleAppliesToId = 2,
            });
            rules.Add(new DiscountRule
            {
                Id = Guid.NewGuid(),
                UserTypeId = 3,
                DiscountTypeId = 1,
                DiscountValue = 5.00m,
                RuleAppliesToId = 3,
            });

            return rules.AsQueryable();
        }

        public IQueryable<Items> GetFakeShopItems()
        {
            var shopItems = new List<Items>();
            shopItems.Add(new Items
            {
                Id = 1,
                CategoryId = 2,
                ItemName = "Television",
                UnitPrice = 125.00m
            });
            shopItems.Add(new Items
            {
                Id = 2,
                CategoryId = 2,
                ItemName = "Laptop",
                UnitPrice = 1845.00m
            });
            shopItems.Add(new Items
            {
                Id = 3,
                CategoryId = 1,
                ItemName = "Apples",
                UnitPrice = 1.50m
            });
            shopItems.Add(new Items
            {
                Id = 4,
                CategoryId = 1,
                ItemName = "Mangoes",
                UnitPrice = 1.75m
            });
            shopItems.Add(new Items
            {
                Id = 5,
                CategoryId = 2,
                ItemName = "Phone",
                UnitPrice = 85.00m
            });

            return shopItems.AsQueryable();
        }
    }
}
