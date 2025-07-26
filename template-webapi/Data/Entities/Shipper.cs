using System.ComponentModel.DataAnnotations;

namespace template_webapi.Data.Entities
{
    public class Shipper
    {
        [Key]
        public int Shipperid { get; set; }

        public string Companyname { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
