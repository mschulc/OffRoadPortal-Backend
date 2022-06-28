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
[Route("/user/car")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CarDto>> GetAll()
    {
        var cars = _carService.GetAll();
        return Ok(cars);
    }

    [HttpGet("{id})")]
    public ActionResult<CarDto> GetById([FromRoute] long id)
    {
        var car = _carService.GetById(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpPost]
    public ActionResult CreateEvent([FromBody] CreateCarDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdCarId = _carService.Create(dto);

        return Created($"/user/car/{createdCarId}", null);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] long id)
    {
        var isDeleted = _carService.Delete(id);

        if (isDeleted) return NoContent();
        else return NotFound();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromBody] UpdateCarDto dto, [FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isUpdated = _carService.Update(id, dto);

        if (!isUpdated) return NotFound();
        return Ok();
    }
}