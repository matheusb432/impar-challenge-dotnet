using ImparApp.Domain.Models;
using ImparApp.Infra.Interfaces;

namespace ImparApp.Infra.Repositories
{
    internal class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(ImparContext context) : base(context) { }
    }
}
