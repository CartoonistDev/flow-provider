using Flow_1Provider.data;
using Newtonsoft.Json;

namespace Flow_1Provider.BindingModels
{
    public class StageUpdateModel
    {
        [JsonProperty("programsId")]
        public string ProgramsId { get; set; }

        public List<StageUpdateBindingModel>? Stages { get; set;}      
    }

    public class StageUpdateBindingModel
    {
        [JsonProperty("stageId")]
        public string id { get; set; }

        [JsonProperty("stageName")]
        public string? Name { get; set; }

        [JsonProperty("showCandidate")]
        public bool ShowCandidate { get; set; } = false;

        [JsonProperty("stageType")]
        public StageTypeBindingModel? StageType { get; set; }

    }

    public class StageBindingModel
    {
        [JsonProperty("stageName")]
        public string? Name { get; set; }

        [JsonProperty("showCandidate")]
        public bool ShowCandidate { get; set; } = false;

        [JsonProperty("stageType")]
        public StageTypeBindingModel? StageType { get; set; }

    }
}
