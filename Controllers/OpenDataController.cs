using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenDataExample.Database;

namespace OpenDataExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenDataController : ControllerBase
    {
        private readonly ILogger<OpenDataController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public OpenDataController(ILogger<OpenDataController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetAddresses")]
        public ActionResult<IEnumerable<AddressDTO>> Get()
        {
            var addresses = new List<AddressDTO>();
            var w = _dbContext?.Welcome?.Include(c => c.Results)?.ThenInclude(r => r.GeoPoint2D)?.FirstOrDefault();
            if (w != null)
            {
                foreach (var a in w.Results)
                {
                    addresses.Add(new AddressDTO { Name = a.Naam, StreetName = a.Straat, StreetNumber = a.Huisnr, City = a.Eigenaar });
                }
            }
            return Ok(addresses);
        }
    }
}
