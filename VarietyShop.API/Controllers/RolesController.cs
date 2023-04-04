using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VarietyShop.Application.Commands.Roles.CreateRole;
using VarietyShop.Application.Commands.Roles.DeleteRole;
using VarietyShop.Application.Queries.Roles.GetAllRoles;
using VarietyShop.Application.Queries.Roles.GetRoleById;

namespace VarietyShop.API.Controllers
{
    [ApiController]
    [Route("v1/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll() 
        {
            var query = new GetAllRolesQuery();

            var roles = await _mediator.Send(query);

            return Ok(roles);
        }

        [HttpGet("id:int")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetRoleByIdQuery(id);

            var role = await _mediator.Send(query);

            return Ok(role);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([FromBody]CreateRoleCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpDelete("id:int")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Disable([FromRoute]int id)
        {
            var command = new DeleteRoleCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
