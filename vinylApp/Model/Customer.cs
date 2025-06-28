using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinylApp.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; } //test




        public Customer(int customerId, string firstName, string lastName)
        {
            CustomerId = customerId;
           FirstName = firstName;
            LastName = lastName;
        }
    }
}