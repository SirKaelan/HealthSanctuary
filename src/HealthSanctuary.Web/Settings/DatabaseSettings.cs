using HealthSanctuary.Data.Settings;

namespace HealthSanctuary.Web.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
    }
}
