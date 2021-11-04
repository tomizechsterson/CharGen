using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DD35CharacterService
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Build().Run();
        }

        private static IHostBuilder BuildWebHost(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseStartup<Startup>()
                    .UseUrls("http://localhost:5002", "https://localhost:5003");
            });
    }
}
