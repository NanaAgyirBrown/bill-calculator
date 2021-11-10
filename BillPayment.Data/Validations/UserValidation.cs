

using BillPayment.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace BillPayment.Data.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        private readonly ILogger<UserValidation> _logger;
        BindingList<string> errors = new BindingList<string>();

        public UserValidation(ILogger<UserValidation> logger)
        {
            _logger = logger;

            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("{PropertyName} can not be empty or null.")
                .NotNull().WithMessage("{PropertyName} can not be empty or null.")
                .MinimumLength(5).WithMessage("{PropertyName} must be at least 3 characters long.").WithName("User Name");

            RuleFor(user => user.UserType)
                .IsInEnum().WithMessage("Invalid User Type name. Please select from the User Type list.");

            RuleFor(user => user.MembershipDate)
                .NotEmpty().WithMessage("{PropertyName} can not be null or empty.")
                .NotNull().WithMessage("{PropertyName} can not be null or empty.")
                .Must(BeValidDate).WithMessage("Membership date can not be newer than a today").WithName("Membership date");
        }


        protected bool BeValidDate(DateTime membershipDate)
        {
            _logger.Log(LogLevel.Information, "Validating Membership date.");
            return (DateTime.Now.Subtract(membershipDate).Days <= 365 && membershipDate.Year <= DateTime.Now.Year) ? true : false;
        }


        public BindingList<string> validateObject(User user)
        {
            var validationResult = Validate(user);

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
