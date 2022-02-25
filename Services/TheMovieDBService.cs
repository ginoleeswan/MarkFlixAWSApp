﻿using MarkFlixAWSApp.Models.TheMovieDB;
using System.Text.Json;

namespace MarkFlixAWSApp.Services
{
    public class TheMovieDBService : ITheMovieDBService
    {
        private readonly HttpClient _httpClient;

        private string _apiKey = "3879bd1c26dd9ee50d4e4e01da21e6f0";

        public TheMovieDBService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string?> GetArtwork(int id, string type)
        {


            var apiString = $"/3/{type}/{id}?api_key={_apiKey}&language=en-US";
            var response = await _httpClient.GetAsync(apiString);
            //response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var responseObject = await JsonSerializer.DeserializeAsync<MovieDBSearchResult>(responseStream);

                return ($"https://image.tmdb.org/t/p/w500{responseObject?.poster_path}");
            }
            else
            {
                return "https://i.ibb.co/YhrmQ7F/404-poster-not-found-CG17701-1.png";

            }


        }

        public async Task<string?> GetName(int id, string type)
        {

            var apiString = $"/3/{type}/{id}?api_key={_apiKey}&language=en-US";
            var response = await _httpClient.GetAsync(apiString);
            //response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var responseObject = await JsonSerializer.DeserializeAsync<MovieDBSearchResult>(responseStream);

                return (type == "tv" ? responseObject?.name : responseObject?.original_title);
            }

            else
            {
                return "Not Found";
            }



        }
    }
}
