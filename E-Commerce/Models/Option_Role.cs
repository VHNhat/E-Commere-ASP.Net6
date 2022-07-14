namespace E_Commerce.Models
{
    public class Option_Role
    {
        private long optionId;
        private long roleId;
        private DateTime createdAt;
        private DateTime lastModifiedAt;

        private OptionRole option;
        private Role role;

        public long OptionId { get => optionId; set => optionId = value; }
        public long RoleId { get => roleId; set => roleId = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime LastModifiedAt { get => lastModifiedAt; set => lastModifiedAt = value; }
        public OptionRole Option { get => option; set => option = value; }
        public Role Role { get => role; set => role = value; }
    }
}
