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
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Items.Any())
            {
                // There are items already stored
                return;
            }

            context.ItemsCategories.AddRange(
                new Models.ItemsCategory
                {
                    Id = 1,
                    Category = "Groceries"
                },
                new Models.ItemsCategory
                {
                    Id = 2,
                    Category = "Electronics"
                }
            );

            context.Items.AddRange(
                new Models.Items
                {
                    Id = 1,
                    Category = Models.ItemCategory.Electronics,
                    ItemName = "Television",
                    UnitPrice = 125.00m
                },
                new Models.Items
                {
                    Id = 2,
                    Category = Models.ItemCategory.Electronics,
                    ItemName = "Laptop",
                    UnitPrice = 1845.00m
                },
                new Models.Items
                {
                    Id = 3,
                    Category = Models.ItemCategory.Groceries,
                    ItemName = "Apples",
                    UnitPrice = 1.50m
                },
                new Models.Items
                {
                    Id = 4,
                    Category = Models.ItemCategory.Groceries,
                    ItemName = "Mangoes",
                    UnitPrice = 1.75m
                },
                new Models.Items
                {
                    Id = 5,
                    Category = Models.ItemCategory.Electronics,
                    ItemName = "Phone",
                    UnitPrice = 85.00m
                },
                new Models.Items
                {
                    Id = 6,
                    Category = Models.ItemCategory.Groceries,
                    ItemName = "Sugar",
                    UnitPrice = 0.75m
                },
                new Models.Items
                {
                    Id = 7,
                    Category = Models.ItemCategory.Groceries,
                    ItemName = "Milk",
                    UnitPrice = 0.92m
                },
                new Models.Items
                {
                    Id = 8,
                    Category = Models.ItemCategory.Electronics,
                    ItemName = "Fan",
                    UnitPrice = 15.50m
                },
                new Models.Items
                {
                    Id = 9,
                    Category = Models.ItemCategory.Groceries,
                    ItemName = "Rice cooker",
                    UnitPrice = 42.00m
                },
                new Models.Items
                {
                    Id = 10,
                    Category = Models.ItemCategory.Electronics,
                    ItemName = "Lamp",
                    UnitPrice = 5.20m
                }
            );

            context.Users.AddRange(
                new Models.User
                {
                    Id = 1,
                    Name = "Kofi Mensah",
                    UserType = Models.UserType.Employee,
                    MembershipDate = DateTime.Parse("4/21/2017"),
                },
                new Models.User
                {
                    Id = 2,
                    Name = "Yaa Mansa",
                    UserType = Models.UserType.Affliate,
                    MembershipDate = DateTime.Parse("10/10/2020"),
                },
                new Models.User
                {
                    Id = 3,
                    Name = "Musa Ishameal",
                    UserType = Models.UserType.Customer,
                    MembershipDate = DateTime.Now,
                },
                new Models.User
                {
                    Id = 4,
                    Name = "Lettu Shangrila",
                    UserType = Models.UserType.Customer,
                    MembershipDate = DateTime.Parse("1/21/2010"),
                }
            );

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


            context.Discounts.AddRange(
                new Models.DiscountRule
                {
                    Id = Guid.NewGuid(),
                    UserType = Models.UserType.Employee,
                    DiscountType = Models.DiscountType.Percentage,
                    DiscountValue = 30.00m,
                    RuleAppliesTo = Models.RuleApplication.Electronics,
                },
                new Models.DiscountRule
                {
                    Id = Guid.NewGuid(),
                    UserType = Models.UserType.Affliate,
                    DiscountType = Models.DiscountType.Percentage,
                    DiscountValue = 10.00m,
                    RuleAppliesTo = Models.RuleApplication.Electronics,
                },
                new Models.DiscountRule
                {
                    Id = Guid.NewGuid(),
                    UserType = Models.UserType.Customer,
                    DiscountType = Models.DiscountType.Percentage,
                    DiscountValue = 5.00m,
                    RuleAppliesTo = Models.RuleApplication.Electronics,
                },
                new Models.DiscountRule
                {
                    Id = Guid.NewGuid(),
                    UserType = Models.UserType.Customer,
                    DiscountType = Models.DiscountType.Cash,
                    DiscountValue = 5.00m,
                    RuleAppliesTo = Models.RuleApplication.All,
                }
            );

            context.RulesAppliesTo.AddRange(
                new Models.RulesApplies
                {
                    Id = 1,
                    ApplyTo = "Groceries"
                },
                new Models.RulesApplies
                {
                    Id = 2,
                    ApplyTo = "Electronics"
                },
                new Models.RulesApplies
                {
                    Id = 3,
                    ApplyTo = "All"
                }
            );

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

        }
    }
}
