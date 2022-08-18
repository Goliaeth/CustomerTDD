using Bogus;
using Customer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerTests
{
    public class AddressTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Address address = new Address();
        }

        [Fact]
        public void ShouldBeAbleToValidate()
        {
            Address address = new Address();
            var result = AddressValidator.Validate(address);
        }

        [Fact]
        public void AddressLineLengthMustBeLess100()
        {
            Address address = new Address();
            address.AddressLine = (new Faker()).Random.String(102);
            var validationResult = AddressValidator.Validate(address);
            CollectionAssert.Contains(validationResult, "AddressLine must be less then 100 chars");
        }

        [Fact]
        public void AddressLine2LengthMustBeLess100()
        {
            Address address = new Address();
            address.AddressLine2 = (new Faker()).Random.String(102);
            var validationResult = AddressValidator.Validate(address);
            CollectionAssert.Contains(validationResult, "AddressLine2 must be less then 100 chars");
        }

        [Fact]
        public void AddressTypeShouldNotBeUnknown()
        {
            Address address = new Address();
            address.AddressType = AddressTypes.Unknown;
            var validationResult = AddressValidator.Validate(address);
            CollectionAssert.Contains(validationResult, "Invalid address property: AddressType");
        }

        [Fact]
        public void CityLengthMustBeLess50()
        {
            Address address = new Address();
            address.City = (new Faker()).Random.String(102);
            var validationResult = AddressValidator.Validate(address);
            CollectionAssert.Contains(validationResult, "City must be less then 50 chars");
        }

        [Fact]
        public void CountryShouldAcceptOnly()
        {
            Address address = new Address();
            address.Country = "Israel";
            var validationResult = AddressValidator.Validate(address);
            CollectionAssert.Contains(validationResult, "Invalid address property: Country");
        }

        [Fact]
        public void PostalCodeLengthMustBeLess5()
        {
            Address address = new Address();
            address.PostalCode = (new Faker()).Random.String(102);
            var validationResult = AddressValidator.Validate(address);
            CollectionAssert.Contains(validationResult, "PostalCode must be less then 5 chars");
        }

        [Fact]
        public void StateLengthMustBeLess20()
        {
            Address address = new Address();
            address.State = (new Faker()).Random.String(102);
            var validationResult = AddressValidator.Validate(address);
            CollectionAssert.Contains(validationResult, "State must be less then 20 chars");
        }

    }
}
