using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ImageUrlResolver : IValueResolver<Doctor, DoctorToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ImageUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Doctor source, DoctorToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return _config["ApiUrl"] + "dummy.jpeg";
                   
         }
    }
}