using Session_2_Lommeregner.Core;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Session_2_Lommeregner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            // Registrer operations
            services.AddTransient<IOperation, AddOperation>();
            services.AddTransient<IOperation, SubtractOperation>();
            services.AddTransient<IOperation, MultiplyOperation>();
            services.AddTransient<IOperation, DivideOperation>();

            // Registrer Calculator med alle IOperation implementeringer
            services.AddSingleton<Calculator>(sp =>
            {
                var operations = sp.GetServices<IOperation>();
                return new Calculator(operations);
            });

            // Registrer CalculatorEngine
            services.AddSingleton<CalculatorEngine>();

            // Registrer MainWindow
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _serviceProvider?.Dispose();
            base.OnExit(e);
        }
    }
}
