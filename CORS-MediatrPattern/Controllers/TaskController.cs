using CORS_MediatrPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CORS_MediatrPattern.Controllers
{
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public TaskController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpGet("/{Id}")]
        public async Task<IActionResult> GetDatabyId(int Id)
        {
            var result = await _mediatr.Send(new GetData.Query(Id));
            return result != null ? Ok(result) : NotFound();
        }
        [HttpPost("")]
        public async Task<IActionResult> GetDatabyId(AddData.Command command) => Ok(await _mediatr.Send(command));
    }
}
