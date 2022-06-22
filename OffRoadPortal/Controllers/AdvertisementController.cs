/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: AdvertisementController.cs                        //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Dtos;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/advert")]
public class AdvertisementController : ControllerBase
{
    private readonly IAdvertisementService _advertService;

    public AdvertisementController(IAdvertisementService advertService)
    {
        _advertService = advertService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AdvertisementDto>> GetAll()
    {
        var adverts = _advertService.GetAll();
        return Ok(adverts);
    }

    [HttpGet("{id})")]
    public ActionResult<AdvertisementDto> GetById([FromRoute] long id)
    {
        var advert = _advertService.GetById(id);
        if (advert == null) return NotFound();
        return Ok(advert);
    }

    [HttpPost]
    public ActionResult CreateEvent([FromBody] CreateAdvertisementDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdAdvertId = _advertService.Create(dto);

        return Created($"/advert/{createdAdvertId}", null);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] long id)
    {
        var isDeleted = _advertService.Delete(id);

        if (isDeleted) return NoContent();
        else return NotFound();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromBody] UpdateAdvertisementDto dto, [FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isUpdated = _advertService.Update(id, dto);

        if (!isUpdated) return NotFound();
        return Ok();
    }
}
