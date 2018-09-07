using Microsoft.AspNetCore.Hosting;

namespace ADD2CharacterService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:42000/")
                .Build();

            host.Run();
        }
    }
}
