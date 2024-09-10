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
            CreateMap<Catering, CateringDTO>();
            CreateMap<Photography, PhotographyDTO>();
            CreateMap<Venue, VenueDTO>();
            CreateMap<Wedding, WeddingDTO>();

            // Map Service to ServiceDTO
            CreateMap<Service, ServiceDTO>()
                .ForMember(dest => dest.WeddingName, opt => opt.MapFrom(src => src.Wedding != null ? src.Wedding.Name : string.Empty))
                .ForMember(dest => dest.weddingId, opt => opt.MapFrom(src => src.WeddingId)) // Map weddingId
                .ForMember(dest => dest.CateringName, opt => opt.MapFrom(src => src.Catering != null ? src.Catering.Name : string.Empty))
                .ForMember(dest => dest.PhotographyName, opt => opt.MapFrom(src => src.Photography != null ? src.Photography.Name : string.Empty))
                .ForMember(dest => dest.VenueName, opt => opt.MapFrom(src => src.Venue != null ? src.Venue.Name : string.Empty))
                .ForMember(dest => dest.CateringDetails, opt => opt.MapFrom(src => src.Catering))
                .ForMember(dest => dest.PhotographyDetails, opt => opt.MapFrom(src => src.Photography))
                .ForMember(dest => dest.VenueDetails, opt => opt.MapFrom(src => src.Venue));

            // Map DTOs to models
            CreateMap<CateringDTO, Catering>();
            CreateMap<PhotographyDTO, Photography>();
            CreateMap<VenueDTO, Venue>();
            CreateMap<WeddingDTO, Wedding>();

            // Map ServiceDTO to Service
            CreateMap<ServiceDTO, Service>()
                .ForMember(dest => dest.WeddingId, opt => opt.MapFrom(src => src.weddingId)); // Map weddingId to Service
        }
    }
}
