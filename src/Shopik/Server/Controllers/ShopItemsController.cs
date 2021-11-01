using Entity;
using Entity.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Shopik.Server.Controllers
{
    [Route("api/shopitems")]
    [ApiController]
    public class ShopItemsController : ControllerBase
    {
        private readonly ShopikDbContext _dbContext;

        public ShopItemsController(ShopikDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public Task<List<ShopItem>> Get()
        {
            return _dbContext.ShopItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public Task PostAsync([FromBody] string name)
        {
            _dbContext.ShopItems.Add(new ShopItem
            {
                Name = name
            });

            return _dbContext.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
