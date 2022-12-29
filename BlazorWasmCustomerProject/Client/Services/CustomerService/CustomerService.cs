 using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using BlazorWasmCustomerProject.Shared.Models;

namespace BlazorWasmCustomerProject.Client.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

       

        public CustomerService(HttpClient http, NavigationManager navigationManager) 
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Customer> Customers { get; set ; } = new List<Customer>();

        public HttpResponseMessage HttpResponse { get; set; } = new HttpResponseMessage();

        public async Task CreateCustomer(Customer customer)
        {
            var result = await _http.PostAsJsonAsync("api/customer", customer);
            await SetCustomers(result);

        }

        public async Task DeleteCustomer(int? id)
        {
            var result = await _http.DeleteAsync($"api/customer/{id}");
            await SetCustomers(result);
        }

        public async Task getCustomers(int page, int quantityPerPage)
        {
            HttpResponse = await _http.GetAsync($"api/customer?page={page}&quantityPerPage={quantityPerPage}");
        }

        public async Task<Customer> GetSingleCustomer(int? id)
        {
            var result = await _http.GetFromJsonAsync<Customer>($"api/customer/{id}");
            if(result != null)
            {
                return result;
            }
            throw new Exception("Customer not found");
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var result = await _http.PutAsJsonAsync($"api/customer/{customer.Id}", customer);
            await SetCustomers(result);
        }

        private async Task SetCustomers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Customer>>();
            if (response != null)
            {
                Customers = response;
            }
            _navigationManager.NavigateTo("customers");
        }
    }
}
