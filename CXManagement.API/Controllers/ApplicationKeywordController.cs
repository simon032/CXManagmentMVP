using CXManagement.Application.UseCases.ApplicationKeyword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CXManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationKeywordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationKeywordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllApplicationKeywordsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetApplicationKeywordByIdQuery { CXAKID = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApplicationKeywordCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateApplicationKeywordCommand command)
        {
            if (id != command.ApplicationKeyword.CXAKID)
                return BadRequest("ID mismatch");

            var success = await _mediator.Send(command);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteApplicationKeywordCommand { CXAKID = id });
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
