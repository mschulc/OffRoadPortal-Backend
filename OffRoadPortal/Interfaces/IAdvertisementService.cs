/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: IAdvertisementService.cs                          //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Dtos;
using OffRoadPortal.Models;

namespace OffRoadPortal.Interfaces
{
    public interface IAdvertisementService
    {
        long Create(CreateAdvertisementDto dto);
        bool Delete(long id);
        IEnumerable<AdvertisementDto> GetAll();
        AdvertisementDto GetById(long id);
        bool Update(long id, UpdateAdvertisementDto dto);
    }
}