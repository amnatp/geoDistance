
using Microsoft.AspNetCore.Mvc;
using geodisplacement.Models;
using geodisplacement.Models.Dto;
using geodisplacement.Services;

namespace geodisplacement;
public class DisplacementController : ControllerBase
{

    [HttpPost("distanceBetween")]
    public IActionResult GetDistanceBetween([FromBody] PlacePair pointPair)
    {
        double distance = GeoService.CalculateDisplacement(pointPair.StartPoint, pointPair.EndPoint);
        return Ok(distance);

    }

    [HttpPost("findFarthestPoint")]
    public IActionResult findFarthestPoint([FromBody] PlaceAndItsNeighbor points )
    {
        Place point = GeoService.FindFarthestPoint(points);
        return Ok(point);

    }

}