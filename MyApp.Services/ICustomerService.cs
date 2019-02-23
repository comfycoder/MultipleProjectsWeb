using MyApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}