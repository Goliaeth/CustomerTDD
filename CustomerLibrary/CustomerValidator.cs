using Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customer
{
    public class CustomerValidator
    {
        private const int FirstNameMaxLength = 50;
        private const int LastNameMaxLength = 50;
        private const int AddressesMinCount = 1;
        private const int NotesMinCount = 1;
        private const int PhoneNumberMaxLength = 15;
        private static readonly Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public static List<string> Validate(Customer customer)
        {
            var errors = new List<string>();

            if (customer.FirstName?.Length > FirstNameMaxLength)
            {
                errors.Add("FirstName must be less then 50 chars");
            }
            if (customer.LastName.ValidateNullAndMaxLength(LastNameMaxLength))
            {
                errors.Add("LastName must be less then 50 chars");
            }
            if (customer.Addresses.Count < AddressesMinCount)
            {
                errors.Add("Addresses length must be at least 1");
            }
            if (customer.PhoneNumber != null)
            {
                bool isValid = !(customer.PhoneNumber.Length > PhoneNumberMaxLength);

                foreach (var ch in customer.PhoneNumber)
                {
                    if (ch < '0' || ch > '9')
                    {
                        isValid = false;
                    }
                }

                if (!isValid)
                    errors.Add("Invalid customer property: PhoneNumber");
            }
            if (customer.Email != null && !EmailRegex.IsMatch(customer.Email))
            {
                errors.Add("Invalid customer property: Email");
            }
            if (customer.Notes.Count < NotesMinCount)
            {
                errors.Add("Notes length must be at least 1");
            }
            if (customer.TotalPurchasesAmount != null && customer.TotalPurchasesAmount < 0)
            {
                errors.Add("Invalid customer property: TotalPurchasesAmount");
            }


            return errors;
        }
    }
}
