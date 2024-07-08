using FinBeat_TestTask.Application.Services.Interfaces.Item;
using Microsoft.Extensions.DependencyInjection;

namespace FinBeat_TestTask.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IItemService, IItemService>();

            return services;
        }
    }
}
