using ImparApp.Application.ViewModels.Photo;

namespace ImparApp.Application.ViewModels.Card
{
    public class CardPostViewModel
    {
        public int PhotoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
