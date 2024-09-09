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

            // Map DTOs to models
            CreateMap<CateringDTO, Catering>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<PhotographyDTO, Photography>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<VenueDTO, Venue>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<WeddingDTO, Wedding>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // Map Service to ServiceDTO
            CreateMap<Service, ServiceDTO>()
                .ForMember(dest => dest.WeddingName, opt => opt.MapFrom(src => src.Wedding != null ? src.Wedding.Name : ""))
                .ForMember(dest => dest.CateringName, opt => opt.MapFrom(src => src.Catering != null ? src.Catering.Name : ""))
                .ForMember(dest => dest.PhotographyName, opt => opt.MapFrom(src => src.Photography != null ? src.Photography.Name : ""))
                .ForMember(dest => dest.VenueName, opt => opt.MapFrom(src => src.Venue != null ? src.Venue.Name : ""));

            // Map ServiceDTO to Service
            CreateMap<ServiceDTO, Service>()
                .ForMember(dest => dest.Wedding, opt => opt.Ignore())
                .ForMember(dest => dest.Catering, opt => opt.Ignore())
                .ForMember(dest => dest.Photography, opt => opt.Ignore())
                .ForMember(dest => dest.Venue, opt => opt.Ignore());
        }
    }
}
