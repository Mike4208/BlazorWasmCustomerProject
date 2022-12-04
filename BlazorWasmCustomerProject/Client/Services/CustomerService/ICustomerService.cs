using BlazorWasmCustomerProject.Shared.Models;

namespace BlazorWasmCustomerProject.Client.Services.CustomerService
{
    public interface ICustomerService
    {
        List<Customer> Customers { get; set; }
        public HttpResponseMessage HttpResponse { get; set; }

        Task getCustomers(int page, int quantityPerPage);
        Task<Customer> GetSingleCustomer(int? id);
        Task CreateCustomer(Customer customer);
        Task DeleteCustomer(int? id);
        Task UpdateCustomer(Customer customer);
    }
}
