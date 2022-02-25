namespace MarkFlixAWSApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RequestCount { get; set; }
        public int TotalPlays { get; set; }
        public int Plays { get; set; }
        public int Duration { get; set; }
        public string LastPlayed { get; set; }
        public string Platform { get; set; }
        public string UserThumb { get; set; }
        public string MediaType { get; set; }
        public float WatchedStatus { get; set; }
        public int PercentComplete { get; set; }
        public string MediaWatchedTitle { get; set; }

    }
}
