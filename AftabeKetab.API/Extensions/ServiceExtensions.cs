using AftabeKetab.API.Repository;
using AftabeKetab.DataModels;

namespace AftabeKetab.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddAllAftabeKetabServices(this IServiceCollection services)
        {
            services.AddScoped(_ => new AftabeKetabContext("AftabeKetabDB"));

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
