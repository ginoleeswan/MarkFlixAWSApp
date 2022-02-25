using MarkFlixAWSApp.Models;
using MarkFlixAWSApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarkFlixAWSApp.Controllers
{
    public class RecentlyAddedController : Controller
    {
        private readonly ITautulliService _tautulliService;

        public RecentlyAddedController(ITautulliService tautulliService)
        {
            _tautulliService = tautulliService;
        }
        public async Task<IActionResult> Index()
        {
            var recentlyAdded = await GetRecentlyAdded();

            return View(recentlyAdded);
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
    }
}
