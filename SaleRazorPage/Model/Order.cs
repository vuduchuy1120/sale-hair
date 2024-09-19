namespace SaleRazorPage.Model
{
    public class Order : EntityBase<Guid>
    {
        public Guid CustomerId { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public int Status { get; set; }
        public decimal TotalPrice { get; set; }
        public double Quantity { get; set; }
        public Customer Customer { get; set; }
    }
}
