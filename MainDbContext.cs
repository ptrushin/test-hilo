using Microsoft.EntityFrameworkCore;

namespace test_hilo
{
    public class MainDbContext : DbContext
    {
        public DbSet<Ware> Ware { get; set; }

        public DbSet<Order> Order { get; set; }
        
        //public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => { builder.AddConsole(); });

        /// <summary>ctor</summary>
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasSequence<long>("EFHiLoSequence100").IncrementsBy(100);
            builder.UseHiLo("EFHiLoSequence100");
        }
    }
}