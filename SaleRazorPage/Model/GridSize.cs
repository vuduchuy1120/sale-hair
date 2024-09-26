namespace SaleRazorPage.Model
{
    public class GridSize :EntityBase<Guid>
    {
        public string Size { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public List<LengthGridSizePrice>? LengthGridSizePrices { get; set; }
    }
}
