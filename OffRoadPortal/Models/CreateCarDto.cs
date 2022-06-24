/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CreateCarDto.cs                                   //
/////////////////////////////////////////////////////////////


using OffRoadPortal.Enums;

namespace OffRoadPortal.Models;

public class CreateCarDto
{
    public string? Name { get; set; }
    public string? Mark { get; set; }
    public string? Model { get; set; }
    public short? Year { get; set; }
    public short? Engine { get; set; }
    public FuelType Fuel { get; set; }
    public string? Description { get; set; }
}
