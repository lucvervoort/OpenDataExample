using Microsoft.EntityFrameworkCore;
using OpenDataExample.Models;

namespace OpenDataExample.Database
{

    public class SeedData
    {
        private readonly ILogger _logger;
        private readonly HttpClientFactory _httpClientFactory;
        private readonly IServiceProvider _serviceProvider;

        public SeedData(ILogger<SeedData> logger, HttpClientFactory httpClientFactory, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _serviceProvider = serviceProvider;
        }

        public async void Initialize()
        {
            using (var context = new MyApplicationDbContext(
                _serviceProvider.GetRequiredService<DbContextOptions<MyApplicationDbContext>>()))
            {
                //if (context.Welcomes.Any())
                //{
                //    return;   // DB has been seeded
                //}

                // Welcome welcome = await _httpClientFactory.GetAsync<Welcome>("https://data.stad.gent/api/explore/v2.1/catalog/datasets/fietsenstallingen-gent/records?limit=20&refine=naam%3A%22Braunplein%22");
                // context.Welcomes.Add(welcome);
                context.SaveChanges();
            }
        }
    }
}
