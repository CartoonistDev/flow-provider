using Newtonsoft.Json;

namespace Flow_1Provider.data
{
    public class ProgramType
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("programName")]
        public string Name { get; set; }
    }
}
