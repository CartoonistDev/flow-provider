using AutoMapper;
using Flow_1Provider.BindingModels;
using Flow_1Provider.data;
using Flow_1Provider.ViewModels;

namespace Flow_1Provider.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region AppTemplate
            CreateMap<AppTemplateBindingModel, AppTemplate>().ReverseMap(); //reverse so the both direction
            CreateMap<AppTemplate, AppTemplateViewModel>().ReverseMap();
            #endregion


            #region Programs
            CreateMap<ProgramBindingModel, Programs>().ReverseMap(); //reverse so the both direction
            CreateMap<Programs, ProgramViewModel>().ReverseMap();
            #endregion

            #region Stage
            CreateMap<StageUpdateBindingModel, Stage>().ReverseMap(); //reverse so the both direction
            CreateMap<StageBindingModel, Stage>().ReverseMap(); //reverse so the both direction
            CreateMap<Stage, StageViewModel>().ReverseMap();
            #endregion

            #region StageType
            CreateMap<StageTypeBindingModel, StageType>().ReverseMap(); //reverse so the both direction
            CreateMap<StageType, StageTypeViewModel>().ReverseMap();
            #endregion

            #region Education And WorkExperience
            CreateMap<Education, EducationViewModel>().ReverseMap(); //reverse so the both direction
            CreateMap<WorkExperience, WorkExperienceViewModel>().ReverseMap();
            #endregion
        }
    }
}