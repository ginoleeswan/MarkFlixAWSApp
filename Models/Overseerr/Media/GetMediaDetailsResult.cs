namespace MarkFlixAWSApp.Models.Overseerr.Media
{
    public class GetMediaDetailsResult
    {
        public int id { get; set; }
        public bool adult { get; set; }
        public int budget { get; set; }
        public Genre[] genres { get; set; }
        public Relatedvideo[] relatedVideos { get; set; }
        public string originalLanguage { get; set; }
        public string originalTitle { get; set; }
        public float popularity { get; set; }
        public Productioncompany[] productionCompanies { get; set; }
        public Productioncountry[] productionCountries { get; set; }
        public string releaseDate { get; set; }
        public Releases releases { get; set; }
        public int revenue { get; set; }
        public Spokenlanguage[] spokenLanguages { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float voteAverage { get; set; }
        public int voteCount { get; set; }
        public string backdropPath { get; set; }
        public string homepage { get; set; }
        public string imdbId { get; set; }
        public string overview { get; set; }
        public string posterPath { get; set; }
        public int runtime { get; set; }
        public string tagline { get; set; }
        public Credits credits { get; set; }
        public Externalids externalIds { get; set; }
        public Mediainfo mediaInfo { get; set; }
        public Watchprovider[] watchProviders { get; set; }
    }

    public class Releases
    {
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string iso_3166_1 { get; set; }
        public Release_Dates[] release_dates { get; set; }
    }

    public class Release_Dates
    {
        public string certification { get; set; }
        public string iso_639_1 { get; set; }
        public DateTime release_date { get; set; }
        public int type { get; set; }
        public string note { get; set; }
    }

    public class Credits
    {
        public Cast[] cast { get; set; }
        public Crew[] crew { get; set; }
    }

    public class Cast
    {
        public int castId { get; set; }
        public string character { get; set; }
        public string creditId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public int gender { get; set; }
        public string profilePath { get; set; }
    }

    public class Crew
    {
        public string creditId { get; set; }
        public string department { get; set; }
        public int id { get; set; }
        public string job { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profilePath { get; set; }
    }

    public class Externalids
    {
        public object facebookId { get; set; }
        public string imdbId { get; set; }
        public object instagramId { get; set; }
        public object twitterId { get; set; }
    }

    public class Mediainfo
    {
        public object[] downloadStatus { get; set; }
        public object[] downloadStatus4k { get; set; }
        public int id { get; set; }
        public string mediaType { get; set; }
        public int tmdbId { get; set; }
        public object tvdbId { get; set; }
        public object imdbId { get; set; }
        public int status { get; set; }
        public int status4k { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime lastSeasonChange { get; set; }
        public DateTime mediaAddedAt { get; set; }
        public int serviceId { get; set; }
        public object serviceId4k { get; set; }
        public int externalServiceId { get; set; }
        public object externalServiceId4k { get; set; }
        public string externalServiceSlug { get; set; }
        public object externalServiceSlug4k { get; set; }
        public string ratingKey { get; set; }
        public object ratingKey4k { get; set; }
        public Request[] requests { get; set; }
        public object[] issues { get; set; }
        public object[] seasons { get; set; }
        public string plexUrl { get; set; }
        public string serviceUrl { get; set; }
    }

    public class Request
    {
        public int id { get; set; }
        public int status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string type { get; set; }
        public bool is4k { get; set; }
        public int serverId { get; set; }
        public int profileId { get; set; }
        public string rootFolder { get; set; }
        public object languageProfileId { get; set; }
        public object[] tags { get; set; }
        public Media media { get; set; }
        public Requestedby requestedBy { get; set; }
        public Modifiedby modifiedBy { get; set; }
        public object[] seasons { get; set; }
        public int seasonCount { get; set; }
    }

    public class Media
    {
        public object[] downloadStatus { get; set; }
        public object[] downloadStatus4k { get; set; }
        public int id { get; set; }
        public string mediaType { get; set; }
        public int tmdbId { get; set; }
        public object tvdbId { get; set; }
        public object imdbId { get; set; }
        public int status { get; set; }
        public int status4k { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime lastSeasonChange { get; set; }
        public DateTime mediaAddedAt { get; set; }
        public int serviceId { get; set; }
        public object serviceId4k { get; set; }
        public int externalServiceId { get; set; }
        public object externalServiceId4k { get; set; }
        public string externalServiceSlug { get; set; }
        public object externalServiceSlug4k { get; set; }
        public string ratingKey { get; set; }
        public object ratingKey4k { get; set; }
        public object[] seasons { get; set; }
        public string plexUrl { get; set; }
        public string serviceUrl { get; set; }
    }

    public class Requestedby
    {
        public int permissions { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string plexUsername { get; set; }
        public object username { get; set; }
        public object recoveryLinkExpirationDate { get; set; }
        public int userType { get; set; }
        public string avatar { get; set; }
        public object movieQuotaLimit { get; set; }
        public object movieQuotaDays { get; set; }
        public object tvQuotaLimit { get; set; }
        public object tvQuotaDays { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public object settings { get; set; }
        public int requestCount { get; set; }
        public string displayName { get; set; }
    }

    public class Modifiedby
    {
        public int permissions { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string plexUsername { get; set; }
        public object username { get; set; }
        public object recoveryLinkExpirationDate { get; set; }
        public int userType { get; set; }
        public string avatar { get; set; }
        public object movieQuotaLimit { get; set; }
        public object movieQuotaDays { get; set; }
        public object tvQuotaLimit { get; set; }
        public object tvQuotaDays { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public object settings { get; set; }
        public int requestCount { get; set; }
        public string displayName { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Relatedvideo
    {
        public string site { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Productioncompany
    {
        public int id { get; set; }
        public string name { get; set; }
        public string originCountry { get; set; }
        public string logoPath { get; set; }
    }

    public class Productioncountry
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class Spokenlanguage
    {
        public string english_name { get; set; }
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }

    public class Watchprovider
    {
        public string iso_3166_1 { get; set; }
        public string link { get; set; }
        public Buy[] buy { get; set; }
        public Flatrate[] flatrate { get; set; }
    }

    public class Buy
    {
        public int displayPriority { get; set; }
        public string logoPath { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Flatrate
    {
        public int displayPriority { get; set; }
        public string logoPath { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
}
