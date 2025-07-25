﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinylApp.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public Order(int orderId, int customerId, DateTime orderDate, string status)
        {
            OrderID = orderId;
            CustomerID = customerId;
            OrderDate = orderDate;
            Status = status;
        }

    }
}
