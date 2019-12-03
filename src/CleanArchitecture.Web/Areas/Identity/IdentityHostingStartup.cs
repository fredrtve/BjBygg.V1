using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CleanArchitecture.Web.Areas.Identity.IdentityHostingStartup))]
namespace CleanArchitecture.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}