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
    public class WorkFlowController : ControllerBase
    {
        private readonly IProgramService programService; 
        private readonly IUtilityService utilityService;
        private readonly IMapper _mapper;

        public WorkFlowController(IProgramService programService, IMapper mapper, IUtilityService utilityService)
        {
            this.programService = programService;
            this._mapper = mapper;
            this.utilityService = utilityService;
        }

        [HttpGet, Route("getStageTypes")]
        public ActionResult<List<string>> GetStageTypes()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var stageTypes = utilityService.GetStageTypes();
            if (stageTypes == null)
            {
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Unable to fetch stages", false, 0));

            }

            return Ok(new ResponseToUser<List<string>>(stageTypes, _mapper, "Stage Types was successfully fetched", true, 1));

        }


        [HttpGet, Route("getSingle")]
        public async Task<ActionResult<Stage>> GetWorkFlow([FromQuery] string programId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var program = await programService.GetById(programId);
            if (program == null)
            {
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Unable to work flow ", false, 0));
            }

            var ivm = _mapper.Map<List<Stage>>(program.Stages);

            return Ok(new ResponseToUser<List<StageViewModel>>(ivm, _mapper, "Work flow was successfully fetched", true, 1));
        }

        [HttpPut, Route("update")]
        public async Task<ActionResult<Stage>> Update(StageUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var stages = _mapper.Map<List<Stage>>(model.Stages);


            var prog = await programService.GetById(model.ProgramsId);

            if (prog == null)
            {
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Unable to update WorkFlow", false, 0));
            }

            var createdWorkFlow = await programService.UpdateWorkFlow(stages, prog.ProgramsId);

            return Ok(new ResponseToUser<List<StageViewModel>>(createdWorkFlow, _mapper, "Stages was successfully updated", true, 1));
        }
    }
}
