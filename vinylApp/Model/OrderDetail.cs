using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinylApp.Model
{
    public class OrderDetail
    {
        public int OrderDetailID { get; }
        public int OrderID { get; }
        public int RecordID { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public OrderDetail(int detailId, int orderId, int recordId, int quantity, decimal price)
        {
            OrderDetailID = detailId;
            OrderID = orderId;
            RecordID = recordId;
            Quantity = quantity;
            Price = price;
        }
    }
}