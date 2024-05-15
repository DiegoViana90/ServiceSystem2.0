using System.Collections.Generic;
using ServiceSystem2.Models.Enum;

namespace ServiceSystem2.Models.Request
{
    public class CreateOrderRequest
    {
        public int TableNumber { get; set; }
        public List<OrderItemRequest> OrderItems { get; set; }
    }

    public class OrderItemRequest
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
