using Newtonsoft.Json;

namespace Flow_1Provider.ViewModels
{
    public class AppTemplateViewModel
    {
        [JsonProperty("coverImage")]
        public string? CoverImage { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("currentResidence")]
        public string CurrentResidence { get; set; }

        [JsonProperty("idNumber")]
        public string IdNumber { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("questions")]
        public List<Dictionary<string, dynamic>>? Questions { get; set; }

        [JsonProperty("education")]
        public List<EducationViewModel>? Education { get; set; }

        [JsonProperty("workExperience")]
        public List<WorkExperienceViewModel>? WorkExperience { get; set; }

        [JsonProperty("programsId")]
        public string ProgramsId { get; set; }

    }
}
