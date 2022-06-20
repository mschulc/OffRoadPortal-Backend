/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: OffRoadPortalMappingProfile.cs                    //
/////////////////////////////////////////////////////////////

using AutoMapper;
using OffRoadPortal.Dtos;
using OffRoadPortal.Entities;

namespace OffRoadPortal.Services;

public class OffRoadPortalMappingProfile : Profile
{
    public OffRoadPortalMappingProfile()
    {
        CreateMap<User, UserDto>();
        
        CreateMap<Advertisement, AdvertisementDto>();

        CreateMap<Article, ArticleDto>(); 

        CreateMap<Event, EventDto>();

        CreateMap<ArticleComment, ArticleCommentDto>();

        CreateMap<EventComment, EventCommentDto>();

        CreateMap<Car, CarDto>();

        CreateMap<Image, ImageDto>();
    }
}
