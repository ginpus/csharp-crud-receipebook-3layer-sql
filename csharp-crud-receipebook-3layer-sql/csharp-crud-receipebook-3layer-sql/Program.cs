using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace csharp_crud_receipebook_3layer_sql
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var startup = new Startup();

            var serviceProvider = startup.ConfigureServices();

            var receipeApp = serviceProvider.GetService<ReceipeApp>();

            receipeApp.StartAsync();
        }
    }
}