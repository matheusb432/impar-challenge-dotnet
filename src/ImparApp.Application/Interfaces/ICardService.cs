using ImparApp.Application.Extensions;
using ImparApp.Application.ViewModels.Card;

namespace ImparApp.Application.Interfaces
{
    public interface ICardService
    {
        OperationResult Query();

        Task<OperationResult> Insert(CardPostViewModel viewModel);

        Task<OperationResult> Update(int id, CardPutViewModel viewModel);

        Task<OperationResult> Delete(int id);
    }
}
