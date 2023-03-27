using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var platformItems = _repository.GetAllPlatforms();
        var platforms = _mapper.Map<IEnumerable<PlatformReadDto>>(platformItems);
        return Ok(platforms);
    }
    
    [HttpGet("{id:int}" , Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platformItem = _repository.GetPlatformById(id);
        if (platformItem != null)
        {
            var platforms = _mapper.Map<PlatformReadDto>(platformItem);
            return Ok(platforms);
        }

        return NotFound();
    }
    
    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        var platform = _mapper.Map<Platform>(platformCreateDto);
        _repository.CreatePlatform(platform);
        _repository.SaveChanges();
        
        var platformReadDto = _mapper.Map<PlatformReadDto>(platform);
        
        //it creates header parameter with created Id to GetPlatformById get link api/platform/getplatformbyId/5
        return CreatedAtRoute(nameof(GetPlatformById), new {platformReadDto.Id}, platformReadDto);
    }
}