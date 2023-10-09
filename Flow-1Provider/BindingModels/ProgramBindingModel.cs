using Flow_1Provider.data;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Flow_1Provider.BindingModels
{
    public class ProgramUpdateModel
    {
        [JsonProperty("programsId")]
        public string ProgramsId { get; set; }

        public ProgramBindingModel program { get; set; }
    }
    public class ProgramBindingModel
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

        [JsonProperty("minQualification")]
        public string MinQualification { get; set; }

        [JsonProperty("numberOfApplicants")]
        public int NumberOfApplicants { get; set; }

        [JsonProperty("appTemplate")]
        public AppTemplateBindingModel? AppTemplate { get; set; }

        [JsonProperty("stages")]
        public List<StageBindingModel>? Stages { get; set; }

    }
}
