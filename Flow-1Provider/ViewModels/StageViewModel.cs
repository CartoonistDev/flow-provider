using Newtonsoft.Json;

namespace Flow_1Provider.ViewModels
{
    public class StageViewModel
    {
        [JsonProperty("stageName")]
        public string? Name { get; set; }

        [JsonProperty("showCandidate")]
        public bool ShowCandidate { get; set; } = false;

        [JsonProperty("stageType")]
        public StageTypeViewModel? StageType { get; set; }

    }
}
