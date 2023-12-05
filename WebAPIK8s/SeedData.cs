using Microsoft.EntityFrameworkCore;

namespace WebAPIK8s
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DbContextClass(serviceProvider.GetRequiredService<DbContextOptions<DbContextClass>>()))
            {
                if (context.Customers.Any()) { return; }
                context.Customers.AddRange(new CustomerDetails { CustomerID = 1, CustomerName = "Jorginho", CustomerAddress = "Italy", CustomerNumber = 12345, CustomerPinCode = 400102});
                context.SaveChanges();
            }
        }
    }
}
    