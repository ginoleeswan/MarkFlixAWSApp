using MarkFlixAWSApp.Models;
using MarkFlixAWSApp.Models.Tautulli.Libraries;
using MarkFlixAWSApp.Models.Tautulli.LibraryUserStats;
using MarkFlixAWSApp.Models.Tautulli.RecentlyAdded;
using MarkFlixAWSApp.Models.Tautulli.History;
using MarkFlixAWSApp.Models.Tautulli.AllHistory;
using System.Text.Json;
using MarkFlixAWSApp.Models.Tautulli.MediaHistory;
using MarkFlixAWSApp.Models.Tautulli.UserNames;
using MarkFlixAWSApp.Models.Tautulli.PlaysPerMonth;

namespace MarkFlixAWSApp.Services
{
    public class TautulliService : ITautulliService
    {
        private readonly HttpClient _httpClient;
        private readonly ITheMovieDBService _theMovieDBService;
        private readonly string _apiKey = "332585e9a336416fba06c72da3a3cb7d";

        public TautulliService(
            HttpClient httpClient,
            ITheMovieDBService theMovieDBService)
        {
            _httpClient = httpClient;
            _theMovieDBService = theMovieDBService;

        }

        //public async Task<IEnumerable<User>?> GetUsers()
        //{
        //    var response = await _httpClient.GetAsync($"?apikey={_apiKey}&cmd=get_user_names");

        //    response.EnsureSuccessStatusCode();

        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    var responseObject = await JsonSerializer.DeserializeAsync<GetTautulliUserNamesResult>(responseStream);

        //    //IEnumerable<User> overseerrUserList = await _overseerrService.GetUsers();

        //    return responseObject?.response.data.Select(i => new User
        //    {
        //        UserId = i.user_id,
        //        Name = i.friendly_name
        //    });
        //}
        public async Task<IEnumerable<Library>?> GetLibraries()
        {
            var response = await _httpClient.GetAsync($"?apikey={_apiKey}&cmd=get_libraries");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync < GetTautulliLibrariesResult>(responseStream);

            return responseObject?.response?.data.Select(i => new Library
            {
                SectionId = int.Parse(i.section_id),
                LibraryName = i.section_name,
                LibraryType = i.section_type,
                Count = i.is_active

            });
        }

