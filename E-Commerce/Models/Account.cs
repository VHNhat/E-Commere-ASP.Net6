namespace E_Commerce.Models
{
    public class Account : AbstractModel
    {
        private string username;
        private string password;
        private string email;

        private Guid roleId;
        private Role role;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public Guid RoleId { get => roleId; set => roleId = value; }
        public Role Role { get => role; set => role = value; }
    }
}
