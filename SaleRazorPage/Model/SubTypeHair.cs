
namespace SaleRazorPage.Model
{
    public class SubTypeHair 
    {
        public Guid TypeHairId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ColorId { get; set; }        
        public string SubTypeName { get; set; }
        public string? SubTypeNameUnAccent { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public TypeHair? TypeHair { get; set; }
        public Category? Category { get; set; }
        public Color? Color { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
