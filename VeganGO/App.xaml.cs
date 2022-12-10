using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VeganGO.Infrastructure;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        private static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient<MainViewModel>();
                services.AddTransient<LoginViewModel>();
                services.AddTransient<RegistrationViewModel>();
                services.AddTransient<ArticleViewModel>();

                services.AddSingleton(s =>
                    new MainWindow(s.GetRequiredService<MainViewModel>()));

                services.AddPooledDbContextFactory<EfContext>(x =>
                    x.UseSqlite("Data Source=VeganGO.db"));//.UseLazyLoadingProxies());

                services.AddSingleton<IStore, Store>();
                services.AddSingleton<IUserRepository, UserRepository>();
                services.AddSingleton<IMaterialRepository, MaterialRepository>();
                services.AddSingleton<ITagRepository, TagRepository>();
            });
            return hostBuilder;
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var window = _host.Services.GetRequiredService<MainWindow>();

            var contextFactory = _host.Services.GetRequiredService<IDbContextFactory<EfContext>>();
            await using var context = contextFactory.CreateDbContext();
            await context.Database.MigrateAsync();
            
            window.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}