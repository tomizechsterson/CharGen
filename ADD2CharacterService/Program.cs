using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ADD2CharacterService
{
    public static class Program
    {
        public static void Main()
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls("http://localhost:42000/")
                .Build();

            host.Run();
        }
    }
}
