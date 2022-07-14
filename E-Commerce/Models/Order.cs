namespace E_Commerce.Models
{
    public class Order : AbstractModel
    {
        private long? customerId;
        private int validated;
        private string status;
        
        private string address;
        private string name;
        private string phone;
        private string time;
        private string payBy;
        private string note;
        
        private long totalPrice;
        private Customer customer;

        public long? CustomerId { get => customerId; set => customerId = value; }
        public int Validated { get => validated; set => validated = value; }
        public string Status { get => status; set => status = value; }
        public string Address { get => address; set => address = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Time { get => time; set => time = value; }
        public string PayBy { get => payBy; set => payBy = value; }
        public string Note { get => note; set => note = value; }
        public long TotalPrice { get => totalPrice; set => totalPrice = value; }
        public Customer Customer { get => customer; set => customer = value; }
    }
}
