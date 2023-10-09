using Newtonsoft.Json;

namespace Flow_1Provider.data
{
    public class StageType
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("stageTypeName")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("questions")]
        public List<Dictionary<string, dynamic>>? Questions { get; set; }

    }
}
