using CXManagement.Application.UseCases.JourneyEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CXManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyEventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JourneyEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllJourneyEventsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetJourneyEventByIdQuery { CXCJEID = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJourneyEventCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJourneyEventCommand command)
        {
            if (id != command.JourneyEventDto.CXCJEID)
                return BadRequest("ID mismatch");

            var success = await _mediator.Send(command);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteJourneyEventCommand { CXCJEID = id });
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
