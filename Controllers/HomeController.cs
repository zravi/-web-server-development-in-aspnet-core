using Microsoft.AspNetCore.Mvc;

namespace MovieCharactersEFCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDependency _dp;
        
        public HomeController(IDependency dp)
        {
            _dp = dp;
        }
    }
}