using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinylApp.vinylApp.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public string OrderName { get; set; }




        public Order(int orderId, string orderName)
        {
            OrderId = orderId;
            OrderName = orderName;
        }
    }
}
