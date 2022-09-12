/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: AccountController.cs                              //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IUserService _userService;

    public AccountController(IAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    [HttpPost("register")]
    public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
    {
        _accountService.RegisterUser(dto);
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginUserDto dto)
    {
        UserDto token = _accountService.LoginUser(dto);
        return Ok(token);
    }

    [HttpPatch("update")]
    public ActionResult Update([FromBody] UpdateUserDto dto)
    {
        _userService.Update(dto);
        return Ok(new Response { Name = "Ok", Status = 200, Message = "Updated"});
    }

}