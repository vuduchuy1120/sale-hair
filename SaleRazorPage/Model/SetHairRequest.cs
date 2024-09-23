using SaleRazorPage.Model;

namespace SaleRazorPage.Model
{
    public class SetHairRequest : EntityBase<Guid>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
        public Category? Category { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
