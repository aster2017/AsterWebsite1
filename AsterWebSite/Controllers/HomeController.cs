using AsterWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsterWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/")]
        [HttpGet("{id}")]
        public IActionResult Index(string Id)
        {
            var filePath = @"./wwwroot/";

            if (string.IsNullOrWhiteSpace(Id))
            {
                Id = "index.html";
                filePath = filePath + Id;
                var html = System.IO.File.ReadAllText(filePath);
                return base.Content(html, "text/html");
            }
            filePath = filePath + Id;
            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                var html = System.IO.File.ReadAllText(filePath);
                return base.Content(html, "text/html");
            }
            else
            {
                return base.Content("File Path not valid");
            }
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
