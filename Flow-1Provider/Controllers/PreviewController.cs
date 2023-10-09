using AutoMapper;
using Flow_1Provider.data;
using Flow_1Provider.Interface;
using Flow_1Provider.Models;
using Flow_1Provider.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Flow_1Provider.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly IProgramService programService;
        private readonly IMapper _mapper;

        public PreviewController(IProgramService programService, IMapper mapper)
        {
            this.programService = programService;
            this._mapper = mapper;
        }


        [HttpGet, Route("getPreview")]
        public async Task<ActionResult<Stage>> GetPreview([FromQuery] string programId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Some field(s) are not valid", false, 0));

            var program = await programService.GetById(programId);
            if (program == null)
            {
                return BadRequest(new ResponseToUser<string>(null, _mapper, "Unable to fetch Preview", false, 0));
            }

            return Ok(new ResponseToUser<ProgramPreviewViewModel>(program, _mapper, "Preview was successfully fetched", true, 1));
        }

    }
}
