﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptor;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers
{
  
        public class AutofacBusinessModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
                builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

                builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
                builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

                builder.RegisterType<UserManager>().As<IUserService>();
                builder.RegisterType<EfUserDal>().As<IUserDal>();

                builder.RegisterType<RentalManager>().As<IRentalService>();
                builder.RegisterType<EfRentalDal>().As<IRentalDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}

