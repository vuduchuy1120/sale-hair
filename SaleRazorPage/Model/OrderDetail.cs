namespace SaleRazorPage.Model
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ThorneId { get; set; }
        public Guid LengthId { get; set; }
        public Guid ThicknessId { get; set; }
        public Guid GridSizeId { get; set; }
        public Guid SetHairRequestId { get; set; }

        public double Quantity { get; set; }
        public bool IsBorder { get; set; }
        
    }
}
