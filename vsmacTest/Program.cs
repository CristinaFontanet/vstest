using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace vsmacTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var config = new ConfigurationBuilder()
				.AddEnvironmentVariables(prefix: "ASPNETCORE_")
				.AddJsonFile("hosting.json", optional: true)
				.Build();
			
            var host = new WebHostBuilder()
				.UseConfiguration(config)
				.UseKestrel()
				.UseUrls("http://*:5000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
