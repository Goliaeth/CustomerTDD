using Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Customer
{
    public enum Types { Shipping, Billing }

    public class Address
    {
        public string AddressLine { get; set; } = String.Empty;
        public string? AddressLine2 { get; set; } = String.Empty;
        public virtual AddressTypes AddressType { get; set; } = AddressTypes.Unknown;
        public string City { get; set; } = String.Empty;

        public string PostalCode { get; set; } = String.Empty;

        public string State { get; set; } = String.Empty;

        public string Country { get; set; } = String.Empty;

    }
}
