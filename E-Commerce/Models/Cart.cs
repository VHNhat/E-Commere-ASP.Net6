namespace E_Commerce.Models
{
    public class Cart : AbstractModel 
    {
        private int quantity;
        private double amount;
        
        private long? customerId;
        private Customer customer;

        private ICollection<CartProduct> cartDetails;

        public int Quantity { get => quantity; set => quantity = value; }
        public double Amount { get => amount; set => amount = value; }
        public long? CustomerId { get => customerId; set => customerId = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public ICollection<CartProduct> CartDetails { get => cartDetails; set => cartDetails = value; }
    }
}
