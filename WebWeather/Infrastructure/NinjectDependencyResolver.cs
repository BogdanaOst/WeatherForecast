﻿using BLL.Managers;
using DAL.UnitOfWork;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebWeather.Services;

namespace WebWeather.Resolver
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IForecastService>().To<ForecastService>(); 
            kernel.Bind<IHistoryManager>().To<HistoryManager>(); 
            kernel.Bind<ISelectedCityManager>().To<SelectedCityManager>(); 
        }
    }
}