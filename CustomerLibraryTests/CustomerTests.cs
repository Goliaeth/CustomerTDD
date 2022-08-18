using Bogus;
using Customer;
using FluentValidation.TestHelper;

namespace CustomerTests
{
    public class CustomerTests
    {
        private readonly CustomerValidator _validator = new CustomerValidator();
        private readonly Faker _faker = new Faker();

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Customer.Customer customer = new Customer.Customer();
        }

        [Fact]
        public void ShouldBeAbleToValidate()
        {
            Customer.Customer customer = new Customer.Customer();
            var validationResult = _validator.TestValidate(customer);
        }

        [Fact]
        public void FirstNameLengthMustBeLess50()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.FirstName = _faker.Random.String(51);
            var validationResult = _validator.TestValidate(customer);
            validationResult.ShouldHaveValidationErrorFor(c => c.FirstName);
        }

        [Fact]
        public void LastNameLengthMustBeLess50()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.LastName = _faker.Random.String(51);
            var validationResult = _validator.TestValidate(customer);
            validationResult.ShouldHaveValidationErrorFor(c => c.LastName);
        }

        [Fact]
        public void AddressesCanNotBeEmpty()
        {
            Customer.Customer customer = new Customer.Customer();
            var validationResult = _validator.TestValidate(customer);
            validationResult.ShouldHaveValidationErrorFor(c => c.Addresses);
        }

        [Fact]
        public void NotesCanNotBeEmpty()
        {
            Customer.Customer customer = new Customer.Customer();
            var validationResult = _validator.TestValidate(customer);
            validationResult.ShouldHaveValidationErrorFor(c => c.Notes);
        }

        [Fact]
        public void EmailShoulAcceptOnlyValidFormat()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.Email = "dsfa";
            var validationResult = _validator.TestValidate(customer);
            validationResult.ShouldHaveValidationErrorFor(c => c.Email);
        }

        [Fact]
        public void PhoneNumberLengthMustBeLess15()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.PhoneNumber = _faker.Random.String(102);
            var validationResult = _validator.TestValidate(customer);
            validationResult.ShouldHaveValidationErrorFor(c => c.PhoneNumber);
        }

        [Fact]
        public void TotalPurchasesAmountNotNullAndPositive()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.TotalPurchasesAmount = -1;
            var validationResult = _validator.TestValidate(customer);
            validationResult.ShouldHaveValidationErrorFor(c => c.TotalPurchasesAmount);
        }

    }
}
