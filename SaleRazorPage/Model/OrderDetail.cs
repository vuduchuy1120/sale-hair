namespace SaleRazorPage.Model
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid? ThorneId { get; set; }
        public Guid? LengthId { get; set; }
        public Guid? ThicknessId { get; set; }
        public Guid? GridSizeId { get; set; }
        public Guid? SetHairRequestId { get; set; }
        public Guid? GridColorId { get; set; }
        public string SubTypeName { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ColorId { get; set; }
        public Guid TypeHairId { get; set; }
        public double? Quantity { get; set; }
        public bool? IsBorder { get; set; }
        public decimal? Price { get; set; }
        public Order Order { get; set; }
        public Thorne? Thorne { get; set; }
        public Length? Length { get; set; }
        public Thickness? Thickness { get; set; }
        public GridSize? GridSize { get; set; }
        public SetHairRequest? SetHairRequest { get; set; }
        public GridColor? GridColor { get; set; }
        public SubTypeHair? SubTypeHair { get; set; }
        public Category? Category { get; set; }
        public Color? Color { get; set; }
        public TypeHair? TypeHair { get; set; }
    }
}
