using System.Linq;
using System.Reflection;
using AutoMapper;
using FooOffer.BusinessLogic.Common.Attributes;
using FooOffer.BusinessLogic.Interfaces;
using FooOffer.BusinessLogic.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace FooOffer.BusinessLogic
{
    public static class DependencyInjection
    {
        public static IServiceCollection SetupServices(this IServiceCollection services)
        {
            //Add Transient Repositories
            services.AddTransient<CityRepository>();
            services.AddTransient<OfferRepository>();
            services.AddTransient<AlternativeRepository>();

            //Setup AutoRegister services by attribute
            services.RegisterAssemblyPublicNonGenericClasses()
                .Where(c => c.Name.EndsWith("Service") && 
                            c.GetCustomAttributes<AutoRegisterServiceAttribute>().Any())
                .AsPublicImplementedInterfaces();

            services.AddAutoMapper(typeof(DependencyInjection));

            return services;
        }
    }
}