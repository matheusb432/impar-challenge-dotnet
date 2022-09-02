namespace ImparApp.Domain.Models
{
    public class Photo : BaseEntity
    {
        public string Base64 { get; set; } = string.Empty;

        public Card Card { get; set; } = Card.None();

        public static Photo None() => new();
    }
}