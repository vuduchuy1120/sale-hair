namespace SaleRazorPage.Model
{
    public class Thickness : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string? NameUnAccent { get; set; }
        public string? Size { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public List<CategoryThickness>? CategoryThicknesses { get; set; }
    }
}
