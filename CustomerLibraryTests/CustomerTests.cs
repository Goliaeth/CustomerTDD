using Bogus;
using Customer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerTests
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Customer.Customer customer = new Customer.Customer();
        }

        [Fact]
        public void ShouldBeAbleToValidate()
        {
            Customer.Customer customer = new Customer.Customer();
            var validationResult = CustomerValidator.Validate(customer);

        }

        [Fact]
        public void FirstNameLengthMustBeLess50()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.FirstName = (new Faker()).Random.String(102);
            var validationResult = CustomerValidator.Validate(customer);
            CollectionAssert.Contains(validationResult, "FirstName must be less then 50 chars");
        }

        [Fact]
        public void LastNameLengthMustBeLess50()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.LastName = (new Faker()).Random.String(102);
            var validationResult = CustomerValidator.Validate(customer);
            CollectionAssert.Contains(validationResult, "LastName must be less then 50 chars");
        }

        [Fact]
        public void AddressesCanNotBeEmpty()
        {
            Customer.Customer customer = new Customer.Customer();
            var validationResult = CustomerValidator.Validate(customer);
            CollectionAssert.Contains(validationResult, "Addresses length must be at least 1");
        }

        [Fact]
        public void NotesCanNotBeEmpty()
        {
            Customer.Customer customer = new Customer.Customer();
            var validationResult = CustomerValidator.Validate(customer);
            CollectionAssert.Contains(validationResult, "Notes length must be at least 1");
        }

        [Fact]
        public void EmailShoulAcceptOnlyValidFormat()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.Email = "dsfa";
            var validationResult = CustomerValidator.Validate(customer);
            CollectionAssert.Contains(validationResult, "Invalid customer property: Email");
        }

        [Fact]
        public void PhoneNumberLengthMustBeLess15()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.PhoneNumber = (new Faker()).Random.String(102);
            var validationResult = CustomerValidator.Validate(customer);
            CollectionAssert.Contains(validationResult, "Invalid customer property: PhoneNumber");
        }

        [Fact]
        public void TotalPurchasesAmountNotNullAndPositive()
        {
            Customer.Customer customer = new Customer.Customer();
            customer.TotalPurchasesAmount = -1;
            var validationResult = CustomerValidator.Validate(customer);
            CollectionAssert.Contains(validationResult, "Invalid customer property: TotalPurchasesAmount");
        }
        
    }
}
