using geodisplacement.Models;
using geodisplacement.Models.Dto;
namespace geodisplacement.Services;
public class GeoService
{
    public static double CalculateDisplacement(Place startPoint, Place endPoint)
    {
        const double r = 6371.0; // Radius of the earth in kilometers. Use 3956 for miles

        // Convert to radians

        double dLat = endPoint.Latitude - startPoint.Latitude;
        double dLon = endPoint.Longtitude - startPoint.Longtitude;

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(startPoint.Latitude) * Math.Cos(endPoint.Latitude) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return r * c;
    }

    public static Place FindFarthestPoint(PlaceAndItsNeighbor points)
    {
        Place farthestPoint = points.StartPoint;
        double farthestDistance = 0D;
        foreach(Place candidatePoint in points.Points) {
            double currentDistance = CalculateDisplacement(points.StartPoint, candidatePoint);
            if( currentDistance > farthestDistance) {
                farthestPoint = candidatePoint;
                farthestDistance = currentDistance;
            }
             
        }
        return farthestPoint;

    }

    private static double DegreesToRadians(double degrees)
    {
        return degrees * (Math.PI / 180);
    }
}