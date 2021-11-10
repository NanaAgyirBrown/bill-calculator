namespace BillPayment.Helpers
{
    public class Settings
    {
        private static IConfiguration Configuration;

        static Settings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }


        public static string DbName => Configuration["Database:DatabaseName"];
    }
}
