using Infrastructure.SatelliteInfoProvider;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class SateliteCoordinatesController : ControllerBase
{
    private readonly ISatelliteInfoProviderService satelliteInfoProviderService;
    public SateliteCoordinatesController(ISatelliteInfoProviderService satelliteSerivce)
    {
        satelliteInfoProviderService = satelliteSerivce;
    }

    [HttpGet]
    public IActionResult Get()
     => Ok(satelliteInfoProviderService.GetSatelliteInfo());
}
