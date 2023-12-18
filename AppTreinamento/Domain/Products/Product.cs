namespace AppTreinamento.Domain.Products
{
    public class Product : Entity
    {
        public int CategoryId { get; set; }
        public Guid Category { get; set; }
        public string Description { get; set; }
        public bool HasStock { get; set; }
        public bool Active { get; set; } = true;
    }
}
