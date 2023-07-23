using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Atown10
{
    public class Customer : BaseClass
    {
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }

    }
}
