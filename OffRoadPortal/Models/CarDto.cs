﻿/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CarDto.cs                                         //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Enums;

namespace OffRoadPortal.Models;

public class CarDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Mark { get; set; }
    public string? Model { get; set; }
    public short? Year { get; set; }
    public double? Engine { get; set; }
    public FuelType Fuel { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public long UserId { get; set; }
}
