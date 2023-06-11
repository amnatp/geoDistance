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

