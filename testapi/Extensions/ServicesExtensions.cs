using testapi.Services;

namespace testapi.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISuperheroeservice, Superheroeservice>(); // Adds services for the Superheroeservice
            
            services.AddScoped<ISuperVillainService, SuperVillainService>(); // Adds services for the SuperVillainService

            services.AddScoped<IAdminService, AdminService>(); // Adds services for the AdminService

        }

    }
}