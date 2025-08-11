using ToDoList.Application.Interfaces;
using ToDoList.Application.Services;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void ConfigureServiceLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IToDoListSingleEntryService, ToDoListSingleEntryService>();
            services.AddScoped<IToDoListService, ToDoListService>();
            services.AddScoped<IServiceManager, ServiceManager>();
        }
        public static void ConfigureRepositoryLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IToDoListSingleEntryRepository, ToDoListSingleEntryRepository>();
            services.AddScoped<IToDoListListRepository, ToDoListListRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddLazy<IToDoListListRepository>();
        }

        public static IServiceCollection AddLazy<TService>(this IServiceCollection services) where TService : class
        {
            return services.AddScoped(provider => new Lazy<TService>(() => provider.GetRequiredService<TService>()));
        }
    }
}
