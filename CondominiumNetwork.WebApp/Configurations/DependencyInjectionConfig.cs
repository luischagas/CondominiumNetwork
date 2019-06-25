using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using CondominiumNetwork.DomainService;
using CondominiumNetwork.Infrastructure.DataAcess.Context;
using CondominiumNetwork.Infrastructure.DataAcess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CondominiumNetwork.WebApp.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CondominiumNetworkContext>();
            services.AddScoped<IOcurrenceService, OcurrenceService>();
            services.AddScoped<IOcurrenceRepository, OcurrenceRepository>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IWarningService, WarningService>();
            services.AddScoped<IWarningRepository, WarningRepository>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IPhotoRepository, PhotoAzureBlobRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();


            return services;
        }
    }
}
