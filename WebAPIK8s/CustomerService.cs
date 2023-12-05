using Microsoft.EntityFrameworkCore;

namespace WebAPIK8s
{
    public class CustomerService : ICustomerService
    {
        public readonly DbContextClass dbContextClass;
        public CustomerService(DbContextClass dbContextClass) 
        { 
            this.dbContextClass = dbContextClass;
        }
        public async Task<bool> AddCustomerDetails(CustomerDetails customerDetails)
        {
            await this.dbContextClass.Customers.AddAsync(customerDetails);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }

        public async Task<bool> DeleteCustomerDetails(int id)
        {
            var findCustomerData = dbContextClass.Customers.Where(_ => _.CustomerID == id).FirstOrDefault();
            if (findCustomerData != null)
            {
                dbContextClass.Customers.Remove(findCustomerData);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                    return true;
                return false;
            }
            return false;
        }

        public async Task<CustomerDetails> GetAllCustomerByID(int id)
        {
            return await dbContextClass.Customers.Where(x => x.CustomerID == id).FirstOrDefaultAsync();
        }

        public async Task<List<CustomerDetails>> GetAllCustomerDetails()
        {
            return await dbContextClass.Customers.ToListAsync();
        }

        public async Task<bool> UpdateCustomerDetails(CustomerDetails customerDetails)
        {
            dbContextClass.Customers.Update(customerDetails);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }
    }
}
