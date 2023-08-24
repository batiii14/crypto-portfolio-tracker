using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    public class CoinsBoughtController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
