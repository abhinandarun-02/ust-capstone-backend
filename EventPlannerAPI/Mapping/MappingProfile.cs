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
            CreateMap<Expense, ExpenseDTO>();

            // Map Service to ServiceDTO
            CreateMap<Service, ServiceDTO>()
                .ForMember(dest => dest.WeddingId, opt => opt.MapFrom(src => src.WeddingId)) // Map weddingId
                .ForMember(dest => dest.CateringId, opt => opt.MapFrom(src => src.Catering != null ? src.Catering.Id : 0))
                .ForMember(dest => dest.PhotographyId, opt => opt.MapFrom(src => src.Photography != null ? src.Photography.Id : 0))
                .ForMember(dest => dest.VenueId, opt => opt.MapFrom(src => src.Venue != null ? src.Venue.Id : 0))
                .ForMember(dest => dest.CateringDetails, opt => opt.MapFrom(src => src.Catering))
                .ForMember(dest => dest.PhotographyDetails, opt => opt.MapFrom(src => src.Photography))
                .ForMember(dest => dest.VenueDetails, opt => opt.MapFrom(src => src.Venue));

            // Map DTOs to models
            CreateMap<PhotographyDTO, Photography>();
            CreateMap<WeddingDTO, Wedding>();
            CreateMap<CateringDTO, Catering>();
            CreateMap<ExpenseDTO, Expense>();

            // Map ServiceDTO to Service
            CreateMap<ServiceDTO, Service>()
                .ForMember(dest => dest.WeddingId, opt => opt.MapFrom(src => src.WeddingId)); // Map weddingId to Service
            CreateMap<VenueDTO, Venue>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
