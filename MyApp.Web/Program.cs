using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MyApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
              .ConfigureAppConfiguration((context, config) =>
              {
                  var env = context.HostingEnvironment;

                  config.SetBasePath(env.ContentRootPath)
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddEnvironmentVariables();

                  // Call other providers here and call AddKeyPerFile last

                  if (env.IsDevelopment())
                  {
                      config.AddJsonFile("localsecrets.json", optional: true, reloadOnChange: true);
                  }
                  else
                  {
                      // The following config builder method reads Azure Key Vault secrets as if they
                      // were individual files in a folder called '/kvmnt' 
                      config.AddKeyPerFile("/kvmnt", false);
                  }
              })
              .UseStartup<Startup>();
    }
}
