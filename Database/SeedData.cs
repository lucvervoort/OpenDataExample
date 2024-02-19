using Microsoft.EntityFrameworkCore;
using OpenDataExample.Models;

namespace OpenDataExample.Database
{

    public class SeedData
    {
        private readonly ILogger _logger;
        private readonly HttpClientRepository _httpClientRepository;
        private readonly IServiceProvider _serviceProvider;

        public SeedData(ILogger<SeedData> logger, HttpClientRepository httpClientRepository, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _httpClientRepository = httpClientRepository;
            _serviceProvider = serviceProvider;
        }

        public async void Initialize()
        {
            using (var context = new ApplicationDbContext(
                _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any Laureates or Prizes.
                if (context.Welcome.Any())
                {
                    return;   // DB has been seeded
                }

                Welcome welcome = await _httpClientRepository.GetAsync<Welcome>("https://data.stad.gent/api/explore/v2.1/catalog/datasets/fietsenstallingen-gent/records?limit=20&refine=naam%3A%22Braunplein%22");
                context.Welcome.Add(welcome);
                context.SaveChanges();

                /*
                //get the json file from the wwwroot folder.
                var env = serviceProvider.GetRequiredService<IWebHostEnvironment>();
                var path = Path.Combine(env.WebRootPath, "files", "Laureate.json");
                //read the json content and then deserialize it to object,
                var jsonString = System.IO.File.ReadAllText(path);
                if (jsonString != null)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    Prize item = System.Text.Json.JsonSerializer.Deserialize<Prize>(jsonString);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                    if (item != null)
                    {
                        context.Prizes.Add(item); //insert the data to the database.
                        context.SaveChanges();
                    }
                }
                */
            }
        }
    }
}
