using Flow_1Provider.Interface;
using Microsoft.Azure.Cosmos;

namespace Flow_1Provider.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly IConfiguration _config;
        public UtilityService(IConfiguration config)
        {
            _config = config;            
        }


        
        public List<string> GetQuestionTypes()
        {
            // Read the configuration section
            return _config.GetSection("QuestionTypes").Get<List<string>>();

        }

        public List<string> GetStageTypes()
        {
            return _config.GetSection("StageTypes").Get<List<string>>();
        }
    }
}
