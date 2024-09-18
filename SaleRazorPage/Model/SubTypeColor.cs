namespace SaleRazorPage.Model
{
    public class SubTypeColor
    {
        public Guid SubTypeHairId { get; set; }
        public Guid ColorId { get; set; }
        public SubTypeHair SubTypeHair { get; set; }
        public Color Color { get; set; }
    }
}
