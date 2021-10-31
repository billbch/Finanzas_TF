using Microsoft.Extensions.DependencyInjection;
using Cartera.DataAccess;

namespace Cartera.Services
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {

            

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IGastosFinalesRepository, GastosFinalesRepository>();
            services.AddTransient<IGastosFinalesService, GastosFinalesService>();

            services.AddTransient<IGastosInicialesRepository, GastosInicialesRepository>();
            services.AddTransient<IGastosInicialesService, GastosInicialesService>();

            services.AddTransient<IPortolioRepository, PortfolioRepository>();
            services.AddTransient<IPortfolioService, PortfolioService>();

            services.AddTransient<IType_Interest_RateRepository, Type_Interest_RateRepository>();
            services.AddTransient<IType_Interest_RateService, Type_Interest_RateService>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IUserServiceConfirmation, UserServiceConfirmation>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services.AddScoped<IBillRepository, BIllRepository>()
                .AddScoped<IBillService, BillService>();
        }
    }
}
