using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(DentalClinic_1._1.Areas.Identity.IdentityHostingStartup))]

namespace DentalClinic_1._1.Areas.Identity
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