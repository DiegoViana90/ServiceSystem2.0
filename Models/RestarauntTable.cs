    public class RestaurantTable
    {
        public int RestaurantTableId { get; set; }
        public int TableNumber { get; set; }
        public bool InService { get; set; }
        public Order Order { get; set; }
    }