using Newtonsoft.Json;

namespace Flow_1Provider.data
{
    public class Stage
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("stageName")]
        public string? Name { get; set; }

        [JsonProperty("showCandidate")]
        public bool ShowCandidate { get; set; } = false;

        [JsonProperty("stageType")]
        public StageType? StageType { get; set; }
        
    }
}
