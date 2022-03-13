
using Microsoft.Extensions.DependencyInjection;
using System;
using ENSIKLO.Services;
using ENSIKLO.ViewModels;

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

            services.AddHttpClient<IBookService, APIBookService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:49067/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //add viewmodels
            services.AddTransient<BookViewModel>();
            services.AddTransient<NewBookViewModel>();
            services.AddTransient<BookDetailViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
