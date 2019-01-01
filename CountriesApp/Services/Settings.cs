namespace CountriesApp.Services
{
    public class Settings
    {
        // database
        public string ConnectionString { get; set; }
        public string Database { get; set; }

        // jwt
        public string Secret { get; set; }
    }
}
