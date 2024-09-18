

namespace SaleRazorPage.Model
{
    public class Category : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string? NameUnAccent { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public List<TypeHair>? TypeHairs { get; set; }
        public List<SetHairRequest>? SetHairsRequest { get; set; }
    }
}
