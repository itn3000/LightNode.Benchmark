using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcSample
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading;
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder builder)
        {
            builder.UseMvc(route =>
            {
                route.MapRoute("default", "{controller}/{action}/{id?}");
            });
        }
    }
    public class Program
    {
        public static CancellationTokenSource TerminateTokenSource = new CancellationTokenSource();
        public static void Main(string[] args)
        {
            var port = 10004;
            using (var host = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseKestrel()
                .UseUrls($"http://localhost:{port}")
                .Build())
            {
                host.Run(TerminateTokenSource.Token);
            }
        }
    }
}
