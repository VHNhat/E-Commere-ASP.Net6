namespace E_Commerce.Models
{
    public class Receiver : AbstractModel
    {
        private string name;
        private string email;
        private string phone;
        private string address;
        private string number;
        private string street;
        private string ward;
        private string district;
        private string city;
        private string country;

        private long? customerId;
        private Customer customer;

        private ICollection<Order> orders;
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Number { get => number; set => number = value; }
        public string Street { get => street; set => street = value; }
        public string Ward { get => ward; set => ward = value; }
        public string District { get => district; set => district = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public long? CustomerId { get => customerId; set => customerId = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public ICollection<Order> Orders { get => orders; set => orders = value; }
    }
}