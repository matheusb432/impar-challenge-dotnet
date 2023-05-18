namespace ImparApp.Infra.Utils
{
    public static class InfraUtils
    {
        public static readonly string DefaultConnectionName = "ImparConnection";
        public static readonly string DefaultConnection =
            "Server=.\\SQLEXPRESS;Database=ImparDB;Trusted_Connection=True;";

        public static string GetEnv(string key) =>
            Environment.GetEnvironmentVariable(key) ?? string.Empty;
    }
}
