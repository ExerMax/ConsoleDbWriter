using System.ComponentModel.DataAnnotations.Schema;

namespace DbWriter.DbAccess.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required int Quantity { get; set; } = 0;
        public string? Description { get; set; }
        public List<Tag> Tags { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
        public List<OrderProduct> OrderProducts { get; set; } = new();
    }
}
