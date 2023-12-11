using ActionFilterSample.Repositories;

namespace ActionFilterSample
{
    public static class StartupServiceExtension
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
