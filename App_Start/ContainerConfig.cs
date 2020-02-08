using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using Banky.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Banky.App_Start
{
    public class ContainerConfig
    {
        public static void Register()
        {
            var bldr = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            bldr.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(bldr);
            bldr.RegisterWebApiFilterProvider(config);
            bldr.RegisterWebApiModelBinderProvider();
            var container = bldr.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder bldr)
        {
            var config = new MapperConfiguration(con =>
            {
                con.AddProfile(new BankMapper());
                con.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            });
            bldr.RegisterInstance(config.CreateMapper())
                .As<IMapper>()
                .SingleInstance();
            bldr.RegisterType<BankingDbContext>()
                .InstancePerRequest();
            bldr.RegisterType<BankingContext>()
                .As<IBanking>()
                .InstancePerRequest();
        }
    }
}