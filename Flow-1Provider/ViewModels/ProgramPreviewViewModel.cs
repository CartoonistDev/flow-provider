using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Flow_1Provider.ViewModels
{
    public class ProgramPreviewViewModel
    {
        [JsonProperty("title")]
        [Required]
        public string Title { get; set; }

        [JsonProperty("summary")]
        [Required]
        [StringLength(250)]
        public string Summary { get; set; }

        [JsonProperty("description")]
        [Required]
        public string Description { get; set; }

        [JsonProperty("skills")]
        public string Skills { get; set; }

        [JsonProperty("benefits")]
        public string Benefits { get; set; }

        [JsonProperty("applicationCriteria")]
        public string ApplicationCriteria { get; set; }

        [JsonProperty("programType")]
        [Required]
        public string ProgramType { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("applicationOpen")]
        [Required]
        public DateTime ApplicationOpen { get; set; }

        [JsonProperty("applicationClose")]
        [Required]
        public DateTime ApplicationClose { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("location")]
        [Required]
        public string Location { get; set; }

        [JsonProperty("appTemplate")]
        [Required]
        public AppTemplatePreviewViewModel? AppTemplate { get; set; }


    }
}
