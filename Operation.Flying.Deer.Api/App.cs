using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Operation.Flying.Deer.Api
{
    public class App
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}