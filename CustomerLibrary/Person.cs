using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public abstract class Person
    {
        public virtual string? FirstName { get; set; }
        public virtual string LastName { get; set; } = String.Empty;

    }
}
