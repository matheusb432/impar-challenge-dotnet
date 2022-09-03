namespace ImparApp.Domain.Models
{
    public class Photo : Entity
    {
        public string Base64 { get; set; } = string.Empty;

        public Card? Card { get; set; }

        public static Photo None() => new();
    }
}
