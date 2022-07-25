using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneCode.HRIS.Models;
using OneCode.HRIS.Models.Employee;
using OneCode.HRIS.Models.Setup;
using System.Net.Http;

namespace OneCode.HRIS.API
{
    public class Program
    {

        private static readonly HttpClient client = new HttpClient();

        public static void Main(string[] args)
        {
            PersonalData personalData = new PersonalData();
            personalData.Id = Guid.NewGuid();

            AddressType addressType = new AddressType();
            addressType.Id = Guid.NewGuid();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }


}
