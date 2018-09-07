using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DD35CharacterService
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:42001")
                .Build();
    }
}