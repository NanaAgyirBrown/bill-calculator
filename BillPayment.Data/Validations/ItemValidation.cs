using BillPayment.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Data.Validations
{ 
    public class ItemValidation : AbstractValidator<Items>
    {
        private readonly ILogger<ItemValidation> _logger;
        BindingList<string> errors = new BindingList<string>();

        public ItemValidation(ILogger<ItemValidation> logger)
        {
            _logger = logger;

            RuleFor(item => item.ItemName)
                .NotEmpty().WithMessage("{PropertyName} can not be empty or null.")
                .NotNull().WithMessage("{PropertyName} can not be empty or null.")
                .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.").WithName("Item Name");

            RuleFor(item => item.CategoryId)
                .NotNull().NotEmpty().WithMessage("Invalid Item Category type. Please select from the Category list.");

            RuleFor(asset => asset.UnitPrice)
                .NotEmpty().WithMessage("{PropertyName} can not be null or empty.")
                .NotNull().WithMessage("{PropertyName} can not be null or empty.")
                .GreaterThan(1).WithMessage("Unit Price can not be less than 1.00").WithName("Unit Price");
        }

        public BindingList<string> validateObject(Items item)
        {
            var validationResult = Validate(item);

            if (!validationResult.IsValid)
            {
                _logger.Log(LogLevel.Information, "Asset object is invalid. Asset not created.");

                foreach (var valResult in validationResult.Errors)
                {
                    errors.Add($"{ valResult.PropertyName } : { valResult.ErrorMessage}");
                }

                return errors;
            }

            _logger.Log(LogLevel.Information, "Asset object is valid. Calling Entity to create asset");

            return errors;
        }
    }
}
