namespace SaleRazorPage.Model
{
    public class Length : EntityBase<Guid>
    {
        public string Inch { get; set; }
        public string? Size { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public List<LengthGridSizePrice>? LengthGridSizePrices { get; set; }
        public List<LengThicknessPrice>? LengThicknessPrices { get; set; }
    }
}
