using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
            => View();

        public string Welcome(string name, int numTimes = 1)
            => HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    }
}