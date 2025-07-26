using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace template_webapi.Data.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public short Qty { get; set; }

        public decimal Discount { get; set; }
        [ForeignKey("Orderid")]
        public virtual Order Order { get; set; } = null!;
        [ForeignKey("Productid")]
        public virtual Product Product { get; set; } = null!;
    }
}
