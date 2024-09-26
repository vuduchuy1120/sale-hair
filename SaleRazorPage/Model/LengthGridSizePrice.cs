namespace SaleRazorPage.Model
{
    public class LengthGridSizePrice
    {
        public Guid LengthId { get; set; }
        public Guid GridSizeId { get; set; }
        public decimal Price { get; set; }
        public bool IsWholeSale { get; set; } = false;
        public Length? Length { get; set; } = default!;
        public GridSize? GridSize { get; set; } = default!;
    }
}
