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
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class OffRoadPortalMappingProfile : Profile
{
    public OffRoadPortalMappingProfile()
    {
        CreateMap<User, UserDto>();
        
        CreateMap<Advertisement, AdvertisementDto>();

        CreateMap<CreateAdvertisementDto, Event>();

        CreateMap<UpdateAdvertisementDto, Event>();

        CreateMap<Article, ArticleDto>();

        CreateMap<Event, EventDto>();   

        CreateMap<CreateEventDto, Event>();

        CreateMap<UpdateEventDto, Event>();

        CreateMap<ArticleComment, ArticleCommentDto>();

        CreateMap<CreateArticleCommentDto, ArticleComment>();

        CreateMap<UpdateArticleCommentDto, ArticleComment>();

        CreateMap<EventComment, EventCommentDto>();

        CreateMap<CreateEventCommentDto, EventComment>();

        CreateMap<UpdateEventCommentDto, EventComment>();

        CreateMap<Car, CarDto>();

        CreateMap<CreateCarDto, Car>();

        CreateMap<UpdateCarDto, Car>();

        CreateMap<Image, ImageDto>();
    }
}
