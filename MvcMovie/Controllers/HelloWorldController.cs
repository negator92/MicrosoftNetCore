namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
            => "This is my default action";

        public string Welcome()
            => "This is the Welcome action method";
    }
}