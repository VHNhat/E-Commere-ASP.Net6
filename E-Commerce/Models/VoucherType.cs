namespace E_Commerce.Models
{
    public class VoucherType : AbstractModel
    {
        private string name;
        private string description;

        private ICollection<Voucher> vouchers;
        private string photo;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public ICollection<Voucher> Vouchers { get => vouchers; set => vouchers = value; }
        public string Photo { get => photo; set => photo = value; }
    }
}
