namespace MarkFlixAWSApp.Models.Tautulli.PlaysPerMonth
{
    public class GetTautulliPlaysPerMonthResult
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public string result { get; set; }
        public object message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string[] categories { get; set; }
        public Series[] series { get; set; }
    }

    public class Series
    {
        public string name { get; set; }
        public int[] data { get; set; }
    }

}
