using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Data
{
    public class InitData
    {
        public static void Initialize(BillerContext context)
        {
            context.Database.EnsureCreated();

            if (context.ItemsCategories.Any())
            {
                context.Database.EnsureDeleted();
                // There are items already stored
                return;
            }

            context.ItemsCategories.AddRange(
                new Models.ItemsCategory
                {
                    Id = 1,
                    Category = "Grocery"
                },
                new Models.ItemsCategory
                {
                    Id = 2,
                    Category = "Electronic"
                }
            );

            context.SaveChanges();


            context.UserTypes.AddRange(
                new Models.UserTypes
                {
                    Id = 1,
                    UserType = "Employee"
                },
                new Models.UserTypes
                {
                    Id = 2,
                    UserType = "Affliate"
                },
                new Models.UserTypes
                {
                    Id = 3,
                    UserType = "Customer"
                }
            );
            context.SaveChanges();

            context.RulesAppliesTo.AddRange(
                new Models.RulesApplies
                {
                    Id = 1,
                    ApplyTo = "Grocery"
                },
                new Models.RulesApplies
                {
                    Id = 2,
                    ApplyTo = "Electronic"
                },
                new Models.RulesApplies
                {
                    Id = 3,
                    ApplyTo = "All"
                }
            );

            context.SaveChanges();

            context.DiscountsType.AddRange(
                new Models.DiscountsType
                {
                    Id = 1,
                    Name = "Cash"
                },
                new Models.DiscountsType
                {
                    Id = 2,
                    Name = "Percentage"
                }
            );

            context.SaveChanges();

            context.Items.AddRange(
                new Models.Items
                {
                    Id = 1,
                    CategoryId = 2,
                    ItemName = "Television",
                    UnitPrice = 125.00m
                },
                new Models.Items
                {
                    Id = 2,
                    CategoryId = 2,
                    ItemName = "Laptop",
                    UnitPrice = 1845.00m
                },
                new Models.Items
                {
                    Id = 3,
                    CategoryId = 1,
                    ItemName = "Apples",
                    UnitPrice = 1.50m
                },
                new Models.Items
                {
                    Id = 4,
                    CategoryId = 1,
                    ItemName = "Mangoes",
                    UnitPrice = 1.75m
                },
                new Models.Items
                {
                    Id = 5,
                    CategoryId = 2,
                    ItemName = "Phone",
                    UnitPrice = 85.00m
                },
                new Models.Items
                {
                    Id = 6,
                    CategoryId = 1,
                    ItemName = "Sugar",
                    UnitPrice = 0.75m
                },
                new Models.Items
                {
                    Id = 7,
                    CategoryId = 1,
                    ItemName = "Milk",
                    UnitPrice = 0.92m
                },
                new Models.Items
                {
                    Id = 8,
                    CategoryId = 2,
                    ItemName = "Fan",
                    UnitPrice = 15.50m
                },
                new Models.Items
                {
                    Id = 9,
                    CategoryId = 2,
                    ItemName = "Rice cooker",
                    UnitPrice = 42.00m
                },
                new Models.Items
                {
                    Id = 10,
                    CategoryId = 2,
                    ItemName = "Lamp",
                    UnitPrice = 5.20m
                }
            );

            context.SaveChanges();

            context.Users.AddRange(
                new Models.User
                {
                    Id = 1,
                    Name = "Kofi Mensah",
                    UserTypeID = context.UserTypes.Find(1).Id,
                    MembershipDate = DateTime.Parse("4/21/2017"),
                },
                new Models.User
                {
                    Id = 2,
                    Name = "Yaa Mansa",
                    UserTypeID = context.UserTypes.Find(3).Id,
                    MembershipDate = DateTime.Parse("10/10/2020"),
                },
                new Models.User
                {
                    Id = 3,
                    Name = "Musa Ishameal",
                    UserTypeID = context.UserTypes.Find(2).Id,
                    MembershipDate = DateTime.Now,
                },
                new Models.User
                {
                    Id = 4,
                    Name = "Lettu Shangrila",
                    UserTypeID = context.UserTypes.Find(3).Id,
                    MembershipDate = DateTime.Parse("1/21/2010"),
                }
            );
            context.SaveChanges();

            context.Discounts.AddRange(
                new Models.DiscountRule
                {
                    Id = Guid.NewGuid(),
                    UserTypeId = context.UserTypes.Find(1).Id,
                    DiscountTypeId = context.DiscountsType.Find(2).Id,
                    DiscountValue = 30.00m,
                    RuleAppliesToId = context.RulesAppliesTo.Find(2).Id,
                },
                new Models.DiscountRule
                {
                    Id = Guid.NewGuid(),
                    UserTypeId = context.UserTypes.Find(2).Id,
                    DiscountTypeId = context.DiscountsType.Find(2).Id,
                    DiscountValue = 10.00m,
                    RuleAppliesToId = context.RulesAppliesTo.Find(2).Id,
                },
                new Models.DiscountRule
                {
                    Id = Guid.NewGuid(),
                    UserTypeId = context.UserTypes.Find(3).Id,
                    DiscountTypeId = context.DiscountsType.Find(2).Id,
                    DiscountValue = 5.00m,
                    RuleAppliesToId = context.RulesAppliesTo.Find(2).Id,
                },
                new Models.DiscountRule
                {
                    Id = Guid.NewGuid(),
                    UserTypeId = context.UserTypes.Find(3).Id,
                    DiscountTypeId = context.DiscountsType.Find(1).Id,
                    DiscountValue = 5.00m,
                    RuleAppliesToId = context.RulesAppliesTo.Find(3).Id,
                }
            );

            context.SaveChanges();           

        }
    }
}
