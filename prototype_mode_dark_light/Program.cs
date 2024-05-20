using Microsoft.Extensions.DependencyInjection;
using prototype_mode_dark_light.contracts;
using prototype_mode_dark_light.domain.services;

namespace prototype_mode_dark_light
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IThemeService, ThemeService>();
            services.AddTransient<Form1>();
        }
    }
}