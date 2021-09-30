using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace test_hilo
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        /// <summary></summary>
        public static MainDbContext MainDbContext;

        /// <summary>Строка соединения с БД</summary>
        public const string CONNECTION_STRING = "Host=localhost;Port=5432;Database=test;Username=test;Password=test;Include Error Detail=true;Command Timeout=0;";
        
        /// <summary></summary>
        public MainDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MainDbContext>();

            builder.UseNpgsql(CONNECTION_STRING);
 
            MainDbContext = new MainDbContext(builder.Options);

            return MainDbContext;
        }
    }
}