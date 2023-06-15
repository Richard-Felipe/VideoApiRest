using ApiRest.Data;
using ApiRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get() => Ok();
}
