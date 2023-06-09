
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TvShowTracker.Application.AppServices;
using TvShowTracker.Application.AppServices.Interfaces;
using TvShowTracker.Application.Services;
using TvShowTracker.Application.Services.Interfaces;
using TvShowTracker.Infra.Data.Interfaces;
using TvShowTracker.Infra.Data.Uow;

namespace TvShowTracker.CrossCutting
{
    public static class BootStrapper
    {
        private static IServiceCollection _services;
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<ITvShowTrackerAppServices, TvShowTrackerAppServices>()
                .AddScoped<ITvShowTrackerServices, TvShowTrackerServices>();

            _services = services;
            return services;
        }
        public static IServiceCollection AddAInfraServices(this IServiceCollection services)
        {
            services
                .AddScoped<IUnitOfWork, UnitOfWork>();
            _services = services;
            return services;
        }
    }
}
