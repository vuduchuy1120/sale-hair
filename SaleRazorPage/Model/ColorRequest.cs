using SaleRazorPage.Model;

namespace SaleRazorPage.Model
{
    public class ColorRequest : EntityBase<Guid>
    {
        public Guid SetHairRequestId { get; set; }
        public string Code { get; set; }
        public string? Name { get; set; }
        public string? NameUnAccent { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public SetHairRequest SetHairRequest { get; set; }
    }
}
