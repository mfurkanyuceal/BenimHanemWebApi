using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication
{

    //Bakalım Jenkins çalışıyor mu?
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseKestrel().UseUrls("http://167.71.74.239:5001").UseStartup<Startup>();
            //WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
