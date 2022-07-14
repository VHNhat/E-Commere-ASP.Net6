namespace E_Commerce.Models
{
    public class Account : AbstractModel
    {
        private string username;
        private string password;
        private string email;

        private long? roleId;
        private Role role;

        private long? userId;
        private User user;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public long? RoleId { get => roleId; set => roleId = value; }
        public Role Role { get => role; set => role = value; }
        public long? UserId { get => userId; set => userId = value; }
        public User User { get => user; set => user = value; }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
