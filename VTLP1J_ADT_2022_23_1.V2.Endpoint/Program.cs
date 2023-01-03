using System;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;


namespace VTLP1J_ADT_2022_23_1.V2.Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
          CreateHostbuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostbuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}