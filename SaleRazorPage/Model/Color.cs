
namespace SaleRazorPage.Model
{
    public class Color : EntityBase<Guid>
    {
        public string Code { get; set; }
        public string? Name { get; set; }
        public string? NameUnAccent { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public List<SubTypeHair>? SubTypeHairs { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
