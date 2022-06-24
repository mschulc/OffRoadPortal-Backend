/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ICarService.cs                                    //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Dtos;
using OffRoadPortal.Models;

namespace OffRoadPortal.Interfaces;

public interface ICarService
{
    long Create(CreateCarDto dto);
    bool Delete(long id);
    IEnumerable<CarDto> GetAll();
    CarDto GetById(long id);
    bool Update(long id, UpdateCarDto dto);
}