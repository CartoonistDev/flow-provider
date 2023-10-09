using Newtonsoft.Json;

namespace Flow_1Provider.data
{
    public class WorkExperience
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("startDate")]
        public DateTime StateDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("currentCompany")]
        public bool CurrentCompany { get; set; } = false;

        [JsonProperty("appTemplateId")]
        public string AppTemplateID { get; set; }

    }
}
