using MyApp.Contracts;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace MyApp.Web.DocumentFilters
{
    public class CustomerExamples : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<CustomerDto>
            {
                new CustomerDto { CustomerId = 1, Title = "Mr", FirstName = "Lenard", LastName = "Picton", EmailAddress = "lpicton1@mashable.com", Phone = "630-918-8604" },
                new CustomerDto { CustomerId = 2, Title = "Ms", FirstName = "Marysa", LastName = "Glinde", EmailAddress = "mglinde4@nba.com", Phone = "795-218-9553" }
            };
        }
    }
}
