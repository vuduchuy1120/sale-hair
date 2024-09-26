namespace SaleRazorPage.Model
{
    public class LengThicknessPrice
    {
        public Guid LengthId { get; set; }
        public Guid ThicknessId { get; set; }
        public decimal Price { get; set; }
        public bool IsWholeSale { get; set; } = false;
        public Length? Length { get; set; } = default!;
        public Thickness? Thickness { get; set; } = default!;
    }
}
