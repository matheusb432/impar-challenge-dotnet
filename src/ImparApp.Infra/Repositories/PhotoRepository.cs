using ImparApp.Domain.Models;
using ImparApp.Infra.Interfaces;

namespace ImparApp.Infra.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(ImparContext context) : base(context)
        {
        }
    }
}
