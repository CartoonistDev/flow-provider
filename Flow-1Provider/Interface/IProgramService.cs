using Flow_1Provider.data;

namespace Flow_1Provider.Interface
{
    public interface IProgramService
    {
        Task<dynamic> Add(Programs program);
        Task<Programs> GetById(string programId);
        Task<Programs> Update(Programs program);
        Task<List<Stage>> UpdateWorkFlow(List<Stage> stage, string ProgramsId);
        Task<AppTemplate> UpdateApplicationForm(AppTemplate appTemplate);
    }
}
