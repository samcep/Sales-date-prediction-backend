using Microsoft.EntityFrameworkCore;

namespace template_webapi.Features.Customers.Dtos
{
    [Keyless]
    public class CustomerPredictionResponse
    {
        public int Custid { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? NextPredictedOrder { get; set; }
    }

}
