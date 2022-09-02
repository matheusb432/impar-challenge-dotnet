﻿namespace ImparApp.Domain.Models
{
    public class Card : BaseEntity
    {
        public int PhotoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public Photo Photo { get; set; } = Photo.None();

        public static Card None() => new ();
    }
}