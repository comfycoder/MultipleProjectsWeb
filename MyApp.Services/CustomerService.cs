using MyApp.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AdventureWorksDbContext _context;

        public CustomerService(AdventureWorksDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var customers = await _context.Customers.Take(50).ToListAsync();

            return customers;
        }
    }
}
