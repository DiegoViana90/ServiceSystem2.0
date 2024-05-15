using ServiceSystem2.Models.Enum;

namespace ServiceSystem2.Models.Request
{
    public class UpdateMenuItemRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public OrderItemType OrderItemType { get; set; }
    }
}