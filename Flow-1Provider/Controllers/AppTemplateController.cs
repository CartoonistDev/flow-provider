using AutoMapper;
using Flow_1Provider.BindingModels;
using Flow_1Provider.data;
using Flow_1Provider.Interface;
using Flow_1Provider.Models;
using Flow_1Provider.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Flow_1Provider.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AppTemplateController : ControllerBase
    {
        private readonly IProgramService programService;
        private readonly IUtilityService utilityService;
        private readonly IMapper _mapper;

        public AppTemplateController(IProgramService programService, IMapper mapper, IUtilityService utilityService)
        {
            this.programService = programService;
            _mapper = mapper;
            this.utilityService = utilityService;
        }

        [HttpGet, Route("getQuestionTypes")]
        public ActionResult<List<string>> GetQuestionTypes()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var questionTypes = utilityService.GetQuestionTypes();
            if (questionTypes == null)
            {
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Unable to fetch questionTypes", false, 0));

            }

            return Ok(new ResponseToUser<List<string>>(questionTypes, _mapper, "Question Types was successfully fetched", true, 1));
        }


        [HttpGet, Route("getSingle")]
        public async Task<ActionResult<AppTemplate>> GetAppTemplate([FromQuery] string programId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var program = await programService.GetById(programId);
            if (program == null)
            {
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Unable to fetch Application Template", false, 0));
            }

            var ivm = _mapper.Map<AppTemplate>(program.AppTemplate);

            return Ok(new ResponseToUser<AppTemplateViewModel>(ivm, _mapper, "Application Template was successfully fetched", true, 1));
        }


        [HttpPut, Route("update")]
        public async Task<ActionResult<AppTemplate>> Update(AppTemplateUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var app = _mapper.Map<AppTemplate>(model.AppTemplate);


            var prog = await programService.GetById(model.ProgramsId);

            if (prog == null)
            {
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Unable to update application", false, 0));

            }

            var createdAppTemplate = await programService.UpdateApplicationForm(app);

            return Ok(new ResponseToUser<AppTemplateViewModel>(createdAppTemplate, _mapper, "Application was successfully added", true, 1));
        }
    }
}
