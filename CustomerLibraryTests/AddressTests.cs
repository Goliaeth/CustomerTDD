using Bogus;
using Customer;
using FluentValidation.TestHelper;

namespace CustomerTests
{
    public class AddressTests
    {
        private readonly AddressValidator _validator = new AddressValidator();
        private readonly Faker _faker = new Faker();

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Address address = new Address();
        }

        [Fact]
        public void ShouldBeAbleToValidate()
        {
            Address address = new Address();
            var validationResult = _validator.TestValidate(address);
        }

        [Fact]
        public void AddressLineLengthMustBeLess100()
        {
            Address address = new Address();
            address.AddressLine = _faker.Random.String(102);
            var validationResult = _validator.TestValidate(address);
            validationResult.ShouldHaveValidationErrorFor(a => a.AddressLine);
        }

        [Fact]
        public void AddressLine2LengthMustBeLess100()
        {
            Address address = new Address();
            address.AddressLine2 = _faker.Random.String(102);
            var validationResult = _validator.TestValidate(address);
            validationResult.ShouldHaveValidationErrorFor(a => a.AddressLine2);
        }

        [Fact]
        public void AddressTypeShouldNotBeUnknown()
        {
            Address address = new Address();
            address.AddressType = AddressTypes.Unknown;
            var validationResult = _validator.TestValidate(address);
            validationResult.ShouldHaveValidationErrorFor(a => a.AddressType);
        }

        [Fact]
        public void CityLengthMustBeLess50()
        {
            Address address = new Address();
            address.City = _faker.Random.String(102);
            var validationResult = _validator.TestValidate(address);
            validationResult.ShouldHaveValidationErrorFor(a => a.City);
        }

        [Fact]
        public void CountryShouldAcceptOnly()
        {
            Address address = new Address();
            address.Country = "Israel";
            var validationResult = _validator.TestValidate(address);
            validationResult.ShouldHaveValidationErrorFor(a => a.Country);
        }

        [Fact]
        public void PostalCodeLengthMustBeLess5()
        {
            Address address = new Address();
            address.PostalCode = _faker.Random.String(102);
            var validationResult = _validator.TestValidate(address);
            validationResult.ShouldHaveValidationErrorFor(a => a.PostalCode);
        }

        [Fact]
        public void StateLengthMustBeLess20()
        {
            Address address = new Address();
            address.State = _faker.Random.String(102);
            var validationResult = _validator.TestValidate(address);
            validationResult.ShouldHaveValidationErrorFor(a => a.State);
        }

    }
}
