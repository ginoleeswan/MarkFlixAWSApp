using MarkFlixAWSApp.Models;
using MarkFlixAWSApp.Models.Overseerr.Media;
using MarkFlixAWSApp.Models.Overseerr.Requests;
using MarkFlixAWSApp.Models.Overseerr.Users;
using System.Text.Json;

namespace MarkFlixAWSApp.Services
{
    public class OverseerrService : IOverseerrService
    {

        private readonly HttpClient _httpClient;
        private readonly ITheMovieDBService _theMovieDBService;
        private readonly ITautulliService _tautulliService;

        public OverseerrService(HttpClient httpClient, 
            ITheMovieDBService theMovieDBService,
            ITautulliService tautulliService)
        {
            _httpClient = httpClient;
            _theMovieDBService = theMovieDBService;
            _tautulliService = tautulliService;
        }

        public async Task<IEnumerable<User>?> GetUsers()
        {
            var response = await _httpClient.GetAsync("user?take=100&skip=0&sort=requests");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetOverseerrUsersResult>(responseStream);

            //IEnumerable<User> tautulliUserList = await _tautulliService.GetUsers();



            return responseObject?.results.Select(i => new User
            {
                UserId = i.id,
                Name = i.displayName,
                Email = i.email,
                RequestCount = i.requestCount,
                UserThumb = i.avatar,
            });
        }
        public async Task<Content>? GetMediaDetails(string? type, int? id)
        {
            var response = await _httpClient.GetAsync($"{type}/{id}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetMediaDetailsResult>(responseStream);


            var contentObject = new Content
            {
                Artwork = $"https://image.tmdb.org/t/p/w500{responseObject.posterPath}",
                Overview = responseObject.overview
            };

            //content.Title = (type == "tv" ? responseObject.name : responseObject.originalTitle);
            //content.Artwork = $"https://image.tmdb.org/t/p/w500{responseObject.posterPath}";
            //content.Overview = responseObject.overview;
            //content.RequestedBy = responseObject.mediaInfo.requests[0].requestedBy.plexUsername;

            return contentObject;
        }

        public async Task<IEnumerable<Models.Request>?> GetRequests(int? id)
        {
            var response = await _httpClient.GetAsync($"user/{id}/requests?take=100&skip=0");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetOverseerrUserRequestsResult>(responseStream);

            //List<Request> requestList = new List<Request>();



            //foreach (var request in responseObject?.results)
            //{
            //    var requestObject = new Request
            //    {
            //        Id = request.id,
            //        Type = request.type,
            //        Name = request.media.externalServiceSlug,
            //        ContentKey = request.media.ratingKey,
            //        TmdbID = request.media.tmdbId

            //    };

            //    requestList.Add(requestObject);
            //}

            //foreach (var request in requestList)
            //{
            //    request.Artwork = _theMovieDBService.GetArtwork(request.TmdbID, request.Type).Result;
            //}

            //return requestList;

            return responseObject?.results.Select(i => new Models.Request
            {
                Id = i.media.id,
                RequesterName = i.requestedBy.plexUsername,
                Type = i.type,
                Name = _theMovieDBService.GetName(i.media.tmdbId, i.type).Result,
                ContentKey = i.media.ratingKey,
                TmdbID = i.media.tmdbId,
                Artwork = _theMovieDBService.GetArtwork(i.media.tmdbId, i.type).Result
            });



        }


    }
}
