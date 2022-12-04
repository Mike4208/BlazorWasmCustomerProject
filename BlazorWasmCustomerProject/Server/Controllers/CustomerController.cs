using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorWasmCustomerProject.Server.Data;
using Microsoft.EntityFrameworkCore;
using BlazorWasmCustomerProject.Shared.Models;
using BlazorWebbAsemblyApp_Customer.Server.Helpers;
using BlazorWasmCustomerProject.Server.Helpers;

namespace BlazorWasmCustomerProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        public CustomerController(DataContext context) 
        {
            _context= context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers([FromQuery]Pagination pagination)
        {
            //var customers = await _context.Customers.ToListAsync();

            //return Ok(customers);
            
            var queryable = _context.Customers.AsQueryable();
            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.QuantityPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
        } 


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);   
            if (customer == null)
            {
                return NotFound("No Customer found by this id :/");
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
           
            return Ok(await GetDbCustomers());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer, int id)
        {
            var dbCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if(dbCustomer == null)
            {
                return NotFound("Customer not found :/");
            }

            dbCustomer.CompanyName = customer.CompanyName;
            dbCustomer.ContactName = customer.ContactName;
            dbCustomer.Address = customer.Address;
            dbCustomer.City = customer.City;
            dbCustomer.Region = customer.Region;
            dbCustomer.PostalCode = customer.PostalCode;
            dbCustomer.Country = customer.Country;
            dbCustomer.Phone = customer.Phone;

            await _context.SaveChangesAsync();

            return Ok(await GetDbCustomers());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound("Customer not found :/");
            }

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return Ok(await GetDbCustomers());
        }

        private async Task<List<Customer>> GetDbCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

    }
}
