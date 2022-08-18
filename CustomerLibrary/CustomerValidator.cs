using FluentValidation;

namespace Customer
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private const int FirstNameMaxLength = 50;
        private const int LastNameMaxLength = 50;
        private const int PhoneNumberMaxLength = 15;

        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).MaximumLength(FirstNameMaxLength).WithMessage("FirstName must be less then 50 chars");
            RuleFor(customer => customer.LastName).NotNull().MaximumLength(LastNameMaxLength).WithMessage("LastName must be less then 50 chars");
            RuleFor(customer => customer.Addresses).NotEmpty().WithMessage("Addresses length must be at least 1");
            RuleFor(customer => customer.PhoneNumber).Matches(@"^\d{12,15}$").MaximumLength(PhoneNumberMaxLength).WithMessage("Invalid customer property: PhoneNumber");
            RuleFor(customer => customer.Notes).NotEmpty().WithMessage("Notes length must be at least 1");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Invalid customer property: Email");
            RuleFor(customer => customer.TotalPurchasesAmount).GreaterThanOrEqualTo(0).WithMessage("Invalid customer property: TotalPurchasesAmount");
        }

    }
}
