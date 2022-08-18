using Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class AddressValidator
    {
        private const int AddressMaxLength = 100;
        private const int CityMaxLength = 50;
        private static readonly List<string> AllowedCountries = new() { "United States", "Canada" };
        private const int PostalCodeMaxLength = 6;
        private const int StateMaxLength = 20;

        public static List<string> Validate(Address address)
        {
            var errors = new List<string>();

            if (address.AddressLine.ValidateNullAndMaxLength(AddressMaxLength))
            {
                errors.Add("AddressLine must be less then 100 chars");
            }
            if (address.AddressLine2.Length > AddressMaxLength)
            {
                errors.Add("AddressLine2 must be less then 100 chars");
            }
            if (address.AddressType == AddressTypes.Unknown)
            {
                errors.Add("Invalid address property: AddressType");
            }
            if (address.City.ValidateNullAndMaxLength(CityMaxLength))
            {
                errors.Add("City must be less then 50 chars");
            }
            if (!AllowedCountries.Contains(address.Country, StringComparer.OrdinalIgnoreCase))
            {
                errors.Add("Invalid address property: Country");
            }
            if (address.PostalCode.ValidateNullAndMaxLength(PostalCodeMaxLength))
            {
                errors.Add("PostalCode must be less then 5 chars");
            }
            if (address.State.ValidateNullAndMaxLength(StateMaxLength))
            {
                errors.Add("State must be less then 20 chars");
            }

            return errors;
        }
    }
}
