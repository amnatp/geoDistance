# GeoDisplacement Service

This repository contains the GeoDisplacement Service, a .NET-based web application designed for geographic calculations. It provides utilities for calculating distances between geographical points and finding the farthest point from a given point among a set of points.

## How it works

The solution consists of two primary parts:

### 1. GeoService

This is the core of the solution, providing essential functionalities:

* **CalculateDisplacement**: Given two geographic points (defined by latitude and longitude), this function calculates the displacement or the distance between them using the haversine formula.

* **FindFarthestPoint**: This function accepts a geographic point and a set of other points, and finds the point in the set that is farthest from the given point.

### 2. DisplacementController

This is an ASP.NET controller exposing two HTTP POST endpoints:

* **/distanceBetween**: This endpoint accepts a pair of geographic points and calculates the distance between them. The calculated distance is returned in the response.

* **/findFarthestPoint**: This endpoint takes a point and a set of other points, finds the farthest point in the set from the given point, and returns this point in the response.

## How to use

To use the service, send a HTTP POST request to either `/distanceBetween` or `/findFarthestPoint`, depending on the operation you want to perform. The geographic points should be included in the body of the request as JSON.

## Examples

* **/distanceBetween**

  Request:
  ```json
  {
      "StartPoint": { "Latitude": 34.052235, "Longtitude": -118.243683 },
      "EndPoint": { "Latitude": 40.712776, "Longtitude": -74.005974 }
  }
  ```
  Response:
  ```
  3940.08
  ```

* **/findFarthestPoint**

  Request:
  ```json
  {
      "StartPoint": { "Latitude": 34.052235, "Longtitude": -118.243683 },
      "Points": [
          { "Latitude": 40.712776, "Longtitude": -74.005974 },
          { "Latitude": 51.507351, "Longtitude": -0.127758 },
          { "Latitude": 35.689487, "Longtitude": 139.691711 }
      ]
  }
  ```
  Response:
  ```json
  {
      "Latitude": 51.507351,
      "Longtitude": -0.127758
  }
  ```

---

Please note that you might need to adjust the examples based on the actual data structure of the `Place` and `PlacePair` objects in your application.

#Classes in projects

##Place
The Place class represents a specific geographical location. It includes the following properties:

Name (Optional): The name of the place.
PostalCode (Optional): The postal code of the place.
Latitude: The latitude of the place, a measure that specifies the north-south position of a point on the Earth's surface.
Longitude: The longitude of the place, a measure that specifies the east-west position of a point on the Earth's surface.

##PlacePair
The PlacePair class, part of the geodisplacement.Models.Dto namespace, encapsulates a pair of geographical locations. It's generally used when we want to determine the distance between two specific locations. It includes the following properties:
StartPoint: A Place object representing the starting location.
EndPoint: A Place object representing the ending location.

##PlaceAndItsNeighbor
The PlaceAndItsNeighbor class, also part of the geodisplacement.Models.Dto namespace, represents a geographical location and a set of neighboring locations. This class is typically used when we want to perform operations that involve a location and its neighbors, such as finding the farthest location from a starting point. It includes the following properties:

StartPoint: A Place object representing the initial location.
Points: A list of Place objects representing the neighboring locations.
