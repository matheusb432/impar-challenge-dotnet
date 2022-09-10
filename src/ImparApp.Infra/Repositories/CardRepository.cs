using ImparApp.Domain.Models;
using ImparApp.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImparApp.Infra.Repositories
{
    internal class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(ImparContext context) : base(context)
        {
        }

        public override async Task<Card?> GetByIdAsync(long id) 
            => await _dbSet
                .Include(c => c.Photo)
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Card?> GetByPhotoIdAsync(long photoId)
            => await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.PhotoId == photoId);
    }
}
