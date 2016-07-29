using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcSample.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class HelloController : Controller
    {
        public IActionResult Echo(string name)
        {
            name = name ?? "Unknown";
            return Json($"Hello {name}");
        }
        public IActionResult Terminate()
        {
            Program.TerminateTokenSource.Cancel();
            return this.NoContent();
        }
    }
}
