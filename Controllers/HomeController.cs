using MarkFlixAWSApp.Models;
using MarkFlixAWSApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarkFlixAWSApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITautulliService _tautulliService;

        public HomeController(
            ILogger<HomeController> logger,
            ITautulliService tautulliService)
        {
            _logger = logger;
            _tautulliService = tautulliService;
        }

        public async Task<IActionResult> Index()
        {
            var recentlyAdded = await GetRecentlyAdded();
            return View(recentlyAdded);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        private async Task<IEnumerable<Content>> GetRecentlyAdded()
        {
            try
            {
                var recentlyAdded = await _tautulliService.GetRecentlyAdded();

                return recentlyAdded;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Content>();
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}