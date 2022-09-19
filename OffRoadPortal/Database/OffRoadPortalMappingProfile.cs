/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: OffRoadPortalMappingProfile.cs                    //
/////////////////////////////////////////////////////////////

using AutoMapper;
using OffRoadPortal.Entities;
using OffRoadPortal.Models;

namespace OffRoadPortal.Database;

public class OffRoadPortalMappingProfile : Profile
{
    public OffRoadPortalMappingProfile()
    {
        //UserEvent Mapping
        CreateMap<User, User_Event>()
            .ForMember(ue => ue.UserId, x => x.MapFrom(u => u.Id))
            .ReverseMap();
        CreateMap<Event, User_Event>()
            .ForMember(ue => ue.EventId, x => x.MapFrom(e => e.Id));

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
