namespace E_Commerce.Models
{
    public class VoucherType : AbstractModel
    {
        private string name;
        private string type;
        private string status;

        private ICollection<Voucher> vouchers;

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public ICollection<Voucher> Vouchers { get => vouchers; set => vouchers = value; }
        public string Status { get => status; set => status = value; }
    }
}
