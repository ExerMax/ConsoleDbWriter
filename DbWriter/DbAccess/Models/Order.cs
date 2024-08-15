using System.ComponentModel.DataAnnotations.Schema;

namespace DbWriter.DbAccess.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required int No { get; set; }
        public required int CustomerId { get; set; }
        public double Sum { get; set; }
        public required Customer Customer { get; set; }
        public required DateTime DateTime { get; set; }
        public List<Product> Products { get; set; } = new();
        public List<OrderProduct> OrderProducts { get; set; } = new();
    }
}
