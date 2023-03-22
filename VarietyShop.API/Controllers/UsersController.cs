using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VarietyShop.Application.Commands.CreateUser;
using VarietyShop.Application.Commands.DeleteUser;
using VarietyShop.Application.Commands.LoginUser;
using VarietyShop.Application.Commands.UpdateUser;
using VarietyShop.Application.Queries.GetAllUsers;
using VarietyShop.Application.Queries.GetUserById;

namespace VarietyShop.API.Controllers;

[ApiController]
[Route("v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "admin")]

    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();

        var users = await _mediator.Send(query);

        return Ok(users);
    }

    [HttpGet("id:int")]
    [Authorize(Roles = "admin")]

    public async Task<IActionResult> GetUserById(int id)
    {
        var query = new GetUserByIdQuery(id);

        var user = await _mediator.Send(query);

        return Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]

    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetUserById), new { id }, command);
    }

    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("id:int")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("login")]
    [AllowAnonymous]

    public async Task<IActionResult> Login([FromBody] LoginUserCommand login)
    {
        return Ok(await _mediator.Send(login));
    }
}
