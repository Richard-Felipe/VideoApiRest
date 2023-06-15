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
    
    [HttpGet("/videos/{id:int}")]
    public async Task<IActionResult> GetbyId([FromServices] VideoContext context, [FromRoute] int id)
    {
        var video = await context.Videos.FirstOrDefaultAsync(video => video.Id == id);

        if (video is null)
            return NotFound();

        return Ok(video);
    }

    [HttpPost("/videos")]
    public async Task<IActionResult> Post([FromServices] VideoContext context, [FromBody] Video model)
    {
        await context.Videos.AddAsync(model);
        await context.SaveChangesAsync();

        return Created($"/videos/{model.Id}", model);
    }
    //[HttpPut("/")]
}
