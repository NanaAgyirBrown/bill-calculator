using BillPayment.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace BillPayment.Data.Validations
{
    public class CartValidation : AbstractValidator<Cart>
    {
        private readonly ILogger<CartValidation> _logger;
        BindingList<string> errors = new BindingList<string>();

        public CartValidation(ILogger<CartValidation> logger)
        {
            _logger = logger;

            RuleFor(cart => cart.User)
                .NotEmpty().WithMessage("{PropertyName} can not be empty or null.")
                .NotNull().WithMessage("{PropertyName} can not be empty or null.");

            RuleFor(cart => cart.CartItem)
                .NotEmpty().WithMessage("{PropertyName} can not be null or empty.")
                .NotNull().WithMessage("{PropertyName} can not be null or empty.");
        }

        public BindingList<string> validateObject(Cart cart)
        {
            var validationResult = Validate(cart);

            if (!validationResult.IsValid)
            {
                _logger.Log(LogLevel.Information, "Cart object is invalid. Cart not created.");

                foreach (var item in validationResult.Errors)
                {
                    errors.Add($"{ item.PropertyName } : { item.ErrorMessage}");
                }

                return errors;
            }

            _logger.Log(LogLevel.Information, "Cart object is valid. Calling Entity to create biller");

            return errors;
        }
    }
}