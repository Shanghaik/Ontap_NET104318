namespace Ontap_NET104.Models
{
    public class BillDetails // Mỗi bill details chứa thông tin của 1 sp trong bill
    {
        public Guid Id { get; set; }
        public string BillId { get; set; }
        public Guid ProductId { get; set; }
        public decimal ProductPrice { get; set; } // Giá tại thời điểm mua
        public int Quantity { get; set; }
        public int Status { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
