/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ICarService.cs                                    //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Models;

namespace OffRoadPortal.Interfaces;

public interface ICarService
{
    long Create(long userId, CreateCarDto dto);
    void Delete(long userId, long carId);
    List<CarDto> GetAll(long userId);
    CarDto GetById(long userId, long carId);
    void Update(long userId, long carId, UpdateCarDto dto);
}