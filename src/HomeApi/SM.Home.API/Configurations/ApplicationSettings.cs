using SM.Identity.API.Client;

namespace SM.Home.API.Configurations
{
    public class ApplicationSettings
    {
        public IdentityClientSettings IdentityClientSettings { get; set; }

        public string SecretKey { get; set; }
    }
}
