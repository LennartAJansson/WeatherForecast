namespace WeatherForecast.Db
{

    using global::WeatherForecast.Db.Abstract;

    using Microsoft.EntityFrameworkCore;

    public class WeatherForecastDbContext : DbContext, IWeatherForecastDbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().HasKey(t => t.Id);
            modelBuilder.Entity<WeatherForecast>().HasIndex(t => t.Date);
            //modelBuilder.Entity<Office>().HasKey(t => t.OfficeId);
            //modelBuilder.Entity<Occasion>().HasKey(t => t.OccasionId);
            //modelBuilder.Entity<Activity>().HasKey(t => t.ActivityId);
            //modelBuilder.Entity<ActivityType>().HasKey(t => t.ActivityTypeId);
            //modelBuilder.Entity<Occasion>().HasOne<Account>().WithMany().HasForeignKey(o => o.AccountId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Occasions_Accounts_AccountId");
        }
    }
}