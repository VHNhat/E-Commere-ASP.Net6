namespace E_Commerce.Models
{
    public class Option_Role
    {
        private Guid optionId;
        private Guid roleId;
        private DateTime createdAt;
        private DateTime lastModifiedAt;

        private OptionRole option;
        private Role role;

        public Guid OptionId { get => optionId; set => optionId = value; }
        public Guid RoleId { get => roleId; set => roleId = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime LastModifiedAt { get => lastModifiedAt; set => lastModifiedAt = value; }
        public OptionRole Option { get => option; set => option = value; }
        public Role Role { get => role; set => role = value; }
    }
}
