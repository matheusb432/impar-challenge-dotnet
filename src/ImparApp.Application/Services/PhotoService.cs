using System.Net;
using AutoMapper;
using ImparApp.Application.Extensions;
using ImparApp.Application.Extensions.ViewModels;
using ImparApp.Application.Interfaces;
using ImparApp.Application.Utils;
using ImparApp.Application.ViewModels.Photo;
using ImparApp.Domain.Models;
using ImparApp.Infra.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ImparApp.Application.Services
{
    public class PhotoService : Service, IPhotoService
    {
        private readonly IPhotoRepository _repo;

        public PhotoService(IPhotoRepository repo, IMapper mapper) : base(mapper)
        {
            _repo = repo;
        }

        public OperationResult Query() => Success(Mapper.ProjectTo<PhotoViewModel>(_repo.Query()));

        public async Task<OperationResult> Insert(IFormFile image)
        {
            if (!(image?.Length > 0))
                return Error();

            var photo = Photo.FromBase64(ApplicationUtils.ConvertImageToBase64(image));

            await _repo.InsertAsync(photo);

            return Success(photo.Id);
        }

        public async Task<OperationResult> Update(int id, IFormFile image)
        {
            if (!(image?.Length > 0))
                return Error();

            var photoBase64 = ApplicationUtils.ConvertImageToBase64(image);

            var entity = await _repo.GetByIdAsNoTrackingAsync(id);

            if (entity is null)
                return Error(HttpStatusCode.NotFound);

            entity.Base64 = photoBase64;

            await _repo.UpdateAsync(entity);
            return Success();
        }

        public async Task<OperationResult> Delete(int id)
        {
            var entity = await _repo.GetByIdAsNoTrackingAsync(id);

            if (entity is null)
                return Error(HttpStatusCode.NotFound);

            await _repo.DeleteAsync(entity);
            return Success();
        }
    }
}
