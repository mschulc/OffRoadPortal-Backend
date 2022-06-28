/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CarService.cs                                     //
/////////////////////////////////////////////////////////////

using AutoMapper;
using OffRoadPortal.Dtos;
using OffRoadPortal.Entities;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class CarService : ICarService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;

    public CarService(OffRoadPortalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public CarDto GetById(long id)
    {
        var car = _dbContext.Cars.FirstOrDefault(c => c.Id == id);

        if (car is null) return null;

        var result = _mapper.Map<CarDto>(car);
        return result;
    }

    public IEnumerable<CarDto> GetAll()
    {
        var cars = _dbContext.Cars.ToList();

        var result = _mapper.Map<List<CarDto>>(cars);

        return result;
    }

    public long Create(CreateCarDto dto)
    {
        var car = _mapper.Map<Car>(dto);
        _dbContext.Cars.Add(car);
        _dbContext.SaveChanges();
        return car.Id;
    }

    public bool Delete(long id)
    {
        var car = _dbContext.Cars.FirstOrDefault(c => c.Id == id);

        if (car is null) return false;

        _dbContext.Cars.Remove(car);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Update(long id, UpdateCarDto dto)
    {
        var car = _dbContext.Cars.FirstOrDefault(c => c.Id == id);

        if (car is null) return false;

        _mapper.Map<Car>(dto);
        _dbContext.SaveChanges();
        return true;
    }
}
