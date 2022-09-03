using ImparApp.Application.Extensions;
using ImparApp.Application.ViewModels.Photo;

namespace ImparApp.Application.Interfaces
{
    public interface IPhotoService
    {
        OperationResult Query();

        Task<OperationResult> Insert(PhotoPostViewModel viewModel);

        Task<OperationResult> Update(int id, PhotoPutViewModel viewModel);

        Task<OperationResult> Delete(int id);
    }
}
