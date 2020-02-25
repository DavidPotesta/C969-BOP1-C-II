using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_BOP1_Potesta_David_001243829
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int countryId { get; set; }
        public int cityId { get; set; }
        public int addressId { get; set; }
        public int customerId { get; set; }

        public string loggedInUser = Controller.getUserName();


    }
}
