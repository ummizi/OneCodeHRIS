using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneCode.HRIS.Models;
using System.Net.Http;
using OneCode.HRIS.Models.EmployeeModels;

namespace OneCode.HRIS.API
{
    public class Program
    {

        private static readonly HttpClient client = new HttpClient();

        public static void Main(string[] args)
        {
            TransactionPersonalData personalData = new TransactionPersonalData();
            personalData.Id = Guid.NewGuid();

            MasterAddressType addressType = new MasterAddressType();
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
