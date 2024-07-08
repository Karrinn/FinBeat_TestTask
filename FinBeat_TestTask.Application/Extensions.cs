using FinBeat_TestTask.Application.Services.Interfaces.Item;
using FinBeat_TestTask.Application.Services.Item;
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
