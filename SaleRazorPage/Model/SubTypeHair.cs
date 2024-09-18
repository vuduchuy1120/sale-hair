
namespace SaleRazorPage.Model
{
    public class SubTypeHair : EntityBase<Guid>
    {
        public Guid TypeHairId { get; set; }
        public string Name { get; set; }
        public string? NameUnAccent { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public TypeHair TypeHair { get; set; }
        public List<SubTypeColor>? SubTypeColors { get; set; }
    }
}
