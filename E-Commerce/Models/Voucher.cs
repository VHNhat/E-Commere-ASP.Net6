namespace E_Commerce.Models
{
    public class Voucher : AbstractModel
    {
        private string code;
        private string name;
        private int quantity;
        private DateTime expiredAt;
        private double value;
        private string photo;
        private VoucherType type;
        private long? typeId;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime ExpiredAt { get => expiredAt; set => expiredAt = value; }
        public double Value { get => value; set => this.value = value; }
        public string Photo { get => photo; set => photo = value; }
        public VoucherType Type { get => type; set => type = value; }
        public long? TypeId { get => typeId; set => typeId = value; }
    }
}
