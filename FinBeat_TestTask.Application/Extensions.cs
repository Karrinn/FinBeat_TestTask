using FinBeat_TestTask.Application.Services;
using FinBeat_TestTask.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FinBeat_TestTask.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddScoped<IItemService, ItemService>();

            return services;
        }
    }
}
