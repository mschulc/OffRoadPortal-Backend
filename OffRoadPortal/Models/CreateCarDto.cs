/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CreateCarDto.cs                                   //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Enums;
using System.ComponentModel.DataAnnotations;

namespace OffRoadPortal.Models;

public class CreateCarDto
{
    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }

    [Required]
    public string? Mark { get; set; }

    [Required]
    public string? Model { get; set; }

    [Required]
    public short? Year { get; set; }
    public double? Engine { get; set; }
    public FuelType Fuel { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
