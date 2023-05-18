namespace ImparApp.Tests.E2E.Utils
{
    public static class PageUrls
    {
        public static readonly string BaseUrl = "http://localhost:3000";
        public static readonly string HomeUrl = BaseUrl;
        public static readonly string CardsUrl = $"{BaseUrl}/cards";
        public static readonly string CardsCreateUrl = $"{CardsUrl}/create";
        public static readonly string CardsEditUrl = $"{CardsUrl}/edit";
    }
}
