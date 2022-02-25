namespace MarkFlixAWSApp.Models.Tautulli.MediaHistory
{

    public class GetTautulliMediaHistoryResult
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
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public Datum[] data { get; set; }
        public int draw { get; set; }
        public string filter_duration { get; set; }
        public string total_duration { get; set; }
    }

    public class Datum
    {
        public int? reference_id { get; set; }
        public int? row_id { get; set; }
        public int? id { get; set; }
        public int date { get; set; }
        public int started { get; set; }
        public int stopped { get; set; }
        public int duration { get; set; }
        public int paused_counter { get; set; }
        public int user_id { get; set; }
        public string user { get; set; }
        public string friendly_name { get; set; }
        public string platform { get; set; }
        public string product { get; set; }
        public string player { get; set; }
        public string ip_address { get; set; }
        public int live { get; set; }
        public string machine_id { get; set; }
        public string location { get; set; }
        public int secure { get; set; }
        public int relayed { get; set; }
        public string media_type { get; set; }
        public int rating_key { get; set; }
        public int parent_rating_key { get; set; }
        public int grandparent_rating_key { get; set; }
        public string full_title { get; set; }
        public string title { get; set; }
        public string parent_title { get; set; }
        public string grandparent_title { get; set; }
        public string original_title { get; set; }
        public string year { get; set; }
        public int media_index { get; set; }
        public int parent_media_index { get; set; }
        public string thumb { get; set; }
        public string originally_available_at { get; set; }
        public string guid { get; set; }
        public string transcode_decision { get; set; }
        public int percent_complete { get; set; }
        public int watched_status { get; set; }
        public int? group_count { get; set; }
        public string group_ids { get; set; }
        public string state { get; set; }
        public int? session_key { get; set; }
    }

}
