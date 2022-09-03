using ImparApp.Application.ViewModels.Photo;

namespace ImparApp.Application.ViewModels.Card
{
    public class CardPutViewModel
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public PhotoPutViewModel Photo { get; set; } = null!;
    }
}
