namespace MarkFlixAWSApp.Models.Tautulli.UserNames
{

    public class GetTautulliUserNamesResult
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public string result { get; set; }
        public object message { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public int user_id { get; set; }
        public string friendly_name { get; set; }
    }

}
