using Microsoft.EntityFrameworkCore;

namespace WebAPIK8s
{
    [Keyless]
    public class CustomerDetails
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerNumber { get; set; }
        public int CustomerPinCode { get; set; }
    }
}
