namespace iSchoolWebApp.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Older
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class NewsModel
    {
        public List<Older> older { get; set; }
        public string pageTitle { get; set; }
    }


}
