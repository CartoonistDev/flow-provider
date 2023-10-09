using Newtonsoft.Json;

namespace Flow_1Provider.data
{
    public class Education
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("school")]
        public string? School { get; set; }

        [JsonProperty("course")]
        public string? Course { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }

        [JsonProperty("startDate")]
        public DateTime StateDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("currentlyStudy")]
        public bool CurrentlyStudy { get; set; } = false;

        [JsonProperty("qualification")]
        public string Qualification { get; set; }

        [JsonProperty("appTemplateId")]
        public string AppTemplateID { get; set; }

    }
}
