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
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService programService;
        private readonly IMapper _mapper;

        public ProgramController(IProgramService programService, IMapper mapper)
        {
            this.programService = programService;
            _mapper = mapper;
        }

        [HttpGet, Route("getSingle")]
        public async Task<ActionResult<Programs>> GetProgram([FromQuery] string programId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var program = await programService.GetById(programId);
            if (program == null)
            {
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Unable to fetch program", false, 0));
            }

            return Ok(new ResponseToUser<ProgramViewModel>(program, _mapper, "Program was successfully fetched", true, 1));
        }

        [HttpPost, Route("add")]
        public async Task<ActionResult<Programs>> CreateProgram(ProgramBindingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var program = _mapper.Map<Programs>(model);

            //Set any additional properties if required
            program.id = Guid.NewGuid().ToString();
            program.ProgramsId = program.id;
            program.AppTemplate.id = program.id;

            program.Stages.ForEach(s =>
            {
                s.id = Guid.NewGuid().ToString();
                s.StageType.id = s.id;
            });
            var createdProgram = await programService.Add(program);


            return Ok(new ResponseToUser<ProgramViewModel>(createdProgram, _mapper, "Program was successfully fetched", true, 1));

        }

        [HttpPut, Route("update")]
        public async Task<ActionResult<Programs>> Update(ProgramUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var map = _mapper.Map<Programs>(model.program);

            map.ProgramsId = model.ProgramsId;
            if (map == null)
            {
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Unable to update Program", false, 0));
            }

            var createdWorkFlow = await programService.Update(map);

            return Ok(new ResponseToUser<ProgramViewModel>(createdWorkFlow, _mapper, "Program was successfully added", true, 1));
        }
    }
}
