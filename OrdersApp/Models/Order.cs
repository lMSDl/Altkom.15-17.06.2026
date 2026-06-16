namespace OrdersApp.Models
{
    public class Order
    {
        public DateTime DateTime { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
