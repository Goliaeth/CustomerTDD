using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public static class StringExtensions
    {
        public static bool ValidateNullAndMaxLength(this string str, int maxLength)
        {
            return string.IsNullOrWhiteSpace(str) || str.Length > maxLength;
        }
    }
}
