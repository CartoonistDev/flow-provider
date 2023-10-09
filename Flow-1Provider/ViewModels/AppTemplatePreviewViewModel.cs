using Newtonsoft.Json;

namespace Flow_1Provider.ViewModels
{
    public class AppTemplatePreviewViewModel
    {
        [JsonProperty("coverImage")]
        public string CoverImage { get; set; }
    }
}
