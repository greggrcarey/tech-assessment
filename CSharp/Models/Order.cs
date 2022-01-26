namespace CSharp.Models
{

    public class Order
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
    }
}