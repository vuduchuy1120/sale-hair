namespace SaleRazorPage.Model
{
    public class TypeHair : EntityBase<Guid>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string? NameUnAccent { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public Category Category { get; set; }
        public List<SubTypeHair>? Subtypes { get; set; }
    }

}
