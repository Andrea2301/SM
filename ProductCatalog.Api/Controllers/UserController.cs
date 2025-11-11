using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application;
using ProductCatalog.Application.Dtos;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly UserService _userService;
    
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // get user by id 
    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetUserById(id);
        
        if (user ==  null)
            return NotFound(new {message = "User not found"});
        
        return Ok(user);
        
    }

    // Get all user 
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var user = await _userService.GetAllUsers();
        return Ok(user);
    }

      //Create a new user 
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateDto userCreateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User
        {
            Username = userCreateDto.Username,
            Email = userCreateDto.Email,
            Password = userCreateDto.Password,

        };
        
        var createUser = await _userService.AddUser(user);
        return CreatedAtAction(nameof(GetById), new { id = createUser.Id }, createUser);
    }

    [HttpPut("Update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserCreateDto userCreateDto)
    {
        if (ModelState.IsValid)
            return BadRequest(ModelState);

        var exist = await _userService.GetUserById(id);
        if (exist == null)
            return NotFound(new { message = $"Error updating user {id}" });
        
        exist.Username =  userCreateDto.Username;
        exist.Email = userCreateDto.Email;
        exist.Password = userCreateDto.Password;

        var updated = await _userService.UpdateUser(exist);
        
        if (!updated )
            return NotFound(new { message = $"Error updating user {id}" });
        return Ok(updated);
    }

    // Delete user by ID

    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _userService.DeleteUser(id);
        
        if (!deleted)
            return NotFound(new { message = $"Error deleting user {id}" });
        return Ok(deleted);
    }
}