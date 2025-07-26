using System.ComponentModel.DataAnnotations;

namespace template_webapi.Data.Entities
{
    public class Category
    {
        [Key]
        public int Categoryid { get; set; }
        public string Categoryname { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
