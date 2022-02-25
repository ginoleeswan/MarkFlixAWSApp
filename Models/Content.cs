namespace MarkFlixAWSApp.Models
{
    public class Content
    {
        public string Title { get; set; }
        public string ParentTitle { get; set; }
        public string GrandparentTitle { get; set; }
        public string SeasonTitle { get; set; }
        public string EpisodeTitle { get; set; }
        public string OriginalTitle { get; set; }
        public string[] Guids { get; set; }
        public int Year { get; set; }
        public int TotalPlays { get; set; }
        public string Artwork { get; set; }
        public string MediaType { get; set; }
        public string ContentRating { get; set; }
        public string WasWatched { get; set; }
        public string LibraryName { get; set; }
        public string Overview { get; set; }
        public string RequestedBy { get; set; }
        public float WatchedStatus { get; set; }
        public int PercentComplete { get; set; }
        public string WatchedBy { get; set; }
        public int RatingKey { get; set; }
    }
}
