using SM.Home.API.Configurations;

namespace SM.Identity.API.Configuration
{
    public class ApplicationSettings
    {
        public ApiConfigurations ApiConfigurations { get; set; }

        public string PrivateKey { get; set; }

        public string SecureKey { get; set; }
    }
}
