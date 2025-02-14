using AztroWebApplication.Models;
using AztroWebApplication.Data;
using AztroWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace AztroWebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]


public class UserController : ControllerBase
{
    private readonly UserService userService;

    public UserController(ApplicationDbContext context)
    {
        userService = new UserService(context);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.GetUserById(id);
        if (user == null)
        {
            return NotFound(new ErrorResponse { Message = "User not found", StatusCode = 404 });
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        var createdUser = await userService.CreateUser(user);
        return Created(nameof(GetUserById), createdUser);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUserById(int id)
    {
        // Update the user in the database
        // For demonstration purposes, we are returning the updated user
        return Ok("User updated successfully by id: " + id);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(int id)
    {
        // Delete the user from the database
        return Ok("User deleted successfully by id: " + id);
    }
}
