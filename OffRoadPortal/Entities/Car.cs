/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: Car.cs                                            //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Enums;

namespace OffRoadPortal.Entities;

public class Car
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Mark { get; set; }
    public string? Model { get; set; }
    public short? Year { get; set; }
    public short? Engine { get; set; }
    public FuelType Fuel { get; set; }
    public string? Description { get; set; }
}
