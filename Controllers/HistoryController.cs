using MarkFlixAWSApp.Models;
using MarkFlixAWSApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarkFlixAWSApp.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ITautulliService _tautulliService;

        public HistoryController(ITautulliService tautulliService)
        {
            _tautulliService = tautulliService;
        }
        public async Task<IActionResult> Index()
        {
            var history = await GetAllWatchHistory();

            return View(history);
        }

        public async Task<IActionResult> Media(int ratingKey)
        {
            var users = await GetMediaWatchHistory(ratingKey);

            return View(users);
        }

        public async Task<IEnumerable<Content>> GetAllWatchHistory()
        {
            try
            {
                var history = await _tautulliService.GetAllWatchHistory();

                return history;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Content>();
            }
        }

        public async Task<IEnumerable<User>> GetMediaWatchHistory(int ratingKey)
        {
            try
            {
                var history = await _tautulliService.GetMediaWatchHistory(ratingKey);

                return history;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<User>();
            }
        }
    }
}
