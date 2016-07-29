using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightNode1.Sample
{
    using LightNode.Server;
    using Owin;
    using Microsoft.Owin.Hosting;
    using System.Threading;
    public class Hello : LightNodeContract
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
        public void Configuration(IAppBuilder builder)
        {
            builder.UseLightNode();
        }
    }
    public class Program
    {
        public static CancellationTokenSource TerminateTokenSource = new CancellationTokenSource();
        public static void Main(string[] args)
        {
            var port = 10003;
            var opts = new StartOptions($"http://localhost:{port}");
            using (WebApp.Start<Startup>($"http://localhost:{port}"))
            {
                TerminateTokenSource.Token.WaitHandle.WaitOne();
            }
        }
    }
}
