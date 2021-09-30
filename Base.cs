using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace test_hilo
{
    public class Base
    {
        protected readonly ServiceCollection Services;

        protected readonly ServiceProvider ServiceProvider;

        protected MainDbContext MainDbContext => ServiceProvider.GetService<MainDbContext>();

        public const string CONNECTION_STRING = "Host=localhost;Port=5432;Database=test;Username=test;Password=test;Include Error Detail=true;Command Timeout=0;";
        
        public Base(ITestOutputHelper output)
        {
            Services = new ServiceCollection();

            Services.AddDbContext<MainDbContext>(options =>
            {
                options.UseNpgsql(CONNECTION_STRING);
            });


            ServiceProvider = Services.BuildServiceProvider();
        }

        [Fact]
        public void DatabaseMigrate()
        {
            MainDbContext.Database.Migrate();
        }
    }
}