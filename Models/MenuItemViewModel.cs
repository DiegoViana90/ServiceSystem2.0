using ServiceSystem2.Models.Enum;

namespace ServiceSystem2.Models
{
    public class MenuItemViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public OrderItemType OrderItemType { get; set; }
    }
}
