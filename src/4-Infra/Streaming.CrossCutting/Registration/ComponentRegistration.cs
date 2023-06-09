using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Streaming.Application.Configuration;

namespace Streaming.CrossCutting.Registration
{
    public static class ComponentRegistration
    {
        public static void AddCrossCutting(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ILoadConfiguration>(s => new LoadConfiguration(configuration));
        }
    }
}
