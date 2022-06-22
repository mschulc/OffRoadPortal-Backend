/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UpdateAdvertisementDto.cs                         //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Enums;

namespace OffRoadPortal.Models;

public class UpdateAdvertisementDto
{
    public long SellerId { get; set; }
    public string? SellerName { get; set; }
    public double Price { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ItemCategory Category { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}
