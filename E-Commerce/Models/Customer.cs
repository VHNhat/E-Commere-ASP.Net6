namespace E_Commerce.Models
{
    public class Customer : AbstractModel
    {
        private string username;
        private string password;
        private string email;
        private string phone;
        private string fullName;
        private string avatar;
        private string address;
        private string city;
        private string country;
        private string role = "Customer";
        private int? gender;

        private ICollection<Cart> carts;
        private ICollection<Order> orders;
        private ICollection<Receiver> receivers;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public string Role { get => role; set => role = value; }
        public int? Gender { get => gender; set => gender = value; }
        public ICollection<Cart> Carts { get => carts; set => carts = value; }
        public ICollection<Order> Orders { get => orders; set => orders = value; }
        public ICollection<Receiver> Receivers { get => receivers; set => receivers = value; }
    }
}