        public async Task<IEnumerable<User>?> GetLibraryUserStats(int sectionId)
        {
            var response = await _httpClient.GetAsync($"?apikey={_apiKey}&cmd=get_library_user_stats&section_id={sectionId}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetTautulliLibraryUserStatsResult>(responseStream);

            return responseObject?.response?.data.Select(i => new User
            {
                Name = i.friendly_name,
                UserId = i.user_id,
                TotalPlays = i.total_plays,
                Email = i.username,
                UserThumb = i.user_thumb


            });
        }

        public async Task<IEnumerable<Content>?> GetRecentlyAdded()
        {
            var response = await _httpClient.GetAsync($"?apikey={_apiKey}&cmd=get_recently_added&count=200");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetTautulliRecentlyAddedResult>(responseStream);

            List<Content> contentList = new List<Content>();



            foreach (var i in responseObject?.response.data.recently_added)
            {
                var contentObject = new Content
                {
                    Title = (i.media_type == "episode" ? i.grandparent_title : (i.media_type == "season" ? i.parent_title : (i.media_type == "show" ? i.title : (i.media_type == "movie" ? i.title : "N/A")))),
                    ParentTitle = (i.media_type == "season" ? i.title : i.parent_title),
                    GrandparentTitle = i.grandparent_title,
                    SeasonTitle = (i.media_type == "season" ? i.title : (i.media_type == "episode" ? i.parent_title : "")),
                    EpisodeTitle = (i.media_type == "episode" ? i.title : ""),
                    OriginalTitle = i.original_title,
                    Guids = i.guids,
                    LibraryName = i.library_name,
                    MediaType = i.media_type,
                    WasWatched = (i.last_viewed_at == "" ? "Never Watched" : i.last_viewed_at)

                };

                contentList.Add(contentObject);
            }

            return contentList;

            //return responseObject?.response?.data.recently_added.Select(i => new Content
            //{
                
            //    Title = (i.library_name == "TV Shows" ? i.grandparent_title : i.title),
            //    ParentTitle = (i.media_type == "season" ? i.title : i.parent_title),
            //    GrandparentTitle = i.grandparent_title,
            //    EpisodeTitle = (i.library_name == "TV Shows" ? i.title : "N/A"),
            //    OriginalTitle = i.original_title,
            //    Guids = i.guids,
            //    LibraryName = i.library_name,
            //    MediaType = i.media_type,
            //    WasWatched = (i.last_viewed_at == "" ? "Never Watched" : i.last_viewed_at)

            //    //Artwork = String.Format("https://image.tmdb.org/t/p/w500{0}", _theMovieDBService.GetArtwork(int.Parse(i.guids.First().Substring(7,-1)), (i.media_type == "season" || i.media_type == "episode" ? "tv" : "movie")).Result)

            //}); ;



            //responseObject?.response?.data.Select(i => new Movie
            //{
            //    for (var row in this.i)
            //{
            //    Title = i.rows[0].title,
            //    Year = i.rows[0].year,
            //    TotalPlays = i.rows[0].total_plays,
            //    Artwork = i.rows[0].art,
            //    MediaType = i.rows[0].media_type

            //}

            //});


        }

        public async Task<IEnumerable<Content>?> GetUserWatchHistory(string userName)
        {
            var response = await _httpClient.GetAsync($"?apikey={_apiKey}&cmd=get_history&user={userName}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetTautulliHistoryResult>(responseStream);

            return responseObject?.response?.data.data.Select(i => new Content
            {
                Title = i.full_title,
                MediaType = i.media_type,
                ParentTitle = i.parent_title,
                GrandparentTitle = i.grandparent_title,
                PercentComplete = i.percent_complete,
                WatchedStatus = i.watched_status,
                WatchedBy = i.user,
                RatingKey = i.rating_key,
            });
        }

        public async Task<IEnumerable<Content>?> GetAllWatchHistory()
        {
            var response = await _httpClient.GetAsync($"?apikey={_apiKey}&cmd=get_history&length=10");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetTautulliAllHistoryResult>(responseStream);

            return responseObject?.response?.data.data.Select(i => new Content
            {
                Title = i.full_title,
                MediaType = i.media_type,
                ParentTitle = i.parent_title,
                GrandparentTitle = i.grandparent_title,
                PercentComplete = i.percent_complete,
                WatchedStatus = i.watched_status,
                WatchedBy = i.user
            });
        }

        public async Task<IEnumerable<User>?> GetMediaWatchHistory(int ratingKey)
        {
            var response = await _httpClient.GetAsync($"?apikey={_apiKey}&cmd=get_history&rating_key={ratingKey}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetTautulliMediaHistoryResult>(responseStream);

            return responseObject?.response?.data.data.Select(i => new User
            {
                Name = i.user,
                UserId = i.user_id,
                WatchedStatus = i.watched_status,
                PercentComplete = i.percent_complete,
                MediaWatchedTitle = i.full_title
            });
        }

        //public async Task<IEnumerable<PlayData>?> GetPlaysPerMonth()
        //{
        //    var response = await _httpClient.GetAsync($"?apikey={_apiKey}&cmd=get_plays_per_month");

        //    response.EnsureSuccessStatusCode();

        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    var responseObject = await JsonSerializer.DeserializeAsync<GetTautulliPlaysPerMonthResult>(responseStream);

        //    List<PlayData> playDataList = new List<PlayData>();
        //    var playDataObject = new PlayData();



        //    foreach (var date in responseObject?.response.data.categories)
        //    {
        //        playDataObject.Date = date;

        //        playDataList.Add(playDataObject);
        //    }

        //    foreach (var data in responseObject?.response.data.series)
        //    {
        //        playDataObject.LibraryName = "TV";
        //        playDataObject.PlayCount = data.data;
              
        //    }

        //    return playDataList;

            //return responseObject?.response.data.categories.Select(i => new PlayData
            //{

            //});
        //}
    }
}
