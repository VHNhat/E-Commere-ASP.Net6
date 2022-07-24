namespace E_Commerce.Models
{
    public class Order : AbstractModel
    {
        private double subTotal;
        private double shippingCost;
        private string paymentMethod;
        private string paymentStatus;
        private string status;
        private double total;

        private long? customerId;
        private Customer customer;
        private long? voucherId;
        private Voucher voucher;
        private long? receiverId;
        private Receiver receiver;

        public double SubTotal { get => subTotal; set => subTotal = value; }
        public double ShippingCost { get => shippingCost; set => shippingCost = value; }
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
        public string PaymentStatus { get => paymentStatus; set => paymentStatus = value; }
        public string Status { get => status; set => status = value; }
        public double Total { get => total; set => total = value; }
        public long? CustomerId { get => customerId; set => customerId = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public long? VoucherId { get => voucherId; set => voucherId = value; }
        public Voucher Voucher { get => voucher; set => voucher = value; }
        public long? ReceiverId { get => receiverId; set => receiverId = value; }
        public Receiver Receiver { get => receiver; set => receiver = value; }
    }
}
