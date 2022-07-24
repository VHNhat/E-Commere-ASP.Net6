using E_Commerce.Utility.Status;

namespace E_Commerce.Models
{
    public class Voucher : AbstractModel
    {
        private string code;
        private string title;
        private string status;
        private string photo;
        private int quantity;
        private double value;
        private DateTime expiredAt;

        private long? typeId;
        private VoucherType type;
        private long? organizerId;
        private Organizer organizer;

        private ICollection<Order> orders;

        public string Code { get => code; set => code = value; }
        public string Title { get => title; set => title = value; }
        public string Status { get => status; set => status = value; }
        public string Photo { get => photo; set => photo = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Value { get => value; set => this.value = value; }
        public DateTime ExpiredAt { get => expiredAt; set => expiredAt = value; }
        public long? TypeId { get => typeId; set => typeId = value; }
        public VoucherType Type { get => type; set => type = value; }
        public long? OrganizerId { get => organizerId; set => organizerId = value; }
        public Organizer Organizer { get => organizer; set => organizer = value; }
        public ICollection<Order> Orders { get => orders; set => orders = value; }
    }
}
