using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightNode2.Sample
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using LightNode;
    using LightNode.Server;
    using System.Threading;
    class Hello : LightNodeContract
    {
        public string Echo(string name)
        {
            name = name ?? "Unknown";
            return $"Hello {name}";
        }
        public void Terminate()
        {
            Program.TerminateTokenSource.Cancel();
        }
    }
    class Startup
    {
        public void Configure(IApplicationBuilder builder)
        {
            builder.UseLightNode(typeof(Startup));
        }
    }
    public class Program
    {
        public static CancellationTokenSource TerminateTokenSource = new CancellationTokenSource();
        public static void Main(string[] args)
        {
            var port = 10005;
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
