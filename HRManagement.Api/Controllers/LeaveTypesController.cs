using HRManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HRManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HRManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HRManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeQuery());
            return leaveTypes;
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<LeaveTypeDetailsDto> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
            return leaveType;
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeCommand leaveType)
        {
            var response = await _mediator.Send(leaveType);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveTypeCommand leaveType)
        {
            var response = await _mediator.Send(leaveType);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLeaveTypeCommnad() { Id = id});
            return NoContent();
        }
    }
}
