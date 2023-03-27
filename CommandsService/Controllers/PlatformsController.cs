using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;

[Route("api/command/[controller]")]
[ApiController]
public class PlatformsController: ControllerBase
{
    public PlatformsController()
    {
        
    }

    [HttpPost]
    public ActionResult TestInboundConnection()
    {
        Console.WriteLine("==> Inbound post # Command Service");
        return Ok("Inbound test from Platforms Controller");
    }
}