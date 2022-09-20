using AutoMapper;
using ImparApp.Application.ViewModels.Photo;
using ImparApp.Domain.Models;

namespace ImparApp.Application.Profiles
{
    public sealed class PhotoProfiles : Profile
    {
        public PhotoProfiles()
        {
            CreateMap<Photo, PhotoViewModel>();
            CreateMap<PhotoPostViewModel, Photo>();
            CreateMap<PhotoPutViewModel, Photo>();
        }
    }
}
