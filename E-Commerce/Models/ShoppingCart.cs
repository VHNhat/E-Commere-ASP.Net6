namespace E_Commerce.Models
{
    public class ShoppingCart : AbstractModel 
    {
        private int id;
        private long? customerId;
        private Customer customer;
        private int productQuantity;

        private ICollection<ShoppingCart_Product> shoppingCart_Products;

        public int Id1 { get => id; set => id = value; }
        public long? CustomerId { get => customerId; set => customerId = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public int ProductQuantity { get => productQuantity; set => productQuantity = value; }
        public ICollection<ShoppingCart_Product> ShoppingCart_Products { get => shoppingCart_Products; set => shoppingCart_Products = value; }
    }
}
