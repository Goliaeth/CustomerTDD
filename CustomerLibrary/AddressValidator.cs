using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer
{
    public class AddressValidator: AbstractValidator<Address>
    {
        private const int AddressMaxLength = 100;
        private const int CityMaxLength = 50;
        private static readonly List<string> AllowedCountries = new() { "United States", "Canada" };
        private const int PostalCodeMaxLength = 6;
        private const int StateMaxLength = 20;

        public AddressValidator()
        {
            RuleFor(address => address.AddressLine).NotNull().MaximumLength(AddressMaxLength).WithMessage("AddressLine must be less then 100 chars");
            RuleFor(address => address.AddressLine2).MaximumLength(AddressMaxLength).WithMessage("AddressLine2 must be less then 100 chars");
            RuleFor(address => address.AddressType).NotEqual(AddressTypes.Unknown).WithMessage("Invalid address property: AddressType");
            RuleFor(address => address.City).MaximumLength(CityMaxLength).WithMessage("City must be less then 50 chars");
            RuleFor(address => address.Country).Must(country => AllowedCountries.Contains(country, StringComparer.OrdinalIgnoreCase)).WithMessage("Invalid address property: Country");
            RuleFor(address => address.PostalCode).MaximumLength(PostalCodeMaxLength).WithMessage("PostalCode must be less then 5 chars");
            RuleFor(address => address.State).MaximumLength(StateMaxLength).WithMessage("State must be less then 20 chars");
        }

    }
}
