using AutoMapper;
using Catedra3Backend.Src.DTOs;
using Catedra3Backend.Src.Models;

namespace Catedra3Backend.Src.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<Post, PostResponseDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate.ToString("dd/MM/yyyy HH:mm")));

            CreateMap<CreatePostDto, Post>()
                .ForMember(dest => dest.PublishedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
        }
    }
}