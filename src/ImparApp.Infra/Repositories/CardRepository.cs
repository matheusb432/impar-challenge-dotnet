using ImparApp.Domain.Models;
using ImparApp.Infra.Interfaces;

namespace ImparApp.Infra.Repositories
{
    internal class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(ImparContext context) : base(context)
        {
        }
    }
}
