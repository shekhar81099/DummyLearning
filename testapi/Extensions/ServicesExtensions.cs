using Microsoft.EntityFrameworkCore.Metadata.Internal;
using testapi.Services;

namespace testapi.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            // services.AddScoped<ISuperheroeservice, Superheroeservice>(); // Adds services for the Superheroeservice
            // services.AddScoped<ISuperheroeservice, Superheroeservice2>(); // Adds services for the Superheroeservice

            services.AddScoped<Superheroeservice>();
            services.AddScoped<Superheroeservice2>();
            
            services.AddScoped<Func<string, ISuperheroeservice>>(provider => Key =>
            {
                // return provider.GetRequiredService<Superheroeservice>();
                return Key switch
                {
                    "Superheroeservice" => provider.GetRequiredService<Superheroeservice>(),
                    "Superheroeservice2" => provider.GetRequiredService<Superheroeservice2>(),
                    _ => provider.GetRequiredService<Superheroeservice>()
                };

            });

            services.AddScoped<ISuperVillainService, SuperVillainService>(); // Adds services for the SuperVillainService

            services.AddScoped<IAdminService, AdminService>(); // Adds services for the AdminService

        }

    }
}