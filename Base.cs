using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace test_hilo
{
    public class ScriptBase
    {
        protected readonly ServiceCollection Services;

        protected readonly ServiceProvider ServiceProvider;

        protected MainDbContext MainDbContext => ServiceProvider.GetService<MainDbContext>();

        /// <summary>Строка соединения с БД</summary>
        public const string CONNECTION_STRING = "Host=localhost;Port=5432;Database=test;Username=test;Password=test;Include Error Detail=true;Command Timeout=0;";
        
        public ScriptBase(ITestOutputHelper output)
        {
            Services = new ServiceCollection();

            Services.AddDbContext<MainDbContext>(options =>
            {
                options.UseNpgsql(CONNECTION_STRING);
                //options.UseLoggerFactory(MainDbContext.LoggerFactory);
            });


            Services.AddLogging(config =>
            {
                //config.AddDebug();
                //config.AddConsole();
                //etc
            });
            /*Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(output)
                .CreateLogger();*/

            ServiceProvider = Services.BuildServiceProvider();

            // Настройки журналирования

        }

        [Fact]
        public void DatabaseMigrate()
        {
            MainDbContext.Database.Migrate();
        }
    }
}