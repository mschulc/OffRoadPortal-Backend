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
        //User Mapping

        //Article Mapping
        CreateMap<Article, ArticleDto>();
        CreateMap<CreateArticleDto, Article>();

        //Article Comments Mapping
        CreateMap<ArticleComment, ArticleCommentDto>();
        CreateMap<CreateArticleCommentDto, ArticleComment>();

        //Event Mapping
        CreateMap<Event, EventDto>();   
        CreateMap<CreateEventDto, Event>();

        //Event comment Mapping
        CreateMap<EventComment, EventCommentDto>();
        CreateMap<CreateEventCommentDto, EventComment>();

        //Car Mapping
        CreateMap<Car, CarDto>();
        CreateMap<CreateCarDto, Car>();
    }
}
