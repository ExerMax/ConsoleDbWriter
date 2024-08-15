using System.ComponentModel.DataAnnotations.Schema;

namespace DbWriter.DbAccess.Models
{
    public class Tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; } = new List<Product> { };
    }
}
