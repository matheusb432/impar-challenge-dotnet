using ImparApp.Domain.Models;

namespace ImparApp.Infra.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<Card?> GetByPhotoIdAsync(long photoId);
    }
}
