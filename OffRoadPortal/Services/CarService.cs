/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CarService.cs                                     //
/////////////////////////////////////////////////////////////

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OffRoadPortal.Dtos;
using OffRoadPortal.Entities;
using OffRoadPortal.Exceptions;
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

    public CarDto GetById(long userId, long carId)
    {
        GetUserById(userId);
        var car = GetCarById(carId, userId);

        var result = _mapper.Map<CarDto>(car);
        return result;
    }

    public List<CarDto> GetAll(long userId)
    {
        var user = GetUserById(userId);
        var result = _mapper.Map<List<CarDto>>(user.Cars);
        return result;
    }

    public long Create(long userId, CreateCarDto dto)
    {
        GetUserById(userId);
        var car = _mapper.Map<Car>(dto);
        car.UserId = userId;
        _dbContext.Cars?.Add(car);
        _dbContext.SaveChanges();
        return car.Id;
    } 

    public void Delete(long userId, long carId)
    {
        GetUserById(userId);
        var car = GetCarById(carId, userId);

        _dbContext.Cars?.Remove(car);
        _dbContext.SaveChanges();
    }

    public void Update(long userId, long carId, UpdateCarDto dto)
    {
        GetUserById(userId);
        GetCarById(carId, userId);

        var car = _mapper.Map<Car>(dto);
        _dbContext.Cars?.Update(car);
        _dbContext.SaveChanges();
    }

    private User GetUserById(long id)
    {
        var user = _dbContext.Users.Include(u => u.Cars).FirstOrDefault(u => u.Id == id);
        if (user is null)
            throw new NotFoundException("User not found");
        return user;
    }

    private Car GetCarById(long carId, long userId)
    {
        var car = _dbContext.Cars.FirstOrDefault(c => c.Id == carId);
        if (car is null || car.UserId != userId)
            throw new NotFoundException("Car not found");
        return car;
    }
}
