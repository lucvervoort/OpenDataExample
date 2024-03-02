using OpenDataExample.Database;
using Microsoft.EntityFrameworkCore;

namespace OpenDataExample
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient("httpClient");
            builder.Services.AddSingleton<HttpClientFactory>();
            
            builder.Services.AddSingleton<SeedData>();

            // voeg toe: dotnet add package
            //      Microsoft.EntityFrameworkCore.SqlServer
            //      Microsoft.EntityFrameworkCore.Tools
            builder.Services.AddDbContext<MyApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext"))
                , contextLifetime: ServiceLifetime.Scoped
                , optionsLifetime: ServiceLifetime.Singleton); // default bestaan options enkel scoped en we willen ze gebruiken in SeedData

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // We maken hier ook een service van - dan zorgt DI voor alle parameters ...
            var seedData = app.Services.GetService<SeedData>();
            seedData?.Initialize();
/*
            if(seedData != null)
            {
                seedData.Initialize();
            }
*/
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
