using CXManagement.Application.UseCases.CustomerAppKeywordValue;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CXManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAppKeywordValueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerAppKeywordValueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCustomerAppKeywordValuesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCustomerAppKeywordValueByIdQuery { CXCAKVID = id });
            if (result == null) return NotFound();
            return Ok(result);
        }


        [HttpGet("GetCustomerAppKeywordValueViewByCustomerId/{customerId}")]
        public async Task<IActionResult> GetCustomerAppKeywordValueViewByCustomerId(int customerId)
        {
            var result = await _mediator.Send(new GetCustomerAppKeywordValueViewByCustomerIdQuery { CXCustomerID = customerId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerAppKeywordValueCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerAppKeywordValueCommand command)
        {
            if (id != command.CustomerAppKeywordValue.CXCAKVID)
                return BadRequest("ID mismatch");

            var success = await _mediator.Send(command);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteCustomerAppKeywordValueCommand { CXCAKVID = id });
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
