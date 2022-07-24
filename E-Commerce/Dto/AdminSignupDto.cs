namespace E_Commerce.Dto
{
    public class AdminSignupDto
    {
        private string username;
        private string password;
        private string email;
        private long roleId;
        private long userId;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public long RoleId { get => roleId; set => roleId = value; }
        public long UserId { get => userId; set => userId = value; }
    }
}
