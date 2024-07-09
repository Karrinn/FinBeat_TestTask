using FinBeat_TestTask.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Serilog;
using FinBeat_TestTask.Infrastructure.Repositories;
using FinBeat_TestTask.Infrastructure.DataBase;
using FinBeat_TestTask.Domain.Repositories;

namespace FinBeat_TestTask.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqliteConnectionString")
                ?? throw new ArgumentNullException("Sqlite connection string is missing.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString,
                    sqlOpts => sqlOpts.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name))
            );

            services.AddSerilog((services, lc) => lc
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console());

            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddCors(opts => { opts.AddDefaultPolicy(p => p.WithOrigins("*")); });
            services.AddResponseCaching();

            return services;
        }
        
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();

            app.UseCors(x =>
                x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseResponseCaching();

            app.UseMiddleware<RequestLoggerMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<ResponseLoggerMiddleware>();

            return app;
        }
    }
}
