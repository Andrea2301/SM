using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application;
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


}