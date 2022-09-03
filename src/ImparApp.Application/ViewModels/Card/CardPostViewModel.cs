using ImparApp.Application.ViewModels.Photo;

namespace ImparApp.Application.ViewModels.Card
{
    public class CardPostViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public PhotoPostViewModel Photo { get; set; } = null!;
    }
}
