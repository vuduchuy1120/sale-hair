using SaleRazorPage.Model;

namespace SaleRazorPage.Model
{
    public class Customer : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? FacebookLink { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? Note { get; set; }
        public List<Order>? Orders { get; set; }


    }
}
