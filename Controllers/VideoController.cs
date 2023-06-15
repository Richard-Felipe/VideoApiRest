using ApiRest.Data;
using ApiRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controllers;

[ApiController]
public class VideoController : ControllerBase
{
    [HttpGet("/videos")]
    public async Task<IActionResult> Get([FromServices] VideoContext context) 
        => Ok(await context.Videos.AsNoTracking().ToListAsync());
}
