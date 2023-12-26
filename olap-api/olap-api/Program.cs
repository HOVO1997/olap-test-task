using Microsoft.EntityFrameworkCore;
using olap_api.Data;
using olap_api.Repositories;
using System.Text.Json.Serialization;

namespace olap_api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // CORS
            builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            }));

            // Logger
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Add services to the container.

            builder.Services.AddControllers();

            // Db Context
            builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

            // Singletones
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();
            builder.Services.AddScoped<IIndicatorRepository, IndicatorRepository>();
            builder.Services.AddScoped<IDataPointRpository, DataPointRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors("ApiCorsPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
