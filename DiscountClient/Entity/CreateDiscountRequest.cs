namespace DiscountClient.Entity
{
    public class CreateDiscountRequest
    {
        public string ProductId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
