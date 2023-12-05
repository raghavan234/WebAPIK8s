namespace WebAPIK8s
{
    public interface ICustomerService
    {
        public Task<List<CustomerDetails>> GetAllCustomerDetails();
        public Task<CustomerDetails> GetAllCustomerByID(int id);
        public Task<bool> AddCustomerDetails(CustomerDetails customerDetails);
        public Task<bool> UpdateCustomerDetails(CustomerDetails customerDetails);
        public Task<bool> DeleteCustomerDetails(int id);
    }
}
