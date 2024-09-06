using AutoMapper;
using EventPlannerAPI.Models;
using EventPlannerAPI.DTOs;

namespace EventPlannerAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            // Map models to DTOs
            CreateMap<Booking, BookingDTO>()
                .ForMember(dest => dest.WeddingName, opt => opt.MapFrom(src => src.Wedding.Name));
            CreateMap<CancelledEvent, CancelledEventDTO>();
            CreateMap<Catering, CateringDTO>();
            CreateMap<Photography, PhotographyDTO>();
            CreateMap<Venue, VenueDTO>();
            CreateMap<Wedding, WeddingDTO>();

            // Map DTOs to models
            CreateMap<BookingDTO, Booking>()
                .ForMember(dest => dest.Wedding, opt => opt.Ignore()); 
            CreateMap<CancelledEventDTO, CancelledEvent>()
                .ForMember(dest => dest.BookingId, opt => opt.Ignore()); 
            CreateMap<CateringDTO, Catering>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            CreateMap<PhotographyDTO, Photography>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            CreateMap<VenueDTO, Venue>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            CreateMap<WeddingDTO, Wedding>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
        }
    }
}
