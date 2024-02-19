using OpenDataExample.Database;
using Microsoft.EntityFrameworkCore;

namespace OpenDataExample
{
    public class HttpClientRepository
    {
        private IHttpClientFactory _httpClientFactory;

        public HttpClientRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            var client = _httpClientFactory.CreateClient("HttpClient");
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");
            var responseObject = await response.Content.ReadFromJsonAsync<T>();
            return responseObject;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient("httpClient");
            builder.Services.AddSingleton<HttpClientRepository>();
            builder.Services.AddSingleton<SeedData>();

            // voeg toe: Microsoft.EntityFrameworkCore.SqlServer
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
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
