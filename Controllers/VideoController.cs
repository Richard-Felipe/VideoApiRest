using ApiRest.Data;
using ApiRest.Data.Dtos;
using ApiRest.Models;
using ApiRest.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controllers;

[ApiController]
public class VideoController : ControllerBase
{
    private VideoContext _context;
    private IMapper _mapper;

    public VideoController(VideoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("/videos")]
    public async Task<IActionResult> Get() 
        => Ok(await _context.Videos.AsNoTracking().ToListAsync());

    [HttpGet("/videos/{id:int}")]
    public async Task<IActionResult> GetbyId([FromRoute] int id)
    {
        var video = await _context.Videos.FirstOrDefaultAsync(video => video.Id == id);

        if (video is null)
            return NotFound();

        return Ok(video);
    }

    [HttpPost("/videos")]
    public async Task<IActionResult> Post([FromBody] CreateVideoDto videoDto)
    {
        var videoAdd = _mapper.Map<Video>(videoDto);

        await _context.Videos.AddAsync(videoAdd);
        await _context.SaveChangesAsync();

        return Created($"/videos/{videoAdd.Id}", videoDto);
    }

    [HttpPut("videos/{id:int}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateVideoDto videoDto)
    {
        var video = await _context.Videos.FirstOrDefaultAsync(x => x.Id == id);

        if (video is null)
            return NotFound();

        var videoUpdated = _mapper.Map(videoDto, video);
        _context.Videos.Update(videoUpdated);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("videos/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var video = await _context.Videos.FirstOrDefaultAsync(x => x.Id == id);

        if (video is null)
            return NotFound();

        _context.Videos.Remove(video);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
