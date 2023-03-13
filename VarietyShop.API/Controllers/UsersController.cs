using Microsoft.AspNetCore.Mvc;
using VarietyShop.Domain.InputModels;
using VarietyShop.Domain.Interfaces.Services;

namespace VarietyShop.API.Controllers;

[Route("v1/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]

    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsers();

        return Ok(users);
    }

    [HttpGet("id:int")]

    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetById(id);

        return Ok(user);
    }

    [HttpPost]

    public async Task<IActionResult> Create(CreateUserInputModel inputModel)
    {
        var id = await _userService.Create(inputModel);

        return CreatedAtAction(nameof(GetById), new { id }, inputModel);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserInputModel inputModel)
    {
        await _userService.Update(inputModel);

        return NoContent(); 
    }

    [HttpPut]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.Delete(id);

        return NoContent();
    }
}
