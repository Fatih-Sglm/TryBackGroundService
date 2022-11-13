using TryBackGroundService.Context;
using TryBackGroundService.QueueServices;
using TryBackGroundService.Repository;
using TryBackGroundService.Services;
using TryBackGroundService.Services.PersonService;

namespace TryBackGroundService.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddHostedService<QueueService>();
            services.AddDbContext<BaseDbContext>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddSingleton(typeof(IQueueService<>), typeof(QueueService<>));
            services.AddLogging(opt =>
            {
                opt.AddConsole();
                opt.AddDebug();
            });
        }
    }
}
