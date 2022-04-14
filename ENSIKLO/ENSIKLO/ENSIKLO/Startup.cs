﻿
using Microsoft.Extensions.DependencyInjection;
using System;
using ENSIKLO.Services;
using ENSIKLO.ViewModels;
using System.Diagnostics;

namespace ENSIKLO
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services

            //services.AddSingleton<IBookService, DummyBookStore>();
            //services.AddSingleton<IUserService, DummyUser>();


            services.AddHttpClient<IBookService, APIBookService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:49067/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<IUserService, APIUserService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:49067/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<ILibraryUserService, APILibraryUserService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:49067/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });


            //add viewmodels
            services.AddTransient<BookViewModel>();
            services.AddTransient<BookDetailViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<ProfileViewModel>();
            services.AddTransient<CatalogViewModel>();
            services.AddTransient<NewArrivalViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
