using CXManagement.Application.UseCases.Keyword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CXManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KeywordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var keywords = await _mediator.Send(new GetAllKeywordsQuery());
            return Ok(keywords);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var keyword = await _mediator.Send(new GetKeywordByIdQuery { CXKeywordID = id });
            if (keyword == null) return NotFound();
            return Ok(keyword);
        }

        [HttpGet("GetAllKeywordsByApplicationId/{appId}")]
        public async Task<IActionResult> GetAllKeywordsByApplicationId(int appId)
        {
            var result = await _mediator.Send(new GetAllKeywordsByApplicationIdQuery { ApplicationId = appId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateKeywordCommand command)
        {
            var newId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateKeywordCommand command)
        {
            if (id != command.Keyword.CXKeywordID)
                return BadRequest("ID mismatch");

            var updated = await _mediator.Send(command);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteKeywordCommand { CXKeywordID = id });
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
