/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: AdvertisementService.cs                           //
/////////////////////////////////////////////////////////////

using AutoMapper;
using OffRoadPortal.Dtos;
using OffRoadPortal.Entities;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class AdvertisementService : IAdvertisementService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;

    public AdvertisementService(OffRoadPortalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public AdvertisementDto GetById(long id)
    {
        var advert = _dbContext.Advertisements.FirstOrDefault(e => e.Id == id);

        if (advert is null) return null;

        var result = _mapper.Map<AdvertisementDto>(advert);
        return result;
    }

    public IEnumerable<AdvertisementDto> GetAll()
    {
        var adverts = _dbContext.Advertisements.ToList();

        var result = _mapper.Map<List<AdvertisementDto>>(adverts);

        return result;
    }

    public long Create(CreateAdvertisementDto dto)
    {
        var advert = _mapper.Map<Advertisement>(dto);
        _dbContext.Advertisements.Add(advert);
        _dbContext.SaveChanges();
        return advert.Id;
    }

    public bool Delete(long id)
    {
        var advert = _dbContext.Advertisements.FirstOrDefault(e => e.Id == id);

        if (advert is null) return false;

        _dbContext.Advertisements.Remove(advert);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Update(long id, UpdateAdvertisementDto dto)
    {
        var advert = _dbContext.Advertisements.FirstOrDefault(e => e.Id == id);

        if (advert is null) return false;

        var result = _mapper.Map<Advertisement>(dto);
        _dbContext.SaveChanges();
        return true;
    }
}
