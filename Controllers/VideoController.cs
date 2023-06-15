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

    [HttpPut("videos/{id:int}")]
    public async Task<IActionResult> Put([FromServices] VideoContext context, [FromRoute] int id, [FromBody] Video model)
    {
        var video = await context.Videos.FirstOrDefaultAsync(x => x.Id == id);

        if (video is null)
            return NotFound();

        video.Titulo = model.Titulo;
        video.descricao = model.descricao;
        video.URL = model.URL;

        context.Videos.Update(video);
        await context.SaveChangesAsync();

        return Ok(video);
    }

    [HttpDelete("videos/{id:int}")]
    public async Task<IActionResult> Delete([FromServices] VideoContext context, [FromRoute] int id)
    {
        var video = await context.Videos.FirstOrDefaultAsync(x => x.Id == id);

        if (video is null)
            return NotFound();

        context.Videos.Remove(video);
        await context.SaveChangesAsync();

        return Ok();
    }
}
