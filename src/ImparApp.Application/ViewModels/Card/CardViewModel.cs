﻿using ImparApp.Application.ViewModels.Photo;

namespace ImparApp.Application.ViewModels.Card
{
    public sealed class CardViewModel
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public PhotoViewModel Photo { get; set; } = null!;
    }
}
