using HellNo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HellNo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Deneme()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7284");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/api/User/add").Result;
            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}