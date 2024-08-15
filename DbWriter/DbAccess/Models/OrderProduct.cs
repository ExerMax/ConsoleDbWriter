namespace DbWriter.DbAccess.Models
{
    public class OrderProduct
    {
        public required int OrderId { get; set; }
        public Order? Order { get; set; }
        public required int ProductId { get; set; }
        public Product? Product { get; set; }
        public required int Quantity { get; set; }
    }
}
