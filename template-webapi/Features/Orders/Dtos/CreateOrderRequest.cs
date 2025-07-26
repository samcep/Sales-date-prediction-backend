namespace template_webapi.Features.Orders.Dtos
{
    public class CreateOrderRequest
    {
        public int Empid { get; set; }
        public int Shipperid { get; set; }
        public string Shipname { get; set; } = null!;
        public string Shipaddress { get; set; } = null!;
        public string Shipcity { get; set; } = null!;
        public DateTime Orderdate { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public decimal Freight { get; set; }
        public string Shipcountry { get; set; } = null!;
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public short Qty { get; set; }

        public decimal Discount { get; set; }
    }
}
