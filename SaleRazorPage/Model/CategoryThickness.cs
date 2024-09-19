namespace SaleRazorPage.Model
{
    public class CategoryThickness
    {
        public Guid CategoryId { get; set; }
        public Guid ThicknessId { get; set; }
        public Category Category { get; set; }
        public Thickness Thickness { get; set; }
    }
}
