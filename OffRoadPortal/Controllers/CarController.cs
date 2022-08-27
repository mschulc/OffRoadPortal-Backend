/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CarController.cs                                  //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Dtos;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/user/{userId}/car")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public ActionResult<List<CarDto>> GetAll(long userId)
    {
        var cars = _carService.GetAll(userId);
        return Ok(cars);
    }

    [HttpGet("{carId})")]
    public ActionResult<CarDto> GetById([FromRoute] long userId, [FromRoute] long carId)
    {
        var car = _carService.GetById(userId, carId);
        return Ok(car);
    }

    [HttpPost]
    public ActionResult CreateCar([FromRoute] long userId ,[FromBody] CreateCarDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdCarId = _carService.Create(userId, dto);
        return Created($"/user/{userId}/car/{createdCarId}", null);
    }

    [HttpDelete("{carId}")]
    public ActionResult Delete([FromRoute] long userId, [FromRoute] long carId)
    {
        _carService.Delete(userId, carId);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromRoute]long userId, [FromBody] UpdateCarDto dto, [FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _carService.Update(userId, id, dto);
        return Ok();
    }
}