using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Doctor, DoctorToReturnDto>()
            .ForMember(d => d.Title , o => o.MapFrom( s => s.Title.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ImageUrlResolver>());
        }
    }
}