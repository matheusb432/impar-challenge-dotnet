using System.Net;
using AutoMapper;
using ImparApp.Application.Extensions;
using ImparApp.Application.Interfaces;
using ImparApp.Application.ViewModels.Photo;
using ImparApp.Domain.Models;
using ImparApp.Domain.Models.Validators;
using ImparApp.Infra.Interfaces;

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

        public async Task<OperationResult> Insert(PhotoPostViewModel viewModel)
        {
            var entity = Mapper.Map<Photo>(viewModel);
            if (!EntityIsValid(new PhotoValidator(), entity))
                return Error();

            await _repo.InsertAsync(entity);
            return Success(entity.Id);
        }

        public async Task<OperationResult> Update(int id, PhotoPutViewModel viewModel)
        {
            var entity = Mapper.Map<Photo>(viewModel);

            if (!EntityIsValid(new PhotoValidator(), entity))
                return Error(HttpStatusCode.BadRequest);

            entity.Id = id;

            var entityFromDb = await _repo.GetByIdAsNoTrackingAsync(id);


            if (entityFromDb is null)
                return Error(HttpStatusCode.NotFound);

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
