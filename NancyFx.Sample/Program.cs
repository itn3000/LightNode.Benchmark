using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NancyFx.Sample
{
    using Microsoft.AspNetCore.Builder;
    using Nancy;
    using Nancy.Owin;
    using System.Threading;
    using Microsoft.AspNetCore.Hosting;
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get("/Hello/Echo", x =>
             {
                 string name = this.Request.Query.name == null ? "Unknown" : Request.Query.name;
                 return $"Hello {name}";
             });
            Get("/Hello/Terminate", x =>
            {
                Program.TerminateTokenSource.Cancel();
                return "";
            });
        }
    }
    class Startup
    {
        public void Configure(IApplicationBuilder builder)
        {
            builder.UseOwin(pipeline =>
            {
                pipeline.UseNancy();
            });
        }
    }
    public class Program
    {
        public static CancellationTokenSource TerminateTokenSource = new CancellationTokenSource();
        public static void Main(string[] args)
        {
            var port = 10006;
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
