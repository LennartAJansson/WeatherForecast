namespace WeatherForecast.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class WeatherForecastDbContextFactory : IDesignTimeDbContextFactory<WeatherForecastDbContext>
{
    private static readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherForecastDb;Integrated Security=True;";

    public WeatherForecastDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<WeatherForecastDbContext> optionsBuilder = new DbContextOptionsBuilder<WeatherForecastDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new WeatherForecastDbContext(optionsBuilder.Options);
    }
}