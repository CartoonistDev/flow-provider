using Newtonsoft.Json;

namespace Flow_1Provider.BindingModels
{
    public class StageTypeBindingModel
    {
        [JsonProperty("stageTypeName")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("questions")]
        public List<Dictionary<string, dynamic>>? Questions { get; set; }
    }
}

